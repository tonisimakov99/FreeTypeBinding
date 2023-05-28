namespace FreeTypeBinding
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_SizeRec_
    {
        public FT_FaceRec_* face;
        public FT_Generic_ generic;
        public FT_Size_Metrics_ metrics;
        public FT_Size_InternalRec_* _internal;
    }
}