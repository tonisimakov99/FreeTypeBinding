namespace FreeTypeBinding
{
    public unsafe struct FT_Size_Metrics_
    {
        public FT_UShort x_ppem;
        public FT_UShort y_ppem;
        public FT_Fixed x_scale;
        public FT_Fixed y_scale;
        public FT_Pos ascender;
        public FT_Pos descender;
        public FT_Pos height;
        public FT_Pos max_advance;
    }
}