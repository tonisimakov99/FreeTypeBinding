using System.Runtime.InteropServices;

namespace FreeTypeBinding
{
    internal static unsafe class FTLinuxNative
    {
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Err FT_Init_FreeType(FT_LibraryRec_** alibrary);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Err FT_Done_FreeType(FT_LibraryRec_* library);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Err FT_New_Face(FT_LibraryRec_* library, byte* filepathname, int face_index, FT_FaceRec_** aface);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Err FT_New_Memory_Face(FT_LibraryRec_* library, byte* file_base, int file_size, int face_index, FT_FaceRec_** aface);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Err FT_Open_Face(FT_LibraryRec_* library, FT_Open_Args_* args, int face_index, FT_FaceRec_** aface);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Err FT_Attach_File(FT_FaceRec_* face, byte* filepathname);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Err FT_Attach_Stream(FT_FaceRec_* face, FT_Open_Args_* parameters);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Err FT_Reference_Face(FT_FaceRec_* face);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Err FT_Done_Face(FT_FaceRec_* face);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Err FT_Select_Size(FT_FaceRec_* face, int strike_index);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Err FT_Request_Size(FT_FaceRec_* face, FT_Size_RequestRec_* req);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Err FT_Set_Char_Size(FT_FaceRec_* face, int char_width, int char_height, uint horz_resolution, uint vert_resolution);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Err FT_Set_Pixel_Sizes(FT_FaceRec_* face, uint pixel_width, uint pixel_height);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Err FT_Load_Glyph(FT_FaceRec_* face, uint glyph_index, FT_LOAD load_flags);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Err FT_Load_Char(FT_FaceRec_* face, uint char_code, FT_LOAD load_flags);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Set_Transform(FT_FaceRec_* face, FT_Matrix_* matrix, FT_Vector_* delta);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Get_Transform(FT_FaceRec_* face, FT_Matrix_* matrix, FT_Vector_* delta);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Err FT_Render_Glyph(FT_GlyphSlotRec_* slot, FT_Render_Mode_ render_mode);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Err FT_Get_Kerning(FT_FaceRec_* face, uint left_glyph, uint right_glyph, uint kern_mode, FT_Vector_* akerning);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Err FT_Get_Track_Kerning(FT_FaceRec_* face, int point_size, int degree, int* akerning);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Err FT_Select_Charmap(FT_FaceRec_* face, FT_Encoding_ encoding);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Err FT_Set_Charmap(FT_FaceRec_* face, FT_CharMapRec_* charmap);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FT_Get_Charmap_Index(FT_CharMapRec_* charmap);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint FT_Get_Char_Index(FT_FaceRec_* face, uint charcode);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint FT_Get_First_Char(FT_FaceRec_* face, uint* agindex);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint FT_Get_Next_Char(FT_FaceRec_* face, uint char_code, uint* agindex);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Err FT_Face_Properties(FT_FaceRec_* face, uint num_properties, FT_Parameter_* properties);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint FT_Get_Name_Index(FT_FaceRec_* face, byte* glyph_name);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Err FT_Get_Glyph_Name(FT_FaceRec_* face, uint glyph_index, void* buffer, uint buffer_max);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* FT_Get_Postscript_Name(FT_FaceRec_* face);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Err FT_Get_SubGlyph_Info(FT_GlyphSlotRec_* glyph, uint sub_index, int* p_index, uint* p_flags, int* p_arg1, int* p_arg2, FT_Matrix_* p_transform);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort FT_Get_FSType_Flags(FT_FaceRec_* face);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint FT_Face_GetCharVariantIndex(FT_FaceRec_* face, uint charcode, uint variantSelector);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FT_Face_GetCharVariantIsDefault(FT_FaceRec_* face, uint charcode, uint variantSelector);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint* FT_Face_GetVariantSelectors(FT_FaceRec_* face);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint* FT_Face_GetVariantsOfChar(FT_FaceRec_* face, uint charcode);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint* FT_Face_GetCharsOfVariant(FT_FaceRec_* face, uint variantSelector);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FT_MulDiv(int a, int b, int c);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FT_MulFix(int a, int b);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FT_DivFix(int a, int b);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FT_RoundFix(int a);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FT_CeilFix(int a);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FT_FloorFix(int a);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Vector_Transform(FT_Vector_* vector, FT_Matrix_* matrix);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Library_Version(FT_LibraryRec_* library, int* amajor, int* aminor, int* apatch);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte FT_Face_CheckTrueTypePatents(FT_FaceRec_* face);
        [DllImport("runtimes/linux-x64/libfreetype.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte FT_Face_SetUnpatentedHinting(FT_FaceRec_* face, byte value);
    }
}