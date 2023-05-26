namespace FreeTypeBinding
{
    public unsafe struct FT_ListNodeRec_
    {
        public FT_ListNodeRec_* prev;
        public FT_ListNodeRec_* next;
        public void* data;
    }
}