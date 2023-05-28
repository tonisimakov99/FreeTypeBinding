namespace FreeTypeBinding
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Generic_
    {
        public void* data;
        public delegate* unmanaged<void*> * finalizer;
    }
}