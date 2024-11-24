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
                new[] {
                    new LibData() {
                    FuncsHeaderPath = options.FilePath,
                    RuntimeData = new RuntimeData()
                    {
                        PerPlatformPathes = new Dictionary<Platform, string>()
                        {
                            { Platform.Windows, "runtimes/win-x64/freetype.dll" },
                            { Platform.Linux, "runtimes/linux-x64/libfreetype.so" },
                            { Platform.Android, "libfreetype.so" },
                        }
                    },
                    LibName="FT"
                    } },
                options.OutDir,
                "FreeTypeBinding",
                anonymousEnumPrefixes: new List<string>() { "FT_Err" },
               typedefStrategies: new Dictionary<string, TypedefStrategy>()
               {
                   { "FT_Error", TypedefStrategy.AsIs}
               },
               notFoundTypesOverrides: new Dictionary<string, string>()
               {
                   { "FT_Error", "FT_Err"}
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