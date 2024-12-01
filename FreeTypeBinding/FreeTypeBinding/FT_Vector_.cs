using System.Runtime.InteropServices;

namespace FreeTypeBinding
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Vector_
    {
        public CLong x;
        public CLong y;
    }
}