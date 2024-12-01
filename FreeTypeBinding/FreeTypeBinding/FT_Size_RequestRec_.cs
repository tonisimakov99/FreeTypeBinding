using System.Runtime.InteropServices;

namespace FreeTypeBinding
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Size_RequestRec_
    {
        public FT_Size_Request_Type_ type;
        public CLong width;
        public CLong height;
        public uint horiResolution;
        public uint vertResolution;
    }
}