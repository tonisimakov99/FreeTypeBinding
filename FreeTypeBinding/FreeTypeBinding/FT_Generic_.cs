using System.Runtime.InteropServices;

namespace FreeTypeBinding
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Generic_
    {
        public void* data;
        public delegate* unmanaged<void*, void> * finalizer;
    }
}