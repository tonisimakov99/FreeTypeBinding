namespace FreeTypeBinding
{
    public unsafe struct FT_MemoryRec_
    {
        public void* user;
        public delegate* unmanaged<FT_MemoryRec_*, long> * alloc;
        public delegate* unmanaged<FT_MemoryRec_*, void*> * free;
        public delegate* unmanaged<FT_MemoryRec_*, long, long, void*> * realloc;
    }
}