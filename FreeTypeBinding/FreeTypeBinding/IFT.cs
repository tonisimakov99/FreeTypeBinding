using System.Runtime.InteropServices;

namespace FreeTypeBinding
{
    internal unsafe interface IFT
    {
        FT_Err FT_Init_FreeType(FT_LibraryRec_** alibrary);
        FT_Err FT_Done_FreeType(FT_LibraryRec_* library);
        FT_Err FT_New_Face(FT_LibraryRec_* library, byte* filepathname, CLong face_index, FT_FaceRec_** aface);
        FT_Err FT_New_Memory_Face(FT_LibraryRec_* library, byte* file_base, CLong file_size, CLong face_index, FT_FaceRec_** aface);
        FT_Err FT_Open_Face(FT_LibraryRec_* library, FT_Open_Args_* args, CLong face_index, FT_FaceRec_** aface);
        FT_Err FT_Attach_File(FT_FaceRec_* face, byte* filepathname);
        FT_Err FT_Attach_Stream(FT_FaceRec_* face, FT_Open_Args_* parameters);
        FT_Err FT_Reference_Face(FT_FaceRec_* face);
        FT_Err FT_Done_Face(FT_FaceRec_* face);
        FT_Err FT_Select_Size(FT_FaceRec_* face, int strike_index);
        FT_Err FT_Request_Size(FT_FaceRec_* face, FT_Size_RequestRec_* req);
        FT_Err FT_Set_Char_Size(FT_FaceRec_* face, CLong char_width, CLong char_height, uint horz_resolution, uint vert_resolution);
        FT_Err FT_Set_Pixel_Sizes(FT_FaceRec_* face, uint pixel_width, uint pixel_height);
        FT_Err FT_Load_Glyph(FT_FaceRec_* face, uint glyph_index, int load_flags);
        FT_Err FT_Load_Char(FT_FaceRec_* face, CULong char_code, int load_flags);
        void FT_Set_Transform(FT_FaceRec_* face, FT_Matrix_* matrix, FT_Vector_* delta);
        void FT_Get_Transform(FT_FaceRec_* face, FT_Matrix_* matrix, FT_Vector_* delta);
        FT_Err FT_Render_Glyph(FT_GlyphSlotRec_* slot, FT_Render_Mode_ render_mode);
        FT_Err FT_Get_Kerning(FT_FaceRec_* face, uint left_glyph, uint right_glyph, uint kern_mode, FT_Vector_* akerning);
        FT_Err FT_Get_Track_Kerning(FT_FaceRec_* face, CLong point_size, int degree, CLong* akerning);
        FT_Err FT_Select_Charmap(FT_FaceRec_* face, FT_Encoding_ encoding);
        FT_Err FT_Set_Charmap(FT_FaceRec_* face, FT_CharMapRec_* charmap);
        int FT_Get_Charmap_Index(FT_CharMapRec_* charmap);
        uint FT_Get_Char_Index(FT_FaceRec_* face, CULong charcode);
        CULong FT_Get_First_Char(FT_FaceRec_* face, uint* agindex);
        CULong FT_Get_Next_Char(FT_FaceRec_* face, CULong char_code, uint* agindex);
        FT_Err FT_Face_Properties(FT_FaceRec_* face, uint num_properties, FT_Parameter_* properties);
        uint FT_Get_Name_Index(FT_FaceRec_* face, byte* glyph_name);
        FT_Err FT_Get_Glyph_Name(FT_FaceRec_* face, uint glyph_index, void* buffer, uint buffer_max);
        byte* FT_Get_Postscript_Name(FT_FaceRec_* face);
        FT_Err FT_Get_SubGlyph_Info(FT_GlyphSlotRec_* glyph, uint sub_index, int* p_index, uint* p_flags, int* p_arg1, int* p_arg2, FT_Matrix_* p_transform);
        ushort FT_Get_FSType_Flags(FT_FaceRec_* face);
        uint FT_Face_GetCharVariantIndex(FT_FaceRec_* face, CULong charcode, CULong variantSelector);
        int FT_Face_GetCharVariantIsDefault(FT_FaceRec_* face, CULong charcode, CULong variantSelector);
        uint* FT_Face_GetVariantSelectors(FT_FaceRec_* face);
        uint* FT_Face_GetVariantsOfChar(FT_FaceRec_* face, CULong charcode);
        uint* FT_Face_GetCharsOfVariant(FT_FaceRec_* face, CULong variantSelector);
        CLong FT_MulDiv(CLong a, CLong b, CLong c);
        CLong FT_MulFix(CLong a, CLong b);
        CLong FT_DivFix(CLong a, CLong b);
        CLong FT_RoundFix(CLong a);
        CLong FT_CeilFix(CLong a);
        CLong FT_FloorFix(CLong a);
        void FT_Vector_Transform(FT_Vector_* vector, FT_Matrix_* matrix);
        void FT_Library_Version(FT_LibraryRec_* library, int* amajor, int* aminor, int* apatch);
        byte FT_Face_CheckTrueTypePatents(FT_FaceRec_* face);
        byte FT_Face_SetUnpatentedHinting(FT_FaceRec_* face, byte value);
        System.Int32 FT_LOAD_DEFAULT { get; }

