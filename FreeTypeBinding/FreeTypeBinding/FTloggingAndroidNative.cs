using System.Runtime.InteropServices;

namespace FreeTypeBinding
{
    internal static unsafe class FTloggingAndroidNative
    {
        [DllImport("libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Trace_Set_Level(byte* tracing_level);
        [DllImport("libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Trace_Set_Default_Level();
        [DllImport("libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Set_Log_Handler(delegate* unmanaged<byte*, byte*, byte*, void> * handler);
        [DllImport("libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Set_Default_Log_Handler();
    }
}