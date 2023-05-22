using CommandLine;
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
            { PrimitiveType.Char,"sbyte" }
        };
        private static TypeSyntax GetTypeSyntax(Type type)
        {
            var typedefType = type as TypedefType;
            var pointerType = type as PointerType;
            var builtInType = type as BuiltinType;
            var tagType = type as TagType;

            if (typedefType != null)
                return SyntaxFactory.ParseTypeName(typedefType.Declaration.Name);

            if (pointerType != null)
                return SyntaxFactory.PointerType(GetTypeSyntax(pointerType.Pointee));

            if (builtInType != null)
                return SyntaxFactory.ParseTypeName(primitiveTypes[builtInType.Type]);

            if (tagType != null)
                return SyntaxFactory.ParseTypeName(tagType.Declaration.Name);

            throw new System.Exception("type not handled");
        }

        public static int Main(string[] args)
        {
            var options = new Options();
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(o =>
                {
                    options = o;
                });

            var parserOptions = new CppSharp.Parser.ParserOptions();
            parserOptions.AddIncludeDirs(options.IncludePath);
            parserOptions.Setup(TargetPlatform.Windows);

            var parseResult = ClangParser.ParseSourceFiles(
                new[] {
                        options.FilePath,
                }, parserOptions);

            for (uint i = 0; i != parseResult.DiagnosticsCount; i++)
            {
                var diagnostic = parseResult.GetDiagnostics(i);
            }
            var context = ClangParser.ConvertASTContext(parserOptions.ASTContext);

            var namespaceNameSyntax = SyntaxFactory.IdentifierName(options.Namespace);


            var typeDefs = new Dictionary<string, string>();

            foreach (var translationUnit in context.TranslationUnits)
            {
                foreach (var typedef in translationUnit.Typedefs)
                {
                    var typeSyntax = GetTypeSyntax(typedef.Type);
                    typeDefs.Add(typedef.Name, typeSyntax.ToFullString());
                }

                foreach (var _class in translationUnit.Classes)
                {
                    using (var fileWriter = new StreamWriter(File.OpenWrite($"{options.OutDir}/{_class.Name}.cs")))
                    {
                        var root = SyntaxFactory.NamespaceDeclaration(namespaceNameSyntax);
                        var _struct = SyntaxFactory.StructDeclaration(_class.Name);
                        _struct = _struct.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));
                        _struct = _struct.AddModifiers(SyntaxFactory.Token(SyntaxKind.UnsafeKeyword));
                        foreach (var field in _class.Fields)
                        {
                            var typeSyntax = GetTypeSyntax(field.Type);
                            var variablesList = new SeparatedSyntaxList<VariableDeclaratorSyntax>();
                            variablesList = variablesList.Add(SyntaxFactory.VariableDeclarator(field.Name));
                            var fieldDeclaration = SyntaxFactory.FieldDeclaration(SyntaxFactory.VariableDeclaration(typeSyntax, variablesList));

                            fieldDeclaration = fieldDeclaration.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));
                            _struct = _struct.AddMembers(fieldDeclaration);
                        }

                        root = root.AddMembers(_struct);

                        fileWriter.Write(root.NormalizeWhitespace().ToFullString());
                    }
                }


                foreach (var _enum in translationUnit.Enums)
                {

                }

                foreach (var typeReference in translationUnit.TypeReferences)
                {

                }

                foreach (var variable in translationUnit.Variables)
                {

                }
            }

            return 0;
        }
    }
}