        CLong FT_LOAD_NO_SCALE { get; }

        CLong FT_LOAD_NO_HINTING { get; }

        CLong FT_LOAD_RENDER { get; }

        CLong FT_LOAD_NO_BITMAP { get; }

        CLong FT_LOAD_VERTICAL_LAYOUT { get; }

        CLong FT_LOAD_FORCE_AUTOHINT { get; }

        CLong FT_LOAD_CROP_BITMAP { get; }

        CLong FT_LOAD_PEDANTIC { get; }

        CLong FT_LOAD_IGNORE_GLOBAL_ADVANCE_WIDTH { get; }

        CLong FT_LOAD_NO_RECURSE { get; }

        CLong FT_LOAD_IGNORE_TRANSFORM { get; }

        CLong FT_LOAD_MONOCHROME { get; }

        CLong FT_LOAD_LINEAR_DESIGN { get; }

        CLong FT_LOAD_SBITS_ONLY { get; }

        CLong FT_LOAD_NO_AUTOHINT { get; }

        CLong FT_LOAD_COLOR { get; }

        CLong FT_LOAD_COMPUTE_METRICS { get; }

        CLong FT_LOAD_BITMAP_METRICS_ONLY { get; }

        CLong FT_LOAD_NO_SVG { get; }

        CLong FT_LOAD_ADVANCE_ONLY { get; }

        CLong FT_LOAD_SVG_ONLY { get; }

        CLong FT_FACE_FLAG_SCALABLE { get; }

        CLong FT_FACE_FLAG_FIXED_SIZES { get; }

        CLong FT_FACE_FLAG_FIXED_WIDTH { get; }

        CLong FT_FACE_FLAG_SFNT { get; }

        CLong FT_FACE_FLAG_HORIZONTAL { get; }

        CLong FT_FACE_FLAG_VERTICAL { get; }

        CLong FT_FACE_FLAG_KERNING { get; }

        CLong FT_FACE_FLAG_FAST_GLYPHS { get; }

        CLong FT_FACE_FLAG_MULTIPLE_MASTERS { get; }

        CLong FT_FACE_FLAG_GLYPH_NAMES { get; }

        CLong FT_FACE_FLAG_EXTERNAL_STREAM { get; }

        CLong FT_FACE_FLAG_HINTER { get; }

        CLong FT_FACE_FLAG_CID_KEYED { get; }

        CLong FT_FACE_FLAG_TRICKY { get; }

        CLong FT_FACE_FLAG_COLOR { get; }

        CLong FT_FACE_FLAG_VARIATION { get; }

        CLong FT_FACE_FLAG_SVG { get; }

        CLong FT_FACE_FLAG_SBIX { get; }

        CLong FT_FACE_FLAG_SBIX_OVERLAY { get; }

        System.Int32 FT_STYLE_FLAG_ITALIC { get; }

        System.Int32 FT_STYLE_FLAG_BOLD { get; }
    }
}