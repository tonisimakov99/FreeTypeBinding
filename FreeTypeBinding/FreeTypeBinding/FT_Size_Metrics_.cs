using System.Runtime.InteropServices;

namespace FreeTypeBinding
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Size_Metrics_
    {
        public ushort x_ppem;
        public ushort y_ppem;
        public CLong x_scale;
        public CLong y_scale;
        public CLong ascender;
        public CLong descender;
        public CLong height;
        public CLong max_advance;
    }
}