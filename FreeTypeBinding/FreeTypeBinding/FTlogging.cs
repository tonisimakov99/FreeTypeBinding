using System.Runtime.InteropServices;

namespace FreeTypeBinding
{
    public unsafe class FTlogging
    {
        public FTlogging(Platform platform)
        {
            if (platform == Platform.Windows)
                lib = new FTloggingWindows();
            else if (platform == Platform.Linux)
                lib = new FTloggingLinux();
            else if (platform == Platform.Android)
                lib = new FTloggingAndroid();
            else
                throw new System.NotSupportedException("not supported");
        }

        IFTlogging lib;
        public void FT_Trace_Set_Level(byte* tracing_level)
        {
            lib.FT_Trace_Set_Level(tracing_level);
        }

        public void FT_Trace_Set_Default_Level()
        {
            lib.FT_Trace_Set_Default_Level();
        }

        public void FT_Set_Log_Handler(delegate* unmanaged<byte*, byte*, byte*, void> * handler)
        {
            lib.FT_Set_Log_Handler(handler);
        }

        public void FT_Set_Default_Log_Handler()
        {
            lib.FT_Set_Default_Log_Handler();
        }

        public System.Int32 FT_LOAD_DEFAULT => lib.FT_LOAD_DEFAULT;
        public CLong FT_LOAD_NO_SCALE => lib.FT_LOAD_NO_SCALE;
        public CLong FT_LOAD_NO_HINTING => lib.FT_LOAD_NO_HINTING;
        public CLong FT_LOAD_RENDER => lib.FT_LOAD_RENDER;
        public CLong FT_LOAD_NO_BITMAP => lib.FT_LOAD_NO_BITMAP;
        public CLong FT_LOAD_VERTICAL_LAYOUT => lib.FT_LOAD_VERTICAL_LAYOUT;
        public CLong FT_LOAD_FORCE_AUTOHINT => lib.FT_LOAD_FORCE_AUTOHINT;
        public CLong FT_LOAD_CROP_BITMAP => lib.FT_LOAD_CROP_BITMAP;
        public CLong FT_LOAD_PEDANTIC => lib.FT_LOAD_PEDANTIC;
        public CLong FT_LOAD_IGNORE_GLOBAL_ADVANCE_WIDTH => lib.FT_LOAD_IGNORE_GLOBAL_ADVANCE_WIDTH;
        public CLong FT_LOAD_NO_RECURSE => lib.FT_LOAD_NO_RECURSE;
        public CLong FT_LOAD_IGNORE_TRANSFORM => lib.FT_LOAD_IGNORE_TRANSFORM;
        public CLong FT_LOAD_MONOCHROME => lib.FT_LOAD_MONOCHROME;
        public CLong FT_LOAD_LINEAR_DESIGN => lib.FT_LOAD_LINEAR_DESIGN;
        public CLong FT_LOAD_SBITS_ONLY => lib.FT_LOAD_SBITS_ONLY;
        public CLong FT_LOAD_NO_AUTOHINT => lib.FT_LOAD_NO_AUTOHINT;
        public CLong FT_LOAD_COLOR => lib.FT_LOAD_COLOR;
        public CLong FT_LOAD_COMPUTE_METRICS => lib.FT_LOAD_COMPUTE_METRICS;
        public CLong FT_LOAD_BITMAP_METRICS_ONLY => lib.FT_LOAD_BITMAP_METRICS_ONLY;
        public CLong FT_LOAD_NO_SVG => lib.FT_LOAD_NO_SVG;
        public CLong FT_LOAD_ADVANCE_ONLY => lib.FT_LOAD_ADVANCE_ONLY;
        public CLong FT_LOAD_SVG_ONLY => lib.FT_LOAD_SVG_ONLY;
        public CLong FT_FACE_FLAG_SCALABLE => lib.FT_FACE_FLAG_SCALABLE;
        public CLong FT_FACE_FLAG_FIXED_SIZES => lib.FT_FACE_FLAG_FIXED_SIZES;
        public CLong FT_FACE_FLAG_FIXED_WIDTH => lib.FT_FACE_FLAG_FIXED_WIDTH;
        public CLong FT_FACE_FLAG_SFNT => lib.FT_FACE_FLAG_SFNT;
        public CLong FT_FACE_FLAG_HORIZONTAL => lib.FT_FACE_FLAG_HORIZONTAL;
        public CLong FT_FACE_FLAG_VERTICAL => lib.FT_FACE_FLAG_VERTICAL;
        public CLong FT_FACE_FLAG_KERNING => lib.FT_FACE_FLAG_KERNING;
        public CLong FT_FACE_FLAG_FAST_GLYPHS => lib.FT_FACE_FLAG_FAST_GLYPHS;
        public CLong FT_FACE_FLAG_MULTIPLE_MASTERS => lib.FT_FACE_FLAG_MULTIPLE_MASTERS;
        public CLong FT_FACE_FLAG_GLYPH_NAMES => lib.FT_FACE_FLAG_GLYPH_NAMES;
        public CLong FT_FACE_FLAG_EXTERNAL_STREAM => lib.FT_FACE_FLAG_EXTERNAL_STREAM;
        public CLong FT_FACE_FLAG_HINTER => lib.FT_FACE_FLAG_HINTER;
        public CLong FT_FACE_FLAG_CID_KEYED => lib.FT_FACE_FLAG_CID_KEYED;
        public CLong FT_FACE_FLAG_TRICKY => lib.FT_FACE_FLAG_TRICKY;
        public CLong FT_FACE_FLAG_COLOR => lib.FT_FACE_FLAG_COLOR;
        public CLong FT_FACE_FLAG_VARIATION => lib.FT_FACE_FLAG_VARIATION;
        public CLong FT_FACE_FLAG_SVG => lib.FT_FACE_FLAG_SVG;
        public CLong FT_FACE_FLAG_SBIX => lib.FT_FACE_FLAG_SBIX;
        public CLong FT_FACE_FLAG_SBIX_OVERLAY => lib.FT_FACE_FLAG_SBIX_OVERLAY;
        public System.Int32 FT_STYLE_FLAG_ITALIC => lib.FT_STYLE_FLAG_ITALIC;
        public System.Int32 FT_STYLE_FLAG_BOLD => lib.FT_STYLE_FLAG_BOLD;
    }
}