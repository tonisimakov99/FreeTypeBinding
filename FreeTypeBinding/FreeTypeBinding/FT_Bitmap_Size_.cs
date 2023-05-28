namespace FreeTypeBinding
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Bitmap_Size_
    {
        public short height;
        public short width;
        public int size;
        public int x_ppem;
        public int y_ppem;
    }
}