namespace FreeTypeBinding
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Matrix_
    {
        public int xx;
        public int xy;
        public int yx;
        public int yy;
    }
}