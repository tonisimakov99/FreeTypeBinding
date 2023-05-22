using CommandLine;
using CppSharp;
using CppSharp.AST;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BoxEngine.FreeType.Generator
{
    public class Program
    {
        public unsafe static int Main(string[] args)
        {
            var options = new Options();
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(o =>
                {
                    options = o;
                });

            var files = Directory.GetFiles(options.OutDir).Where(t => t.EndsWith(".cs"));
            foreach (var file in files)
            {
                File.Delete(file);
            }

            var parserOptions = new CppSharp.Parser.ParserOptions();
            parserOptions.AddIncludeDirs(@"C:\Users\Anton\source\repos\BoxEngine\BoxEngine.FreeType.Generator\headers");
            parserOptions.AddIncludeDirs(@"C:\Users\Anton\source\repos\BoxEngine\BoxEngine.FreeType.Generator\headers\dlg");
            parserOptions.AddIncludeDirs(@"C:\Users\Anton\source\repos\BoxEngine\BoxEngine.FreeType.Generator\headers\freetype");
            parserOptions.AddIncludeDirs(@"C:\Users\Anton\source\repos\BoxEngine\BoxEngine.FreeType.Generator\headers\freetype\config");
            parserOptions.AddIncludeDirs(@"C:\Users\Anton\source\repos\BoxEngine\BoxEngine.FreeType.Generator\headers\freetype\internal");
            parserOptions.AddIncludeDirs(@"C:\Users\Anton\source\repos\BoxEngine\BoxEngine.FreeType.Generator\headers\freetype\services");
            parserOptions.SetupMSVC(VisualStudioVersion.Latest);

            var parseResult = ClangParser.ParseSourceFiles(
                new[] {
                        options.FilePath,
                }, parserOptions);

            for (uint i = 0; i != parseResult.DiagnosticsCount; i++)
            {
                var diagnostic = parseResult.GetDiagnostics(i);
            }
            var context = ClangParser.ConvertASTContext(parserOptions.ASTContext);
            context.TranslationUnits.First().Classes.First().Fields.First().QualifiedType.Type.
             //var structs= new Dictionary<string,StructDeclarationSyntax>
             var namespaceNameSyntax = SyntaxFactory.IdentifierName(options.Namespace);

            for (uint i = 0; i != parserOptions.ASTContext.TranslationUnitsCount; i++)
            {
                var unit = parserOptions.ASTContext.GetTranslationUnits(i);
                
                for (uint j = 0; j != unit.ClassesCount; j++)
                {
                    var classItem = unit.GetClasses(j);

                    using (var fileWriter = new StreamWriter(File.OpenWrite($"{options.OutDir}/{classItem.Name}.cs")))
                    {
                        var root = SyntaxFactory.NamespaceDeclaration(namespaceNameSyntax);
                        var structD = SyntaxFactory.StructDeclaration(classItem.Name);
                        structD = structD.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));
                        
                        for (uint z = 0; z != classItem.FieldsCount; z++)
                        {
  
                            var field = classItem.GetFields(z);
                            //var a = (PointerType)field.QualifiedType.Type;
                            var fieldDeclaration = SyntaxFactory.FieldDeclaration(SyntaxFactory.VariableDeclaration(SyntaxFactory.ParseTypeName(field.Class.Name)));
                            fieldDeclaration = fieldDeclaration.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));

                            structD = structD.AddMembers(fieldDeclaration);
                        }

                        root = root.AddMembers(structD);




                        fileWriter.Write(root.NormalizeWhitespace().ToFullString());
                    }
                }
                for (uint j = 0; j != unit.TypeAliasesCount; j++)
                {
                    var item = unit.GetTypeAliases(j);
                }
                for (uint j = 0; j != unit.TypedefsCount; j++)
                {
                    var item = unit.GetTypedefs(j);
                    File.WriteAllText($"{options.OutDir}/{item.Name}.cs", "");
                }
                for (uint j = 0; j != unit.FunctionsCount; j++)
                {
                    var item = unit.GetFunctions(j);
                }
                for (uint j = 0; j != unit.VariablesCount; j++)
                {
                    var item = unit.GetVariables(j);
                }
                for (uint j = 0; j != unit.EnumsCount; j++)
                {
                    var item = unit.GetEnums(j);
                    File.WriteAllText($"{options.OutDir}/{item.Name}.cs", "");
                }
            }
            return 0;
        }
    }
}