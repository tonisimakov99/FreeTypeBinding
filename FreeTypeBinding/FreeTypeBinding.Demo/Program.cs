using System;
using System.Runtime.InteropServices;

namespace FreeTypeBinding.Demo
{
    internal class Program
    {
        unsafe static void Main(string[] args)
        {
            FT_LibraryRec_* pointer;
            FT_FaceRec_* face;
            var error = FreeType.FT_Init_FreeType(&pointer);

            error = FreeType.FT_New_Face(pointer, (byte*)Marshal.StringToHGlobalAnsi("VeganStylePersonalUse-5Y58.ttf"), 0, &face);

        }
    }
}