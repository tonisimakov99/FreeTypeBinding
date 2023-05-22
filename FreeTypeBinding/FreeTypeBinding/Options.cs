﻿using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BoxEngine.FreeType.Generator
{
    internal class Options
    {
        [Option('o', "outdir", Required = true, HelpText = "Output directory")]
        public string OutDir { get; set; }

        [Option('f', "file", Required = true, HelpText = "Headers file path")]
        public string FilePath { get; set; }

        [Option('n', "namespace", Required = true, HelpText = "Out namespace")]
        public string Namespace { get; set; }
    }
}
