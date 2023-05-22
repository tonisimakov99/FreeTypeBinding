namespace FreeTypeBinding
{
    public unsafe struct FT_Open_Args_
    {
        public FT_UInt flags;
        public FT_Byte* memory_base;
        public FT_Long memory_size;
        public FT_String* pathname;
        public FT_Stream stream;
        public FT_Module driver;
        public FT_Int num_params;
        public FT_Parameter* params;
    }
}