namespace FreeTypeBinding
{
    public unsafe struct FT_StreamRec_
    {
        public byte* base;
        public ulong size;
        public ulong pos;
        public FT_StreamDesc descriptor;
        public FT_StreamDesc pathname;
        public FT_Stream_IoFunc read;
        public FT_Stream_CloseFunc close;
        public FT_Memory memory;
        public byte* cursor;
        public byte* limit;
    }
}
}