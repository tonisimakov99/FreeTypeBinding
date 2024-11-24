using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FreeTypeBinding.Generator
{
    internal class Options
    {
        [Option('o', "outdir", Required = true, HelpText = "Output directory")]
        public required string OutDir { get; set; }

        [Option('f', "file", Required = true, HelpText = "Header file path")]
        public required string FilePath { get; set; }

        [Option('i', "include", Required = true, HelpText = "Include dir")]
        public required string IncludePath { get; set; }

        [Option('n', "namespace", Required = true, HelpText = "Out namespace")]
        public required string Namespace { get; set; }
    }
}
