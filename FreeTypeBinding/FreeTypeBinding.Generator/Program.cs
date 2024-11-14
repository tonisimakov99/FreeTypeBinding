using BindingGenerator;
using CommandLine;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Collections.Generic;

namespace FreeTypeBinding.Generator
{
    public class Program
    {
        private static Options options;
        public static int Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(o =>
                {
                    options = o;
                });

            Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Debug()
              .WriteTo.Console()
              .CreateLogger();

            var loggerFactory = LoggerFactory.Create((builder) => { builder.AddSerilog(Log.Logger); });


            BindingGenerator.Generator.Generate(
                new[] { options.IncludePath },
                options.FilePath,
                options.OutDir,
                "runtimes/win-x64/freetype.dll",
                "FreeTypeBinding",
                "FT",
                anonymousEnumName: "FT_Error",

               typedefStrategies: new Dictionary<string, TypedefStrategy>()
               {
                   { "FT_Error", TypedefStrategy.AsIs}
               },
               fieldParametersTypeOverrides: new Dictionary<string, string>()
               {
                   {"load_flags", "FT_LOAD" },
                   {"face_flags", "FT_FACE_FLAG" },
                   {"style_flags", "FT_STYLE_FLAG" },
                   {"pixel_mode", "FT_Pixel_Mode_" }
               },
               preprocessedEnumSearchParameters: new List<EnumSearchParameter>()
               {
                   new EnumSearchParameter(){Prefix="FT_LOAD", ExcludePrefix="FT_LOAD_TARGET" },
                   new EnumSearchParameter(){Prefix="FT_FACE_FLAG" },
                   new EnumSearchParameter(){Prefix="FT_STYLE_FLAG" }
               },
               logger: loggerFactory.CreateLogger<BindingGenerator.Generator>()
                );
            return 0;
        }
    }
}