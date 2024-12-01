using System.Runtime.InteropServices;

namespace FreeTypeBinding
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_StreamDesc_
    {
        public CLong value;
        public void* pointer;
    }
}