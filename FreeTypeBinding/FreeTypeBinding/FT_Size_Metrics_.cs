namespace FreeTypeBinding
{
    public unsafe struct FT_Size_Metrics_
    {
        public ushort x_ppem;
        public ushort y_ppem;
        public long x_scale;
        public long y_scale;
        public long ascender;
        public long descender;
        public long height;
        public long max_advance;
    }
}