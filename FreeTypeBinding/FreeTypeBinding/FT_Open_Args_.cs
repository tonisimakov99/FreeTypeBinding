namespace FreeTypeBinding
{
    public unsafe struct FT_Open_Args_
    {
        public uint flags;
        public byte* memory_base;
        public long memory_size;
        public byte* pathname;
        public FT_StreamRec_* stream;
        public FT_ModuleRec_* driver;
        public int num_params;
        public FT_Parameter_* params;
    }
}