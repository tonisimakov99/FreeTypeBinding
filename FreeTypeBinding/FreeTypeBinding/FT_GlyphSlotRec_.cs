namespace FreeTypeBinding
{
    public unsafe struct FT_GlyphSlotRec_
    {
        public FT_Library library;
        public FT_Face face;
        public FT_GlyphSlot next;
        public FT_UInt glyph_index;
        public FT_Generic generic;
        public FT_Glyph_Metrics metrics;
        public FT_Fixed linearHoriAdvance;
        public FT_Fixed linearVertAdvance;
        public FT_Vector advance;
        public FT_Glyph_Format format;
        public FT_Bitmap bitmap;
        public FT_Int bitmap_left;
        public FT_Int bitmap_top;
        public FT_Outline outline;
        public FT_UInt num_subglyphs;
        public FT_SubGlyph subglyphs;
        public void* control_data;
        public long control_len;
        public FT_Pos lsb_delta;
        public FT_Pos rsb_delta;
        public void* other;
        public FT_Slot_Internal internal;
    }
}