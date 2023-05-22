namespace FreeTypeBinding
{
    public unsafe struct FT_ListNodeRec_
    {
        public FT_ListNode prev;
        public FT_ListNode next;
        public void* data;
    }
}