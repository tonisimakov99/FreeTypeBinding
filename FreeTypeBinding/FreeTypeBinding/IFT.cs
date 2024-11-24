namespace FreeTypeBinding
{
    internal unsafe interface IFT
    {
        FT_Err FT_Init_FreeType(FT_LibraryRec_** alibrary);
        FT_Err FT_Done_FreeType(FT_LibraryRec_* library);
        FT_Err FT_New_Face(FT_LibraryRec_* library, byte* filepathname, int face_index, FT_FaceRec_** aface);
        FT_Err FT_New_Memory_Face(FT_LibraryRec_* library, byte* file_base, int file_size, int face_index, FT_FaceRec_** aface);
        FT_Err FT_Open_Face(FT_LibraryRec_* library, FT_Open_Args_* args, int face_index, FT_FaceRec_** aface);
        FT_Err FT_Attach_File(FT_FaceRec_* face, byte* filepathname);
        FT_Err FT_Attach_Stream(FT_FaceRec_* face, FT_Open_Args_* parameters);
        FT_Err FT_Reference_Face(FT_FaceRec_* face);
        FT_Err FT_Done_Face(FT_FaceRec_* face);
        FT_Err FT_Select_Size(FT_FaceRec_* face, int strike_index);
        FT_Err FT_Request_Size(FT_FaceRec_* face, FT_Size_RequestRec_* req);
        FT_Err FT_Set_Char_Size(FT_FaceRec_* face, int char_width, int char_height, uint horz_resolution, uint vert_resolution);
        FT_Err FT_Set_Pixel_Sizes(FT_FaceRec_* face, uint pixel_width, uint pixel_height);
        FT_Err FT_Load_Glyph(FT_FaceRec_* face, uint glyph_index, FT_LOAD load_flags);
        FT_Err FT_Load_Char(FT_FaceRec_* face, uint char_code, FT_LOAD load_flags);
        void FT_Set_Transform(FT_FaceRec_* face, FT_Matrix_* matrix, FT_Vector_* delta);
        void FT_Get_Transform(FT_FaceRec_* face, FT_Matrix_* matrix, FT_Vector_* delta);
        FT_Err FT_Render_Glyph(FT_GlyphSlotRec_* slot, FT_Render_Mode_ render_mode);
        FT_Err FT_Get_Kerning(FT_FaceRec_* face, uint left_glyph, uint right_glyph, uint kern_mode, FT_Vector_* akerning);
        FT_Err FT_Get_Track_Kerning(FT_FaceRec_* face, int point_size, int degree, int* akerning);
        FT_Err FT_Select_Charmap(FT_FaceRec_* face, FT_Encoding_ encoding);
        FT_Err FT_Set_Charmap(FT_FaceRec_* face, FT_CharMapRec_* charmap);
        int FT_Get_Charmap_Index(FT_CharMapRec_* charmap);
        uint FT_Get_Char_Index(FT_FaceRec_* face, uint charcode);
        uint FT_Get_First_Char(FT_FaceRec_* face, uint* agindex);
        uint FT_Get_Next_Char(FT_FaceRec_* face, uint char_code, uint* agindex);
        FT_Err FT_Face_Properties(FT_FaceRec_* face, uint num_properties, FT_Parameter_* properties);
        uint FT_Get_Name_Index(FT_FaceRec_* face, byte* glyph_name);
        FT_Err FT_Get_Glyph_Name(FT_FaceRec_* face, uint glyph_index, void* buffer, uint buffer_max);
        byte* FT_Get_Postscript_Name(FT_FaceRec_* face);
        FT_Err FT_Get_SubGlyph_Info(FT_GlyphSlotRec_* glyph, uint sub_index, int* p_index, uint* p_flags, int* p_arg1, int* p_arg2, FT_Matrix_* p_transform);
        ushort FT_Get_FSType_Flags(FT_FaceRec_* face);
        uint FT_Face_GetCharVariantIndex(FT_FaceRec_* face, uint charcode, uint variantSelector);
        int FT_Face_GetCharVariantIsDefault(FT_FaceRec_* face, uint charcode, uint variantSelector);
        uint* FT_Face_GetVariantSelectors(FT_FaceRec_* face);
        uint* FT_Face_GetVariantsOfChar(FT_FaceRec_* face, uint charcode);
        uint* FT_Face_GetCharsOfVariant(FT_FaceRec_* face, uint variantSelector);
        int FT_MulDiv(int a, int b, int c);
        int FT_MulFix(int a, int b);
        int FT_DivFix(int a, int b);
        int FT_RoundFix(int a);
        int FT_CeilFix(int a);
        int FT_FloorFix(int a);
        void FT_Vector_Transform(FT_Vector_* vector, FT_Matrix_* matrix);
        void FT_Library_Version(FT_LibraryRec_* library, int* amajor, int* aminor, int* apatch);
        byte FT_Face_CheckTrueTypePatents(FT_FaceRec_* face);
        byte FT_Face_SetUnpatentedHinting(FT_FaceRec_* face, byte value);
    }
}