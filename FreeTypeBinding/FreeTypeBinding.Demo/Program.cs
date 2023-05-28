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
            var error = FT.Init_FreeType(&pointer);

            error = FT.New_Face(pointer, (byte*)Marshal.StringToHGlobalAnsi("impact2.ttf"), 0, &face);
            error = FT.Set_Char_Size(face, 0, 16 * 64, 300, 300);
            var glyphIndex = FT.Get_Char_Index(face, 'я');
            error = FT.Load_Glyph(face, glyphIndex, FT_LOAD.FT_LOAD_DEFAULT);
        }
    }
}