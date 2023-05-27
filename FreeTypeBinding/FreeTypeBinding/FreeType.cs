namespace FreeTypeBinding
{
    using System.Runtime.InteropServices;

    public unsafe static class FreeType
    {
        [DllImport("freetype.dll")]
        public static extern FT_Error FT_Init_FreeType(FT_LibraryRec_** alibrary);
        [DllImport("freetype.dll")]
        public static extern FT_Error FT_Done_FreeType(FT_LibraryRec_* library);
        [DllImport("freetype.dll")]
        public static extern FT_Error FT_New_Face(FT_LibraryRec_* library, byte* filepathname, long face_index, FT_FaceRec_** aface);
        [DllImport("freetype.dll")]
        public static extern FT_Error FT_New_Memory_Face(FT_LibraryRec_* library, byte* file_base, long file_size, long face_index, FT_FaceRec_** aface);
        [DllImport("freetype.dll")]
        public static extern FT_Error FT_Open_Face(FT_LibraryRec_* library, FT_Open_Args_* args, long face_index, FT_FaceRec_** aface);
        [DllImport("freetype.dll")]
        public static extern FT_Error FT_Attach_File(FT_FaceRec_* face, byte* filepathname);
        [DllImport("freetype.dll")]
        public static extern FT_Error FT_Attach_Stream(FT_FaceRec_* face, FT_Open_Args_* parameters);
        [DllImport("freetype.dll")]
        public static extern FT_Error FT_Reference_Face(FT_FaceRec_* face);
        [DllImport("freetype.dll")]
        public static extern FT_Error FT_Done_Face(FT_FaceRec_* face);
        [DllImport("freetype.dll")]
        public static extern FT_Error FT_Select_Size(FT_FaceRec_* face, int strike_index);
        [DllImport("freetype.dll")]
        public static extern FT_Error FT_Request_Size(FT_FaceRec_* face, FT_Size_RequestRec_* req);
        [DllImport("freetype.dll")]
        public static extern FT_Error FT_Set_Char_Size(FT_FaceRec_* face, long char_width, long char_height, uint horz_resolution, uint vert_resolution);
        [DllImport("freetype.dll")]
        public static extern FT_Error FT_Set_Pixel_Sizes(FT_FaceRec_* face, uint pixel_width, uint pixel_height);
        [DllImport("freetype.dll")]
        public static extern FT_Error FT_Load_Glyph(FT_FaceRec_* face, uint glyph_index, int load_flags);
        [DllImport("freetype.dll")]
        public static extern FT_Error FT_Load_Char(FT_FaceRec_* face, ulong char_code, int load_flags);
        [DllImport("freetype.dll")]
        public static extern void FT_Set_Transform(FT_FaceRec_* face, FT_Matrix_* matrix, FT_Vector_* delta);
        [DllImport("freetype.dll")]
        public static extern void FT_Get_Transform(FT_FaceRec_* face, FT_Matrix_* matrix, FT_Vector_* delta);
        [DllImport("freetype.dll")]
        public static extern FT_Error FT_Render_Glyph(FT_GlyphSlotRec_* slot, FT_Render_Mode_ render_mode);
        [DllImport("freetype.dll")]
        public static extern FT_Error FT_Get_Kerning(FT_FaceRec_* face, uint left_glyph, uint right_glyph, uint kern_mode, FT_Vector_* akerning);
        [DllImport("freetype.dll")]
        public static extern FT_Error FT_Get_Track_Kerning(FT_FaceRec_* face, long point_size, int degree, long* akerning);
        [DllImport("freetype.dll")]
        public static extern FT_Error FT_Select_Charmap(FT_FaceRec_* face, FT_Encoding_ encoding);
        [DllImport("freetype.dll")]
        public static extern FT_Error FT_Set_Charmap(FT_FaceRec_* face, FT_CharMapRec_* charmap);
        [DllImport("freetype.dll")]
        public static extern int FT_Get_Charmap_Index(FT_CharMapRec_* charmap);
        [DllImport("freetype.dll")]
        public static extern uint FT_Get_Char_Index(FT_FaceRec_* face, ulong charcode);
        [DllImport("freetype.dll")]
        public static extern ulong FT_Get_First_Char(FT_FaceRec_* face, uint* agindex);
        [DllImport("freetype.dll")]
        public static extern ulong FT_Get_Next_Char(FT_FaceRec_* face, ulong char_code, uint* agindex);
        [DllImport("freetype.dll")]
        public static extern FT_Error FT_Face_Properties(FT_FaceRec_* face, uint num_properties, FT_Parameter_* properties);
        [DllImport("freetype.dll")]
        public static extern uint FT_Get_Name_Index(FT_FaceRec_* face, byte* glyph_name);
        [DllImport("freetype.dll")]
        public static extern FT_Error FT_Get_Glyph_Name(FT_FaceRec_* face, uint glyph_index, void* buffer, uint buffer_max);
        [DllImport("freetype.dll")]
        public static extern byte* FT_Get_Postscript_Name(FT_FaceRec_* face);
        [DllImport("freetype.dll")]
        public static extern FT_Error FT_Get_SubGlyph_Info(FT_GlyphSlotRec_* glyph, uint sub_index, int* p_index, uint* p_flags, int* p_arg1, int* p_arg2, FT_Matrix_* p_transform);
        [DllImport("freetype.dll")]
        public static extern ushort FT_Get_FSType_Flags(FT_FaceRec_* face);
        [DllImport("freetype.dll")]
        public static extern uint FT_Face_GetCharVariantIndex(FT_FaceRec_* face, ulong charcode, ulong variantSelector);
        [DllImport("freetype.dll")]
        public static extern int FT_Face_GetCharVariantIsDefault(FT_FaceRec_* face, ulong charcode, ulong variantSelector);
        [DllImport("freetype.dll")]
        public static extern uint* FT_Face_GetVariantSelectors(FT_FaceRec_* face);
        [DllImport("freetype.dll")]
        public static extern uint* FT_Face_GetVariantsOfChar(FT_FaceRec_* face, ulong charcode);
        [DllImport("freetype.dll")]
        public static extern uint* FT_Face_GetCharsOfVariant(FT_FaceRec_* face, ulong variantSelector);
        [DllImport("freetype.dll")]
        public static extern long FT_MulDiv(long a, long b, long c);
        [DllImport("freetype.dll")]
        public static extern long FT_MulFix(long a, long b);
        [DllImport("freetype.dll")]
        public static extern long FT_DivFix(long a, long b);
        [DllImport("freetype.dll")]
        public static extern long FT_RoundFix(long a);
        [DllImport("freetype.dll")]
        public static extern long FT_CeilFix(long a);
        [DllImport("freetype.dll")]
        public static extern long FT_FloorFix(long a);
        [DllImport("freetype.dll")]
        public static extern void FT_Vector_Transform(FT_Vector_* vector, FT_Matrix_* matrix);
        [DllImport("freetype.dll")]
        public static extern void FT_Library_Version(FT_LibraryRec_* library, int* amajor, int* aminor, int* apatch);
        [DllImport("freetype.dll")]
        public static extern byte FT_Face_CheckTrueTypePatents(FT_FaceRec_* face);
        [DllImport("freetype.dll")]
        public static extern byte FT_Face_SetUnpatentedHinting(FT_FaceRec_* face, byte value);
        [DllImport("freetype.dll")]
        public static extern byte* FT_Error_String(FT_Error error_code);
    }
}