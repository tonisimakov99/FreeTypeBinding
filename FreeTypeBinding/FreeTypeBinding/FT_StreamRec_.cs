namespace FreeTypeBinding
{
    public unsafe struct FT_StreamRec_
    {
        public byte* _base;
        public ulong size;
        public ulong pos;
        public FT_StreamDesc_ descriptor;
        public FT_StreamDesc_ pathname;
        public delegate*<> * read;
        public delegate*<> * close;
        public FT_MemoryRec_* memory;
        public byte* cursor;
        public byte* limit;
    }
}