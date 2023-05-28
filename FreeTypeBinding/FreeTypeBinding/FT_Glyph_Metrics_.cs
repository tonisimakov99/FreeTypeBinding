namespace FreeTypeBinding
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Glyph_Metrics_
    {
        public int width;
        public int height;
        public int horiBearingX;
        public int horiBearingY;
        public int horiAdvance;
        public int vertBearingX;
        public int vertBearingY;
        public int vertAdvance;
    }
}