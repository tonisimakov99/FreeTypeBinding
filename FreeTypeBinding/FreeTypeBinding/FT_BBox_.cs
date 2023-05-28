namespace FreeTypeBinding
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_BBox_
    {
        public int xMin;
        public int yMin;
        public int xMax;
        public int yMax;
    }
}