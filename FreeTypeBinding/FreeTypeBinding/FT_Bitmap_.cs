namespace FreeTypeBinding
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Bitmap_
    {
        public uint rows;
        public uint width;
        public int pitch;
        public byte* buffer;
        public ushort num_grays;
        public byte pixel_mode;
        public byte palette_mode;
        public void* palette;
    }
}