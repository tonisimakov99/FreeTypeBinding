using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;
using CppSharp.Generators.CSharp;
using CppSharp.Passes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace BoxEngine.FreeType.Generator
{
    public class FreetypeLibrary : ILibrary
    {
        public void Postprocess(Driver driver, ASTContext ctx)
        {

        }

        public void Preprocess(Driver driver, ASTContext ctx)
        {

        }

        public void Setup(Driver driver)
        {
            var options = driver.Options;
            options.GeneratorKind = GeneratorKind.CSharp;
            options.OutputDir = "BoxEngine.FreeType";
            options.GenerationOutputMode = GenerationOutputMode.FilePerUnit;
            options.GenerateDefaultValuesForArguments = true;
            
            var module = options.AddModule("BoxEngine.FreeType");
            
            var directory = Directory.GetCurrentDirectory();
            driver.ParserOptions.SetupMSVC(VisualStudioVersion.Latest);
            
            module.LibraryName = "freetype.dll";
            module.OutputNamespace = "BoxEngine.FreeType";
            //module.LibraryName = "freetype.a";
            //module.Headers.AddRange(Generate($"{directory}\\headers"));
            module.Headers.Add($"{directory}\\headers\\main.h");

            module.IncludeDirs.Add($"{directory}\\headers");
            module.IncludeDirs.Add($"{directory}\\headers\\dlg");
            module.IncludeDirs.Add($"{directory}\\headers\\freetype");
            module.IncludeDirs.Add($"{directory}\\headers\\freetype\\config");
            module.IncludeDirs.Add($"{directory}\\headers\\freetype\\internal");
            module.IncludeDirs.Add($"{directory}\\headers\\freetype\\internal\\services");
            //var parserOptions = driver.ParserOptions;

            //parserOptions.AddIncludeDirs($"{directory}\\headers");
            //parserOptions.AddIncludeDirs($"{directory}\\headers\\dlg");
            //parserOptions.AddIncludeDirs($"{directory}\\headers\\freetype");
            //parserOptions.AddIncludeDirs($"{directory}\\headers\\freetype\\config");
            //parserOptions.AddIncludeDirs($"{directory}\\headers\\freetype\\internal");
            //parserOptions.AddIncludeDirs($"{directory}\\headers\\freetype\\internal\\services");
        }

        private List<string> Generate(string path)
        {
            var result = new List<string>();
            var dirs = Directory.GetDirectories(path);
            foreach (var dir in dirs)
                result.AddRange(Generate(dir));

            var headers = Directory.GetFiles(path).Where(t => t.EndsWith(".h"));
            result.AddRange(headers);

            return result;
        }

        public void SetupPasses(Driver driver)
        {

        }
    }
}
