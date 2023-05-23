namespace FreeTypeBinding
{
    public unsafe struct FT_Outline_Funcs_
    {
        public FT_Outline_MoveToFunc move_to;
        public FT_Outline_LineToFunc line_to;
        public FT_Outline_ConicToFunc conic_to;
        public FT_Outline_CubicToFunc cubic_to;
        public int shift;
        public long delta;
    }
}