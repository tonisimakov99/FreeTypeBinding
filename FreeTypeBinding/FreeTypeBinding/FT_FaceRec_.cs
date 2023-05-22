namespace FreeTypeBinding
{
    public unsafe struct FT_FaceRec_
    {
        public FT_Long num_faces;
        public FT_Long face_index;
        public FT_Long face_flags;
        public FT_Long style_flags;
        public FT_Long num_glyphs;
        public FT_String* family_name;
        public FT_String* style_name;
        public FT_Int num_fixed_sizes;
        public FT_Bitmap_Size* available_sizes;
        public FT_Int num_charmaps;
        public FT_CharMap* charmaps;
        public FT_Generic generic;
        public FT_BBox bbox;
        public FT_UShort units_per_EM;
        public FT_Short ascender;
        public FT_Short descender;
        public FT_Short height;
        public FT_Short max_advance_width;
        public FT_Short max_advance_height;
        public FT_Short underline_position;
        public FT_Short underline_thickness;
        public FT_GlyphSlot glyph;
        public FT_Size size;
        public FT_CharMap charmap;
        public FT_Driver driver;
        public FT_Memory memory;
        public FT_Stream stream;
        public FT_ListRec sizes_list;
        public FT_Generic autohint;
        public void* extensions;
        public FT_Face_Internal internal;
    }
}