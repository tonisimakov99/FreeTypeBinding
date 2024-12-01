using System.Runtime.InteropServices;

namespace FreeTypeBinding
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_MemoryRec_
    {
        public void* user;
        public delegate* unmanaged<FT_MemoryRec_*, CLong, void*> * alloc;
        public delegate* unmanaged<FT_MemoryRec_*, void*, void> * free;
        public delegate* unmanaged<FT_MemoryRec_*, CLong, CLong, void*, void*> * realloc;
    }
}