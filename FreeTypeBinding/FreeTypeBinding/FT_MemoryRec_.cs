namespace FreeTypeBinding
{
    public unsafe struct FT_MemoryRec_
    {
        public void* user;
        public FT_Alloc_Func alloc;
        public FT_Free_Func free;
        public FT_Realloc_Func realloc;
    }
}