namespace FreeTypeBinding
{
    public unsafe struct FT_CharMapRec_
    {
        public FT_Face face;
        public FT_Encoding encoding;
        public FT_UShort platform_id;
        public FT_UShort encoding_id;
    }
}