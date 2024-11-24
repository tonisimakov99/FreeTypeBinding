namespace FreeTypeBinding
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_StreamRec_
    {
        public byte* _base;
        public uint size;
        public uint pos;
        public FT_StreamDesc_ descriptor;
        public FT_StreamDesc_ pathname;
        public delegate* unmanaged<FT_StreamRec_*, uint, byte*, uint, uint> * read;
        public delegate* unmanaged<FT_StreamRec_*, void> * close;
        public FT_MemoryRec_* memory;
        public byte* cursor;
        public byte* limit;
    }
}