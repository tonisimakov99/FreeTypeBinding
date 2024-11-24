namespace FreeTypeBinding
{
    internal unsafe class FTAndroid : IFT
    {
        public FT_Err FT_Init_FreeType(FT_LibraryRec_** alibrary)
        {
            return FTAndroidNative.FT_Init_FreeType(alibrary);
        }

        public FT_Err FT_Done_FreeType(FT_LibraryRec_* library)
        {
            return FTAndroidNative.FT_Done_FreeType(library);
        }

        public FT_Err FT_New_Face(FT_LibraryRec_* library, byte* filepathname, int face_index, FT_FaceRec_** aface)
        {
            return FTAndroidNative.FT_New_Face(library, filepathname, face_index, aface);
        }

        public FT_Err FT_New_Memory_Face(FT_LibraryRec_* library, byte* file_base, int file_size, int face_index, FT_FaceRec_** aface)
        {
            return FTAndroidNative.FT_New_Memory_Face(library, file_base, file_size, face_index, aface);
        }

        public FT_Err FT_Open_Face(FT_LibraryRec_* library, FT_Open_Args_* args, int face_index, FT_FaceRec_** aface)
        {
            return FTAndroidNative.FT_Open_Face(library, args, face_index, aface);
        }

        public FT_Err FT_Attach_File(FT_FaceRec_* face, byte* filepathname)
        {
            return FTAndroidNative.FT_Attach_File(face, filepathname);
        }

        public FT_Err FT_Attach_Stream(FT_FaceRec_* face, FT_Open_Args_* parameters)
        {
            return FTAndroidNative.FT_Attach_Stream(face, parameters);
        }

        public FT_Err FT_Reference_Face(FT_FaceRec_* face)
        {
            return FTAndroidNative.FT_Reference_Face(face);
        }

        public FT_Err FT_Done_Face(FT_FaceRec_* face)
        {
            return FTAndroidNative.FT_Done_Face(face);
        }

        public FT_Err FT_Select_Size(FT_FaceRec_* face, int strike_index)
        {
            return FTAndroidNative.FT_Select_Size(face, strike_index);
        }

        public FT_Err FT_Request_Size(FT_FaceRec_* face, FT_Size_RequestRec_* req)
        {
            return FTAndroidNative.FT_Request_Size(face, req);
        }

        public FT_Err FT_Set_Char_Size(FT_FaceRec_* face, int char_width, int char_height, uint horz_resolution, uint vert_resolution)
        {
            return FTAndroidNative.FT_Set_Char_Size(face, char_width, char_height, horz_resolution, vert_resolution);
        }

        public FT_Err FT_Set_Pixel_Sizes(FT_FaceRec_* face, uint pixel_width, uint pixel_height)
        {
            return FTAndroidNative.FT_Set_Pixel_Sizes(face, pixel_width, pixel_height);
        }

        public FT_Err FT_Load_Glyph(FT_FaceRec_* face, uint glyph_index, FT_LOAD load_flags)
        {
            return FTAndroidNative.FT_Load_Glyph(face, glyph_index, load_flags);
        }

        public FT_Err FT_Load_Char(FT_FaceRec_* face, uint char_code, FT_LOAD load_flags)
        {
            return FTAndroidNative.FT_Load_Char(face, char_code, load_flags);
        }

        public void FT_Set_Transform(FT_FaceRec_* face, FT_Matrix_* matrix, FT_Vector_* delta)
        {
            FTAndroidNative.FT_Set_Transform(face, matrix, delta);
        }

        public void FT_Get_Transform(FT_FaceRec_* face, FT_Matrix_* matrix, FT_Vector_* delta)
        {
            FTAndroidNative.FT_Get_Transform(face, matrix, delta);
        }

        public FT_Err FT_Render_Glyph(FT_GlyphSlotRec_* slot, FT_Render_Mode_ render_mode)
        {
            return FTAndroidNative.FT_Render_Glyph(slot, render_mode);
        }

        public FT_Err FT_Get_Kerning(FT_FaceRec_* face, uint left_glyph, uint right_glyph, uint kern_mode, FT_Vector_* akerning)
        {
            return FTAndroidNative.FT_Get_Kerning(face, left_glyph, right_glyph, kern_mode, akerning);
        }

        public FT_Err FT_Get_Track_Kerning(FT_FaceRec_* face, int point_size, int degree, int* akerning)
        {
            return FTAndroidNative.FT_Get_Track_Kerning(face, point_size, degree, akerning);
        }

        public FT_Err FT_Select_Charmap(FT_FaceRec_* face, FT_Encoding_ encoding)
        {
            return FTAndroidNative.FT_Select_Charmap(face, encoding);
        }

        public FT_Err FT_Set_Charmap(FT_FaceRec_* face, FT_CharMapRec_* charmap)
        {
            return FTAndroidNative.FT_Set_Charmap(face, charmap);
        }

        public int FT_Get_Charmap_Index(FT_CharMapRec_* charmap)
        {
            return FTAndroidNative.FT_Get_Charmap_Index(charmap);
        }

        public uint FT_Get_Char_Index(FT_FaceRec_* face, uint charcode)
        {
            return FTAndroidNative.FT_Get_Char_Index(face, charcode);
        }

        public uint FT_Get_First_Char(FT_FaceRec_* face, uint* agindex)
        {
            return FTAndroidNative.FT_Get_First_Char(face, agindex);
        }

        public uint FT_Get_Next_Char(FT_FaceRec_* face, uint char_code, uint* agindex)
        {
            return FTAndroidNative.FT_Get_Next_Char(face, char_code, agindex);
        }

        public FT_Err FT_Face_Properties(FT_FaceRec_* face, uint num_properties, FT_Parameter_* properties)
        {
            return FTAndroidNative.FT_Face_Properties(face, num_properties, properties);
        }

        public uint FT_Get_Name_Index(FT_FaceRec_* face, byte* glyph_name)
        {
            return FTAndroidNative.FT_Get_Name_Index(face, glyph_name);
        }

        public FT_Err FT_Get_Glyph_Name(FT_FaceRec_* face, uint glyph_index, void* buffer, uint buffer_max)
        {
            return FTAndroidNative.FT_Get_Glyph_Name(face, glyph_index, buffer, buffer_max);
        }

        public byte* FT_Get_Postscript_Name(FT_FaceRec_* face)
        {
            return FTAndroidNative.FT_Get_Postscript_Name(face);
        }

        public FT_Err FT_Get_SubGlyph_Info(FT_GlyphSlotRec_* glyph, uint sub_index, int* p_index, uint* p_flags, int* p_arg1, int* p_arg2, FT_Matrix_* p_transform)
        {
            return FTAndroidNative.FT_Get_SubGlyph_Info(glyph, sub_index, p_index, p_flags, p_arg1, p_arg2, p_transform);
        }

        public ushort FT_Get_FSType_Flags(FT_FaceRec_* face)
        {
            return FTAndroidNative.FT_Get_FSType_Flags(face);
        }

        public uint FT_Face_GetCharVariantIndex(FT_FaceRec_* face, uint charcode, uint variantSelector)
        {
            return FTAndroidNative.FT_Face_GetCharVariantIndex(face, charcode, variantSelector);
        }

        public int FT_Face_GetCharVariantIsDefault(FT_FaceRec_* face, uint charcode, uint variantSelector)
        {
            return FTAndroidNative.FT_Face_GetCharVariantIsDefault(face, charcode, variantSelector);
        }

        public uint* FT_Face_GetVariantSelectors(FT_FaceRec_* face)
        {
            return FTAndroidNative.FT_Face_GetVariantSelectors(face);
        }

        public uint* FT_Face_GetVariantsOfChar(FT_FaceRec_* face, uint charcode)
        {
            return FTAndroidNative.FT_Face_GetVariantsOfChar(face, charcode);
        }

        public uint* FT_Face_GetCharsOfVariant(FT_FaceRec_* face, uint variantSelector)
        {
            return FTAndroidNative.FT_Face_GetCharsOfVariant(face, variantSelector);
        }

        public int FT_MulDiv(int a, int b, int c)
        {
            return FTAndroidNative.FT_MulDiv(a, b, c);
        }

        public int FT_MulFix(int a, int b)
        {
            return FTAndroidNative.FT_MulFix(a, b);
        }

        public int FT_DivFix(int a, int b)
        {
            return FTAndroidNative.FT_DivFix(a, b);
        }

        public int FT_RoundFix(int a)
        {
            return FTAndroidNative.FT_RoundFix(a);
        }

        public int FT_CeilFix(int a)
        {
            return FTAndroidNative.FT_CeilFix(a);
        }

        public int FT_FloorFix(int a)
        {
            return FTAndroidNative.FT_FloorFix(a);
        }

        public void FT_Vector_Transform(FT_Vector_* vector, FT_Matrix_* matrix)
        {
            FTAndroidNative.FT_Vector_Transform(vector, matrix);
        }

        public void FT_Library_Version(FT_LibraryRec_* library, int* amajor, int* aminor, int* apatch)
        {
            FTAndroidNative.FT_Library_Version(library, amajor, aminor, apatch);
        }

        public byte FT_Face_CheckTrueTypePatents(FT_FaceRec_* face)
        {
            return FTAndroidNative.FT_Face_CheckTrueTypePatents(face);
        }

        public byte FT_Face_SetUnpatentedHinting(FT_FaceRec_* face, byte value)
        {
            return FTAndroidNative.FT_Face_SetUnpatentedHinting(face, value);
        }
    }
}