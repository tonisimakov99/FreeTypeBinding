namespace FreeTypeBinding
{
    public unsafe struct FT_Size_RequestRec_
    {
        public FT_Size_Request_Type type;
        public FT_Long width;
        public FT_Long height;
        public FT_UInt horiResolution;
        public FT_UInt vertResolution;
    }
}