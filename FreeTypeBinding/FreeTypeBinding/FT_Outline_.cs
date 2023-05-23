namespace FreeTypeBinding
{
    public unsafe struct FT_Outline_
    {
        public short n_contours;
        public short n_points;
        public FT_Vector* points;
        public byte* tags;
        public short* contours;
        public int flags;
    }
}