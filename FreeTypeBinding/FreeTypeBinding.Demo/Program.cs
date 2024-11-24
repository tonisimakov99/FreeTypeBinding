using SkiaSharp;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace FreeTypeBinding.Demo
{
    internal class Program
    {
        unsafe static void Main(string[] args)
        {
            FT_LibraryRec_* pointer;
            FT_FaceRec_* face;

            var ft = new FT(Platform.Windows);

            var error = ft.FT_Init_FreeType(&pointer);

            error = ft.FT_New_Face(pointer, (byte*)Marshal.StringToHGlobalAnsi("impact2.ttf"), 0, &face);
            error = ft.FT_Set_Char_Size(face, 0, 16 * 64, 300, 300);
            var glyphIndex = ft.FT_Get_Char_Index(face, 'я');
            error = ft.FT_Load_Glyph(face, glyphIndex, FT_LOAD.FT_LOAD_DEFAULT);
            error = ft.FT_Render_Glyph(face->glyph, FT_Render_Mode_.FT_RENDER_MODE_NORMAL);
            var bitmap = face->glyph->bitmap;

            var skBitmap = new SKBitmap((int)bitmap.width, (int)bitmap.rows);
            var canvas = new SKCanvas(skBitmap);

            for (var i = 0; i != bitmap.width; i++)
            {
                for (var j = 0; j != bitmap.rows; j++)
                {
                    canvas.DrawPoint(new SKPoint(i, j), new SKColor(bitmap.buffer[j*bitmap.pitch+i], bitmap.buffer[j * bitmap.pitch + i], bitmap.buffer[j * bitmap.pitch + i], bitmap.buffer[j * bitmap.pitch + i]));
                }
            }

            using(var fileStream = File.OpenWrite("some.jpg"))
            {
                using (var wstream = new SKManagedWStream(fileStream))
                {
                    skBitmap.Encode(wstream, SKEncodedImageFormat.Png, 100);
                }
            }

        }
    }
}