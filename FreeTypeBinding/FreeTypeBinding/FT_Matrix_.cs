using System.Runtime.InteropServices;

namespace FreeTypeBinding
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Matrix_
    {
        public CLong xx;
        public CLong xy;
        public CLong yx;
        public CLong yy;
    }
}