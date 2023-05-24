namespace FreeTypeBinding
{
    public unsafe struct FT_MemoryRec_
    {
        public void* user;
        public delegate*<> * alloc;
        public delegate*<> * free;
        public delegate*<> * realloc;
    }
}