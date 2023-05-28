namespace FreeTypeBinding
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Vector_
    {
        public int x;
        public int y;
    }
}