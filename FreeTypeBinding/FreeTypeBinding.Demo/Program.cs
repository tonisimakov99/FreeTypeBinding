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
            var error = FT.FT_Init_FreeType(&pointer);

            error = FT.FT_New_Face(pointer, (byte*)Marshal.StringToHGlobalAnsi("impact2.ttf"), 0, &face);
            error = FT.FT_Set_Char_Size(face, 0, 16 * 64, 300, 300);
            var glyphIndex = FT.FT_Get_Char_Index(face, 'я');
            error = FT.FT_Load_Glyph(face, glyphIndex, FT_LOAD.FT_LOAD_DEFAULT);
            error = FT.FT_Render_Glyph(face->glyph, FT_Render_Mode_.FT_RENDER_MODE_NORMAL);
        }
    }
}