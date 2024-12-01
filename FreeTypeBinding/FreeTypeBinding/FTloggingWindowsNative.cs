using System.Runtime.InteropServices;

namespace FreeTypeBinding
{
    internal static unsafe class FTloggingWindowsNative
    {
        [DllImport("runtimes/win-x64/native/freetype.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Trace_Set_Level(byte* tracing_level);
        [DllImport("runtimes/win-x64/native/freetype.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Trace_Set_Default_Level();
        [DllImport("runtimes/win-x64/native/freetype.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Set_Log_Handler(delegate* unmanaged<byte*, byte*, byte*, void> * handler);
        [DllImport("runtimes/win-x64/native/freetype.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Set_Default_Log_Handler();
    }
}