namespace FreeTypeBinding
{
    public unsafe struct FT_Generic_
    {
        public void* data;
        public delegate* unmanaged<void*> * finalizer;
    }
}