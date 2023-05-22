namespace FreeTypeBinding
{
    public unsafe struct FT_Raster_Params_
    {
        public FT_Bitmap* target;
        public void* source;
        public int flags;
        public FT_SpanFunc gray_spans;
        public FT_SpanFunc black_spans;
        public FT_Raster_BitTest_Func bit_test;
        public FT_Raster_BitSet_Func bit_set;
        public void* user;
        public FT_BBox clip_box;
    }
}