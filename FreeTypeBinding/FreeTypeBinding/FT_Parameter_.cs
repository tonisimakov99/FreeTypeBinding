using System.Runtime.InteropServices;

namespace FreeTypeBinding
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Parameter_
    {
        public CULong tag;
        public void* data;
    }
}