using System.Runtime.InteropServices;

namespace FreeTypeBinding
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_BBox_
    {
        public CLong xMin;
        public CLong yMin;
        public CLong xMax;
        public CLong yMax;
    }
}