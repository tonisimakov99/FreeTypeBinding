﻿using CommandLine;
using CppSharp;
using CppSharp.AST;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FreeTypeBinding.Generator
{
    public class Program
    {
        private static Dictionary<PrimitiveType, string> primitiveTypes = new Dictionary<PrimitiveType, string>()
        {
            { PrimitiveType.Int,"int"},
            { PrimitiveType.Long,"int"},
            { PrimitiveType.Float,"float"},
            { PrimitiveType.Double,"double"},
            { PrimitiveType.Bool,"bool"},
            { PrimitiveType.String,"string"},
            { PrimitiveType.ULong,"uint" },
            { PrimitiveType.UInt,"uint" },
            { PrimitiveType.Void,"void" },
            { PrimitiveType.UChar,"byte" },
            { PrimitiveType.UShort,"ushort" },
            { PrimitiveType.Short,"short" },
            { PrimitiveType.SChar,"sbyte" },
            { PrimitiveType.Char,"byte" },
            { PrimitiveType.ULongLong,"ulong" },
            { PrimitiveType.LongLong,"long" }
        };

        private static Dictionary<string, Class> classes= new Dictionary<string, Class>();
        private static Dictionary<string, Enumeration> enumerations = new Dictionary<string, Enumeration>();
        private static Dictionary<string, BuiltinType> enumerationBaseTypeOverrides = new Dictionary<string, BuiltinType>();
        private static Dictionary<string, Enumeration> predefinedEnumerations = new Dictionary<string, Enumeration>();
        private static Dictionary<string, Enumeration> typeOverrides = new Dictionary<string, Enumeration>();


        private static Options options;
        public static int Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(o =>
                {
                    options = o;
                });

            var parserOptions = new CppSharp.Parser.ParserOptions();
            parserOptions.AddIncludeDirs(options.IncludePath);
            parserOptions.Setup(TargetPlatform.Windows);
            parserOptions.LanguageVersion = CppSharp.Parser.LanguageVersion.C99_GNU;

            var parseResult = ClangParser.ParseSourceFiles(
                new[] {
                        options.FilePath
                }, parserOptions);

            foreach (var file in Directory.GetFiles(options.OutDir).Where(t => t.EndsWith(".cs")))
                File.Delete(file);

            for (uint i = 0; i != parseResult.DiagnosticsCount; i++)
            {
                var diagnostic = parseResult.GetDiagnostics(i);
            }
            var context = ClangParser.ConvertASTContext(parserOptions.ASTContext);

            InitTypes(context);

            var namespaceNameSyntax = SyntaxFactory.IdentifierName(options.Namespace);

            var rootSyntax = SyntaxFactory.NamespaceDeclaration(
                namespaceNameSyntax,
                default,
                new SyntaxList<UsingDirectiveSyntax>().Add(SyntaxFactory.UsingDirective(SyntaxFactory.IdentifierName("System.Runtime.InteropServices"))),
                default);

            var classSyntax = SyntaxFactory.ClassDeclaration("FT");
            classSyntax = classSyntax.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));
            classSyntax = classSyntax.AddModifiers(SyntaxFactory.Token(SyntaxKind.UnsafeKeyword));
            classSyntax = classSyntax.AddModifiers(SyntaxFactory.Token(SyntaxKind.StaticKeyword));


            var attributesArgsList = new SeparatedSyntaxList<AttributeArgumentSyntax>();
            attributesArgsList = attributesArgsList.Add(
                SyntaxFactory.AttributeArgument(
                    SyntaxFactory.LiteralExpression(
                        SyntaxKind.StringLiteralExpression,
                            SyntaxFactory.Literal("runtimes/win-x64/freetype.dll"))));
            attributesArgsList = attributesArgsList.Add(
                SyntaxFactory.AttributeArgument(SyntaxFactory.ParseExpression("CallingConvention = CallingConvention.Cdecl")));


            var dllImportAttribute = SyntaxFactory.Attribute(
                SyntaxFactory.IdentifierName("DllImport"),
                SyntaxFactory.AttributeArgumentList(attributesArgsList)
                );

            var funcSyntaxTypes = new List<MethodDeclarationSyntax>();

            using (var fileWriter = new StreamWriter(File.OpenWrite($"{options.OutDir}/FreeType.cs")))
            {
                foreach (var translationUnit in context.TranslationUnits)
                {
                    foreach (var _func in translationUnit.Functions)
                    {
                        var modifiers = new SyntaxTokenList();
                        modifiers = modifiers.Add(SyntaxFactory.Token(SyntaxKind.PublicKeyword));
                        modifiers = modifiers.Add(SyntaxFactory.Token(SyntaxKind.StaticKeyword));
                        modifiers = modifiers.Add(SyntaxFactory.Token(SyntaxKind.ExternKeyword));

                        var attributes = new SyntaxList<AttributeListSyntax>();
                        attributes = attributes.Add(SyntaxFactory.AttributeList(new SeparatedSyntaxList<AttributeSyntax>().Add(dllImportAttribute)));
                        var parameters = new SeparatedSyntaxList<ParameterSyntax>();

                        foreach (var parameter in _func.Parameters)
                        {
                            TypeSyntax paramType;
                            if (typeOverrides.ContainsKey(parameter.Name))
                                paramType = GetTypeSyntax(context, new TagType()
                                {
                                    Declaration = typeOverrides[parameter.Name]
                                });
                            else
                                paramType = GetTypeSyntax(context, parameter.Type);
                            parameters = parameters.Add(SyntaxFactory.Parameter(default, default, paramType, SyntaxFactory.Identifier(parameter.Name), default));
                        }

                        var returnTypeSyntax = GetTypeSyntax(context, _func.ReturnType.Type);
                        var funcSyntax = SyntaxFactory.MethodDeclaration(
                            attributes,
                            modifiers,
                            returnTypeSyntax,
                            null,
                            SyntaxFactory.Identifier(_func.Name),
                            null,
                            SyntaxFactory.ParameterList(parameters),
                            default,
                            null,
                            SyntaxFactory.Token(SyntaxKind.SemicolonToken));


                        funcSyntaxTypes.Add(funcSyntax);
                    }
                }

                classSyntax = classSyntax.AddMembers(funcSyntaxTypes.ToArray());
                rootSyntax = rootSyntax.AddMembers(classSyntax);
                fileWriter.Write(rootSyntax.NormalizeWhitespace().ToFullString());
            }

            return 0;
        }

        private static List<string> registeredTypes = new List<string>();
        private static TypeSyntax GetTypeSyntax(ASTContext context, Type type)
        {
            var typedefType = type as TypedefType;
            var pointerType = type as PointerType;
            var builtInType = type as BuiltinType;
            var tagType = type as TagType;
            var functionType = type as FunctionType;

            if (typedefType != null)
            {
                if (typedefType.Declaration.Name == "FT_Error")
                    return GetTypeSyntax(context, new TagType()
                    {
                        Declaration = new Enumeration()
                        {
                            Name = "FT_Error"
                        }
                    });
                return GetTypeSyntax(context, typedefType.Declaration.Type);
            }

            if (pointerType != null)
                return SyntaxFactory.PointerType(GetTypeSyntax(context, pointerType.Pointee));

            if (builtInType != null)
                return SyntaxFactory.ParseTypeName(primitiveTypes[builtInType.Type]);

            if (tagType != null)
            {
                if (!registeredTypes.Contains(tagType.Declaration.Name))
                    RegisterType(context, tagType.Declaration.Name);

                return SyntaxFactory.ParseTypeName(tagType.Declaration.Name);
            }

            if (functionType != null)
            {
                var parameters = new SeparatedSyntaxList<FunctionPointerParameterSyntax>();

                foreach (var parameter in functionType.Parameters)
                    parameters = parameters.Add(SyntaxFactory.FunctionPointerParameter(GetTypeSyntax(context, parameter.Type)));

                return SyntaxFactory.FunctionPointerType(
                    SyntaxFactory.FunctionPointerCallingConvention(SyntaxFactory.Token(SyntaxKind.UnmanagedKeyword)),
                    SyntaxFactory.FunctionPointerParameterList(parameters)
                    );
            }

            throw new System.Exception("type not handled");
        }

        private static void InitTypes(ASTContext context)
        {
            foreach (var translationUnit in context.TranslationUnits)
            {
                foreach (var _class in translationUnit.Classes)
                {
                    classes.Add(_class.Name, _class);
                }
            }

            enumerationBaseTypeOverrides.Add("FT_Pixel_Mode_", new BuiltinType() { Type = PrimitiveType.UChar });

            var errCount = 0;
            foreach (var translationUnit in context.TranslationUnits)
            {
                foreach (var _enum in translationUnit.Enums)
                {
                    if (_enum.Name == "")
                    {
                        if (errCount == 0)
                            enumerations.Add($"", _enum);
                        else
                        {
                            _enum.Name = "FT_Error";
                            enumerations.Add("FT_Error", _enum);
                        }
                        errCount++;
                    }
                    else
                    {
                        if(enumerationBaseTypeOverrides.ContainsKey(_enum.Name))
                        {
                            _enum.Type = enumerationBaseTypeOverrides[_enum.Name];
                        }
                        enumerations.Add(_enum.Name, _enum);
                    }
                }
            }

            //AddPreprocessedEnumeration(context, "load_flags", "FT_LOAD", "FT_LOAD_TARGET");
            //AddPreprocessedEnumeration(context, "face_flags", "FT_FACE_FLAG");
            //AddPreprocessedEnumeration(context, "style_flags", "FT_STYLE_FLAG");

            AddPreprocessedEnumeration(context, "FT_LOAD", "FT_LOAD_TARGET");
            AddPreprocessedEnumeration(context, "FT_FACE_FLAG");
            AddPreprocessedEnumeration(context, "FT_STYLE_FLAG");

            typeOverrides.Add("load_flags", predefinedEnumerations["FT_LOAD"]);
            typeOverrides.Add("face_flags", predefinedEnumerations["FT_FACE_FLAG"]);
            typeOverrides.Add("style_flags", predefinedEnumerations["FT_STYLE_FLAG"]);
            typeOverrides.Add("pixel_mode", enumerations["FT_Pixel_Mode_"]);
        }

        private static void AddPreprocessedEnumeration(ASTContext context, string startsWith, string? notStartsWith = default)
        {
            if (!predefinedEnumerations.ContainsKey(startsWith))
            {
                var definations = new Dictionary<string, string>();
                foreach (var translationUnit in context.TranslationUnits)
                {
                    foreach (var _preprocessed in translationUnit.PreprocessedEntities)
                    {
                        var macroDefination = _preprocessed as MacroDefinition;
                        if (macroDefination != default)
                        {
                            if (notStartsWith != default)
                            {
                                if (macroDefination.Name.StartsWith(startsWith) && !macroDefination.Name.StartsWith(notStartsWith))
                                    definations.Add(macroDefination.Name, macroDefination.Expression.Replace("L", ""));
                            }
                            else
                            {
                                if (macroDefination.Name.StartsWith(startsWith))
                                    definations.Add(macroDefination.Name, macroDefination.Expression.Replace("L", ""));
                            }
                        }
                    }
                }

                predefinedEnumerations.Add(startsWith, new Enumeration()
                {
                    Name = startsWith,
                    Type = new BuiltinType() { Type = PrimitiveType.Long },
                    Items = definations.Select(t => new Enumeration.Item() { Name = t.Key, Expression = t.Value }).ToList()
                });
            }
        }

        private static void RegisterType(ASTContext context, string typeName)
        {
            registeredTypes.Add(typeName);

            if (classes.ContainsKey(typeName))
            {
                var _class = classes[typeName];
                using (var fileWriter = new StreamWriter(File.OpenWrite($"{options.OutDir}/{_class.Name}.cs")))
                {
                    var namespaceNameSyntax = SyntaxFactory.IdentifierName(options.Namespace);

                    var rootSyntax = SyntaxFactory.NamespaceDeclaration(
                        namespaceNameSyntax,
                        default,
                        new SyntaxList<UsingDirectiveSyntax>().Add(SyntaxFactory.UsingDirective(SyntaxFactory.IdentifierName("System.Runtime.InteropServices"))),
                        default);
                    var attribute = SyntaxFactory.Attribute(
                                  SyntaxFactory.IdentifierName("StructLayout"),
                                  SyntaxFactory.AttributeArgumentList(
                                      new SeparatedSyntaxList<AttributeArgumentSyntax>().Add(
                                          SyntaxFactory.AttributeArgument(SyntaxFactory.ParseExpression("LayoutKind.Sequential")))));

                    var _struct = SyntaxFactory.StructDeclaration(_class.Name);
                    _struct = _struct.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));
                    _struct = _struct.AddModifiers(SyntaxFactory.Token(SyntaxKind.UnsafeKeyword));
                    _struct = _struct.AddAttributeLists(SyntaxFactory.AttributeList(new SeparatedSyntaxList<AttributeSyntax>().Add(attribute)));
                    foreach (var field in _class.Fields)
                    {
                        TypeSyntax typeSyntax;
                        if (typeOverrides.ContainsKey(field.Name))
                        {
                            typeSyntax = GetTypeSyntax(context, new TagType()
                            {
                                Declaration = typeOverrides[field.Name]
                            });
                        }
                        else
                            typeSyntax = GetTypeSyntax(context, field.Type);
                        var variablesList = new SeparatedSyntaxList<VariableDeclaratorSyntax>();
                        var name = field.Name;
                        if (name == "internal" || name == "base" || name == "params")
                            name = "_" + name;
                        variablesList = variablesList.Add(SyntaxFactory.VariableDeclarator(name));
                        var fieldDeclaration = SyntaxFactory.FieldDeclaration(SyntaxFactory.VariableDeclaration(typeSyntax, variablesList));

                        fieldDeclaration = fieldDeclaration.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));
                        _struct = _struct.AddMembers(fieldDeclaration);
                    }

                    rootSyntax = rootSyntax.AddMembers(_struct);

                    fileWriter.Write(rootSyntax.NormalizeWhitespace().ToFullString());
                }
            }
            else if (enumerations.ContainsKey(typeName))
            {
                var _enum = enumerations[typeName];
                using (var fileWriter = new StreamWriter(File.OpenWrite($"{options.OutDir}/{_enum.Name}.cs")))
                {
                    var namespaceNameSyntax = SyntaxFactory.IdentifierName(options.Namespace);
                    var root = SyntaxFactory.NamespaceDeclaration(namespaceNameSyntax);
                    var type = _enum.Type as BuiltinType;

                    var _enumDeclaration = SyntaxFactory.EnumDeclaration(_enum.Name);
                    _enumDeclaration = _enumDeclaration.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));
                    _enumDeclaration = _enumDeclaration.WithBaseList(
                        SyntaxFactory.BaseList(
                            new SeparatedSyntaxList<BaseTypeSyntax>().Add(SyntaxFactory.SimpleBaseType(GetTypeSyntax(context, type)))));

                    foreach (var item in _enum.Items)
                    {
                        var _enumMemberDeclaration = SyntaxFactory.EnumMemberDeclaration(item.Name);
                        _enumMemberDeclaration = _enumMemberDeclaration.WithEqualsValue(
                            SyntaxFactory.EqualsValueClause(SyntaxFactory.ParseExpression(item.Value.ToString())));
                        _enumDeclaration = _enumDeclaration.AddMembers(_enumMemberDeclaration);
                    }

                    root = root.AddMembers(_enumDeclaration);

                    fileWriter.Write(root.NormalizeWhitespace().ToFullString());
                }
            }
            else if (predefinedEnumerations.ContainsKey(typeName))
            {
                var _enum = predefinedEnumerations[typeName];
                using (var fileWriter = new StreamWriter(File.OpenWrite($"{options.OutDir}/{_enum.Name}.cs")))
                {
                    var namespaceNameSyntax = SyntaxFactory.IdentifierName(options.Namespace);
                    var root = SyntaxFactory.NamespaceDeclaration(namespaceNameSyntax);
                    var type = _enum.Type as BuiltinType;

                    var _enumDeclaration = SyntaxFactory.EnumDeclaration(_enum.Name);
                    _enumDeclaration = _enumDeclaration.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));
                    _enumDeclaration = _enumDeclaration.WithBaseList(
                        SyntaxFactory.BaseList(
                            new SeparatedSyntaxList<BaseTypeSyntax>().Add(SyntaxFactory.SimpleBaseType(GetTypeSyntax(context, type)))));

                    foreach (var item in _enum.Items)
                    {
                        var _enumMemberDeclaration = SyntaxFactory.EnumMemberDeclaration(item.Name);
                        _enumMemberDeclaration = _enumMemberDeclaration.WithEqualsValue(
                            SyntaxFactory.EqualsValueClause(SyntaxFactory.ParseExpression(item.Expression)));
                        _enumDeclaration = _enumDeclaration.AddMembers(_enumMemberDeclaration);
                    }

                    root = root.AddMembers(_enumDeclaration);

                    fileWriter.Write(root.NormalizeWhitespace().ToFullString());
                }
            }
            else
            {
                throw new System.Exception("not supproted type");
            }
        }
    }
}