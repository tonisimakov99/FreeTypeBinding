namespace FreeTypeBinding
{
    public unsafe struct FT_Size_RequestRec_
    {
        public FT_Size_Request_Type_ type;
        public long width;
        public long height;
        public uint horiResolution;
        public uint vertResolution;
    }
}