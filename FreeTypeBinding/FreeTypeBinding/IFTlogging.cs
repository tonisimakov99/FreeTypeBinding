using System.Runtime.InteropServices;

namespace FreeTypeBinding
{
    internal unsafe interface IFTlogging
    {
        void FT_Trace_Set_Level(byte* tracing_level);
        void FT_Trace_Set_Default_Level();
        void FT_Set_Log_Handler(delegate* unmanaged<byte*, byte*, byte*, void> * handler);
        void FT_Set_Default_Log_Handler();
        System.Int32 FT_LOAD_DEFAULT { get; }

        CLong FT_LOAD_NO_SCALE { get; }

        CLong FT_LOAD_NO_HINTING { get; }

        CLong FT_LOAD_RENDER { get; }

        CLong FT_LOAD_NO_BITMAP { get; }

        CLong FT_LOAD_VERTICAL_LAYOUT { get; }

        CLong FT_LOAD_FORCE_AUTOHINT { get; }

        CLong FT_LOAD_CROP_BITMAP { get; }

        CLong FT_LOAD_PEDANTIC { get; }

        CLong FT_LOAD_IGNORE_GLOBAL_ADVANCE_WIDTH { get; }

        CLong FT_LOAD_NO_RECURSE { get; }

        CLong FT_LOAD_IGNORE_TRANSFORM { get; }

        CLong FT_LOAD_MONOCHROME { get; }

        CLong FT_LOAD_LINEAR_DESIGN { get; }

        CLong FT_LOAD_SBITS_ONLY { get; }

        CLong FT_LOAD_NO_AUTOHINT { get; }

        CLong FT_LOAD_COLOR { get; }

        CLong FT_LOAD_COMPUTE_METRICS { get; }

        CLong FT_LOAD_BITMAP_METRICS_ONLY { get; }

        CLong FT_LOAD_NO_SVG { get; }

        CLong FT_LOAD_ADVANCE_ONLY { get; }

        CLong FT_LOAD_SVG_ONLY { get; }

        CLong FT_FACE_FLAG_SCALABLE { get; }

        CLong FT_FACE_FLAG_FIXED_SIZES { get; }

        CLong FT_FACE_FLAG_FIXED_WIDTH { get; }

        CLong FT_FACE_FLAG_SFNT { get; }

        CLong FT_FACE_FLAG_HORIZONTAL { get; }

        CLong FT_FACE_FLAG_VERTICAL { get; }

        CLong FT_FACE_FLAG_KERNING { get; }

        CLong FT_FACE_FLAG_FAST_GLYPHS { get; }

        CLong FT_FACE_FLAG_MULTIPLE_MASTERS { get; }

        CLong FT_FACE_FLAG_GLYPH_NAMES { get; }

        CLong FT_FACE_FLAG_EXTERNAL_STREAM { get; }

        CLong FT_FACE_FLAG_HINTER { get; }

        CLong FT_FACE_FLAG_CID_KEYED { get; }

        CLong FT_FACE_FLAG_TRICKY { get; }

        CLong FT_FACE_FLAG_COLOR { get; }

        CLong FT_FACE_FLAG_VARIATION { get; }

        CLong FT_FACE_FLAG_SVG { get; }

        CLong FT_FACE_FLAG_SBIX { get; }

        CLong FT_FACE_FLAG_SBIX_OVERLAY { get; }

        System.Int32 FT_STYLE_FLAG_ITALIC { get; }

        System.Int32 FT_STYLE_FLAG_BOLD { get; }
    }
}