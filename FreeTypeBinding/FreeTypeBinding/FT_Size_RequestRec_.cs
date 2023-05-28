namespace FreeTypeBinding
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Size_RequestRec_
    {
        public FT_Size_Request_Type_ type;
        public int width;
        public int height;
        public uint horiResolution;
        public uint vertResolution;
    }
}