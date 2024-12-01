using System.Runtime.InteropServices;

namespace FreeTypeBinding
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_GlyphSlotRec_
    {
        public FT_LibraryRec_* library;
        public FT_FaceRec_* face;
        public FT_GlyphSlotRec_* next;
        public uint glyph_index;
        public FT_Generic_ generic;
        public FT_Glyph_Metrics_ metrics;
        public CLong linearHoriAdvance;
        public CLong linearVertAdvance;
        public FT_Vector_ advance;
        public FT_Glyph_Format_ format;
        public FT_Bitmap_ bitmap;
        public int bitmap_left;
        public int bitmap_top;
        public FT_Outline_ outline;
        public uint num_subglyphs;
        public FT_SubGlyphRec_* subglyphs;
        public void* control_data;
        public CLong control_len;
        public CLong lsb_delta;
        public CLong rsb_delta;
        public void* other;
        public FT_Slot_InternalRec_* _internal;
    }
}