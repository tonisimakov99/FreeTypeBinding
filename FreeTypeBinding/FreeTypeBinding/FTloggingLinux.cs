using System.Runtime.InteropServices;

namespace FreeTypeBinding
{
    internal unsafe class FTloggingLinux : IFTlogging
    {
        public void FT_Trace_Set_Level(byte* tracing_level)
        {
            FTloggingLinuxNative.FT_Trace_Set_Level(tracing_level);
        }

        public void FT_Trace_Set_Default_Level()
        {
            FTloggingLinuxNative.FT_Trace_Set_Default_Level();
        }

        public void FT_Set_Log_Handler(delegate* unmanaged<byte*, byte*, byte*, void> * handler)
        {
            FTloggingLinuxNative.FT_Set_Log_Handler(handler);
        }

        public void FT_Set_Default_Log_Handler()
        {
            FTloggingLinuxNative.FT_Set_Default_Log_Handler();
        }

        public System.Int32 FT_LOAD_DEFAULT => 0;
        public CLong FT_LOAD_NO_SCALE => new CLong(1);
        public CLong FT_LOAD_NO_HINTING => new CLong(2);
        public CLong FT_LOAD_RENDER => new CLong(4);
        public CLong FT_LOAD_NO_BITMAP => new CLong(8);
        public CLong FT_LOAD_VERTICAL_LAYOUT => new CLong(16);
        public CLong FT_LOAD_FORCE_AUTOHINT => new CLong(32);
        public CLong FT_LOAD_CROP_BITMAP => new CLong(64);
        public CLong FT_LOAD_PEDANTIC => new CLong(128);
        public CLong FT_LOAD_IGNORE_GLOBAL_ADVANCE_WIDTH => new CLong(512);
        public CLong FT_LOAD_NO_RECURSE => new CLong(1024);
        public CLong FT_LOAD_IGNORE_TRANSFORM => new CLong(2048);
        public CLong FT_LOAD_MONOCHROME => new CLong(4096);
        public CLong FT_LOAD_LINEAR_DESIGN => new CLong(8192);
        public CLong FT_LOAD_SBITS_ONLY => new CLong(16384);
        public CLong FT_LOAD_NO_AUTOHINT => new CLong(32768);
        public CLong FT_LOAD_COLOR => new CLong(1048576);
        public CLong FT_LOAD_COMPUTE_METRICS => new CLong(2097152);
        public CLong FT_LOAD_BITMAP_METRICS_ONLY => new CLong(4194304);
        public CLong FT_LOAD_NO_SVG => new CLong(16777216);
        public CLong FT_LOAD_ADVANCE_ONLY => new CLong(256);
        public CLong FT_LOAD_SVG_ONLY => new CLong(8388608);
        public CLong FT_FACE_FLAG_SCALABLE => new CLong(1);
        public CLong FT_FACE_FLAG_FIXED_SIZES => new CLong(2);
        public CLong FT_FACE_FLAG_FIXED_WIDTH => new CLong(4);
        public CLong FT_FACE_FLAG_SFNT => new CLong(8);
        public CLong FT_FACE_FLAG_HORIZONTAL => new CLong(16);
        public CLong FT_FACE_FLAG_VERTICAL => new CLong(32);
        public CLong FT_FACE_FLAG_KERNING => new CLong(64);
        public CLong FT_FACE_FLAG_FAST_GLYPHS => new CLong(128);
        public CLong FT_FACE_FLAG_MULTIPLE_MASTERS => new CLong(256);
        public CLong FT_FACE_FLAG_GLYPH_NAMES => new CLong(512);
        public CLong FT_FACE_FLAG_EXTERNAL_STREAM => new CLong(1024);
        public CLong FT_FACE_FLAG_HINTER => new CLong(2048);
        public CLong FT_FACE_FLAG_CID_KEYED => new CLong(4096);
        public CLong FT_FACE_FLAG_TRICKY => new CLong(8192);
        public CLong FT_FACE_FLAG_COLOR => new CLong(16384);
        public CLong FT_FACE_FLAG_VARIATION => new CLong(32768);
        public CLong FT_FACE_FLAG_SVG => new CLong(65536);
        public CLong FT_FACE_FLAG_SBIX => new CLong(131072);
        public CLong FT_FACE_FLAG_SBIX_OVERLAY => new CLong(262144);
        public System.Int32 FT_STYLE_FLAG_ITALIC => 1;
        public System.Int32 FT_STYLE_FLAG_BOLD => 2;
    }
}