using CommandLine;
using CppSharp;
using CppSharp.AST;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Std.Vector;
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
            { PrimitiveType.Long,"long"},
            { PrimitiveType.Float,"float"},
            { PrimitiveType.Double,"double"},
            { PrimitiveType.Bool,"bool"},
            { PrimitiveType.String,"string"},
            { PrimitiveType.ULong,"ulong" },
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
                        options.FilePath,
                }, parserOptions);

            foreach (var file in Directory.GetFiles(options.OutDir).Where(t => t.EndsWith(".cs")))
                File.Delete(file);

            for (uint i = 0; i != parseResult.DiagnosticsCount; i++)
            {
                var diagnostic = parseResult.GetDiagnostics(i);
            }
            var context = ClangParser.ConvertASTContext(parserOptions.ASTContext);

            var namespaceNameSyntax = SyntaxFactory.IdentifierName(options.Namespace);

            var rootSyntax = SyntaxFactory.NamespaceDeclaration(
                namespaceNameSyntax,
                default,
                new SyntaxList<UsingDirectiveSyntax>().Add(SyntaxFactory.UsingDirective(SyntaxFactory.IdentifierName("System.Runtime.InteropServices"))),
                default);

            var classSyntax = SyntaxFactory.ClassDeclaration("FreeType");
            classSyntax = classSyntax.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));
            classSyntax = classSyntax.AddModifiers(SyntaxFactory.Token(SyntaxKind.UnsafeKeyword));
            classSyntax = classSyntax.AddModifiers(SyntaxFactory.Token(SyntaxKind.StaticKeyword));


            var attribute = SyntaxFactory.Attribute(
                SyntaxFactory.IdentifierName("DllImport"),
                SyntaxFactory.AttributeArgumentList(new SeparatedSyntaxList<AttributeArgumentSyntax>().Add(SyntaxFactory.AttributeArgument(SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal("freetype.dll")))))
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
                        attributes = attributes.Add(SyntaxFactory.AttributeList(new SeparatedSyntaxList<AttributeSyntax>().Add(attribute)));
                        var parameters = new SeparatedSyntaxList<ParameterSyntax>();
                        foreach (var parameter in _func.Parameters)
                            parameters = parameters.Add(SyntaxFactory.Parameter(default, default, GetTypeSyntax(context, parameter.Type), SyntaxFactory.Identifier(parameter.Name), default));

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

        private static Dictionary<string, Type> registeredTypes = new Dictionary<string, Type>();
        private static TypeSyntax GetTypeSyntax(ASTContext context, Type type)
        {
            var typedefType = type as TypedefType;
            var pointerType = type as PointerType;
            var builtInType = type as BuiltinType;
            var tagType = type as TagType;
            var functionType = type as FunctionType;

            if (typedefType != null)
                return GetTypeSyntax(context, typedefType.Declaration.Type);

            if (pointerType != null)
                return SyntaxFactory.PointerType(GetTypeSyntax(context, pointerType.Pointee));

            if (builtInType != null)
                return SyntaxFactory.ParseTypeName(primitiveTypes[builtInType.Type]);

            if (tagType != null)
            {
                if (!registeredTypes.ContainsKey(tagType.Declaration.Name))
                    RegisterType(context, tagType);

                return SyntaxFactory.ParseTypeName(tagType.Declaration.Name);
            }

            if (functionType != null)
                return SyntaxFactory.FunctionPointerType();

            throw new System.Exception("type not handled");
        }

        private static Dictionary<string, Class> classes;
        private static Dictionary<string, Enumeration> enumerations;
        private static void RegisterType(ASTContext context, TagType tagType)
        {
            if (classes == default)
            {
                classes = new Dictionary<string, Class>();

                foreach (var translationUnit in context.TranslationUnits)
                {
                    foreach (var _class in translationUnit.Classes)
                    {
                        classes.Add(_class.Name, _class);
                    }
                }
            }

            if (enumerations == default)
            {
                enumerations = new Dictionary<string, Enumeration>();

                foreach (var translationUnit in context.TranslationUnits)
                {
                    foreach (var _enum in translationUnit.Enums)
                    {
                        if (_enum.Name == "")
                            System.Console.WriteLine(_enum.DebugText);
                        else
                            enumerations.Add(_enum.Name, _enum);
                    }
                }
            }


            registeredTypes.Add(tagType.Declaration.Name, tagType);

            if (classes.ContainsKey(tagType.Declaration.Name))
            {
                var _class = classes[tagType.Declaration.Name];
                using (var fileWriter = new StreamWriter(File.OpenWrite($"{options.OutDir}/{_class.Name}.cs")))
                {
                    var namespaceNameSyntax = SyntaxFactory.IdentifierName(options.Namespace);
                    var root = SyntaxFactory.NamespaceDeclaration(namespaceNameSyntax);
                    var _struct = SyntaxFactory.StructDeclaration(_class.Name);
                    _struct = _struct.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));
                    _struct = _struct.AddModifiers(SyntaxFactory.Token(SyntaxKind.UnsafeKeyword));
                    foreach (var field in _class.Fields)
                    {
                        var typeSyntax = GetTypeSyntax(context, field.Type);
                        var variablesList = new SeparatedSyntaxList<VariableDeclaratorSyntax>();
                        var name = field.Name;
                        if (name == "internal" || name == "base")
                            name = "_" + name;
                        variablesList = variablesList.Add(SyntaxFactory.VariableDeclarator(name));
                        var fieldDeclaration = SyntaxFactory.FieldDeclaration(SyntaxFactory.VariableDeclaration(typeSyntax, variablesList));

                        fieldDeclaration = fieldDeclaration.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));
                        _struct = _struct.AddMembers(fieldDeclaration);
                    }

                    root = root.AddMembers(_struct);

                    fileWriter.Write(root.NormalizeWhitespace().ToFullString());
                }
            }
            else if (enumerations.ContainsKey(tagType.Declaration.Name))
            {
                var _enum = enumerations[tagType.Declaration.Name];
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
                        if (type.Type == PrimitiveType.Int)
                        {
                            var _enumMemberDeclaration = SyntaxFactory.EnumMemberDeclaration(item.Name);
                            _enumMemberDeclaration = _enumMemberDeclaration.WithEqualsValue(
                                SyntaxFactory.EqualsValueClause(
                                    SyntaxFactory.LiteralExpression(
                                        SyntaxKind.StringLiteralExpression,
                                        SyntaxFactory.Literal((int)item.Value))));
                            _enumDeclaration = _enumDeclaration.AddMembers(_enumMemberDeclaration);
                        }
                        else
                            throw new System.Exception("not supported type");
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