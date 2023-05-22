namespace FreeTypeBinding
{
    public unsafe struct FT_Generic_
    {
        public void* data;
        public FT_Generic_Finalizer finalizer;
    }
}