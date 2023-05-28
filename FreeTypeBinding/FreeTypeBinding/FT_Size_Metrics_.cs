namespace FreeTypeBinding
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Size_Metrics_
    {
        public ushort x_ppem;
        public ushort y_ppem;
        public int x_scale;
        public int y_scale;
        public int ascender;
        public int descender;
        public int height;
        public int max_advance;
    }
}