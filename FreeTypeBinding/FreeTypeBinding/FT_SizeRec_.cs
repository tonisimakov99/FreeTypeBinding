namespace FreeTypeBinding
{
    public unsafe struct FT_SizeRec_
    {
        public FT_Face face;
        public FT_Generic generic;
        public FT_Size_Metrics metrics;
        public FT_Size_Internal internal;
    }
}