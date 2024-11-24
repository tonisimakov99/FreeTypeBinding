namespace FreeTypeBinding
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_MemoryRec_
    {
        public void* user;
        public delegate* unmanaged<FT_MemoryRec_*, int, void*> * alloc;
        public delegate* unmanaged<FT_MemoryRec_*, void*, void> * free;
        public delegate* unmanaged<FT_MemoryRec_*, int, int, void*, void*> * realloc;
    }
}