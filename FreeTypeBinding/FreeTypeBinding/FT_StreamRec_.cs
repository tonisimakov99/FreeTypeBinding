using System.Runtime.InteropServices;

namespace FreeTypeBinding
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_StreamRec_
    {
        public byte* _base;
        public CULong size;
        public CULong pos;
        public FT_StreamDesc_ descriptor;
        public FT_StreamDesc_ pathname;
        public delegate* unmanaged<FT_StreamRec_*, CULong, byte*, CULong, CULong> * read;
        public delegate* unmanaged<FT_StreamRec_*, void> * close;
        public FT_MemoryRec_* memory;
        public byte* cursor;
        public byte* limit;
    }
}