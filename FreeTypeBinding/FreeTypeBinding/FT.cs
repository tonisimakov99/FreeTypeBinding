using System.Runtime.InteropServices;

namespace FreeTypeBinding
{
    public unsafe class FT
    {
        public FT(Platform platform)
        {
            if (platform == Platform.Windows)
                lib = new FTWindows();
            else if (platform == Platform.Linux)
                lib = new FTLinux();
            else if (platform == Platform.Android)
                lib = new FTAndroid();
            else
                throw new System.NotSupportedException("not supported");
        }

        IFT lib;
        public FT_Err FT_Init_FreeType(FT_LibraryRec_** alibrary)
        {
            return lib.FT_Init_FreeType(alibrary);
        }

        public FT_Err FT_Done_FreeType(FT_LibraryRec_* library)
        {
            return lib.FT_Done_FreeType(library);
        }

        public FT_Err FT_New_Face(FT_LibraryRec_* library, byte* filepathname, CLong face_index, FT_FaceRec_** aface)
        {
            return lib.FT_New_Face(library, filepathname, face_index, aface);
        }

        public FT_Err FT_New_Memory_Face(FT_LibraryRec_* library, byte* file_base, CLong file_size, CLong face_index, FT_FaceRec_** aface)
        {
            return lib.FT_New_Memory_Face(library, file_base, file_size, face_index, aface);
        }

        public FT_Err FT_Open_Face(FT_LibraryRec_* library, FT_Open_Args_* args, CLong face_index, FT_FaceRec_** aface)
        {
            return lib.FT_Open_Face(library, args, face_index, aface);
        }

        public FT_Err FT_Attach_File(FT_FaceRec_* face, byte* filepathname)
        {
            return lib.FT_Attach_File(face, filepathname);
        }

        public FT_Err FT_Attach_Stream(FT_FaceRec_* face, FT_Open_Args_* parameters)
        {
            return lib.FT_Attach_Stream(face, parameters);
        }

        public FT_Err FT_Reference_Face(FT_FaceRec_* face)
        {
            return lib.FT_Reference_Face(face);
        }

        public FT_Err FT_Done_Face(FT_FaceRec_* face)
        {
            return lib.FT_Done_Face(face);
        }

        public FT_Err FT_Select_Size(FT_FaceRec_* face, int strike_index)
        {
            return lib.FT_Select_Size(face, strike_index);
        }

        public FT_Err FT_Request_Size(FT_FaceRec_* face, FT_Size_RequestRec_* req)
        {
            return lib.FT_Request_Size(face, req);
        }

        public FT_Err FT_Set_Char_Size(FT_FaceRec_* face, CLong char_width, CLong char_height, uint horz_resolution, uint vert_resolution)
        {
            return lib.FT_Set_Char_Size(face, char_width, char_height, horz_resolution, vert_resolution);
        }

        public FT_Err FT_Set_Pixel_Sizes(FT_FaceRec_* face, uint pixel_width, uint pixel_height)
        {
            return lib.FT_Set_Pixel_Sizes(face, pixel_width, pixel_height);
        }

        public FT_Err FT_Load_Glyph(FT_FaceRec_* face, uint glyph_index, int load_flags)
        {
            return lib.FT_Load_Glyph(face, glyph_index, load_flags);
        }

        public FT_Err FT_Load_Char(FT_FaceRec_* face, CULong char_code, int load_flags)
        {
            return lib.FT_Load_Char(face, char_code, load_flags);
        }

        public void FT_Set_Transform(FT_FaceRec_* face, FT_Matrix_* matrix, FT_Vector_* delta)
        {
            lib.FT_Set_Transform(face, matrix, delta);
        }

        public void FT_Get_Transform(FT_FaceRec_* face, FT_Matrix_* matrix, FT_Vector_* delta)
        {
            lib.FT_Get_Transform(face, matrix, delta);
        }

        public FT_Err FT_Render_Glyph(FT_GlyphSlotRec_* slot, FT_Render_Mode_ render_mode)
        {
            return lib.FT_Render_Glyph(slot, render_mode);
        }

        public FT_Err FT_Get_Kerning(FT_FaceRec_* face, uint left_glyph, uint right_glyph, uint kern_mode, FT_Vector_* akerning)
        {
            return lib.FT_Get_Kerning(face, left_glyph, right_glyph, kern_mode, akerning);
        }

        public FT_Err FT_Get_Track_Kerning(FT_FaceRec_* face, CLong point_size, int degree, CLong* akerning)
        {
            return lib.FT_Get_Track_Kerning(face, point_size, degree, akerning);
        }

        public FT_Err FT_Select_Charmap(FT_FaceRec_* face, FT_Encoding_ encoding)
        {
            return lib.FT_Select_Charmap(face, encoding);
        }

        public FT_Err FT_Set_Charmap(FT_FaceRec_* face, FT_CharMapRec_* charmap)
        {
            return lib.FT_Set_Charmap(face, charmap);
        }

        public int FT_Get_Charmap_Index(FT_CharMapRec_* charmap)
        {
            return lib.FT_Get_Charmap_Index(charmap);
        }

        public uint FT_Get_Char_Index(FT_FaceRec_* face, CULong charcode)
        {
            return lib.FT_Get_Char_Index(face, charcode);
        }

        public CULong FT_Get_First_Char(FT_FaceRec_* face, uint* agindex)
        {
            return lib.FT_Get_First_Char(face, agindex);
        }

        public CULong FT_Get_Next_Char(FT_FaceRec_* face, CULong char_code, uint* agindex)
        {
            return lib.FT_Get_Next_Char(face, char_code, agindex);
        }

        public FT_Err FT_Face_Properties(FT_FaceRec_* face, uint num_properties, FT_Parameter_* properties)
        {
            return lib.FT_Face_Properties(face, num_properties, properties);
        }

        public uint FT_Get_Name_Index(FT_FaceRec_* face, byte* glyph_name)
        {
            return lib.FT_Get_Name_Index(face, glyph_name);
        }

        public FT_Err FT_Get_Glyph_Name(FT_FaceRec_* face, uint glyph_index, void* buffer, uint buffer_max)
        {
            return lib.FT_Get_Glyph_Name(face, glyph_index, buffer, buffer_max);
        }

        public byte* FT_Get_Postscript_Name(FT_FaceRec_* face)
        {
            return lib.FT_Get_Postscript_Name(face);
        }

        public FT_Err FT_Get_SubGlyph_Info(FT_GlyphSlotRec_* glyph, uint sub_index, int* p_index, uint* p_flags, int* p_arg1, int* p_arg2, FT_Matrix_* p_transform)
        {
            return lib.FT_Get_SubGlyph_Info(glyph, sub_index, p_index, p_flags, p_arg1, p_arg2, p_transform);
        }

        public ushort FT_Get_FSType_Flags(FT_FaceRec_* face)
        {
            return lib.FT_Get_FSType_Flags(face);
        }

        public uint FT_Face_GetCharVariantIndex(FT_FaceRec_* face, CULong charcode, CULong variantSelector)
        {
            return lib.FT_Face_GetCharVariantIndex(face, charcode, variantSelector);
        }

        public int FT_Face_GetCharVariantIsDefault(FT_FaceRec_* face, CULong charcode, CULong variantSelector)
        {
            return lib.FT_Face_GetCharVariantIsDefault(face, charcode, variantSelector);
        }

        public uint* FT_Face_GetVariantSelectors(FT_FaceRec_* face)
        {
            return lib.FT_Face_GetVariantSelectors(face);
        }

        public uint* FT_Face_GetVariantsOfChar(FT_FaceRec_* face, CULong charcode)
        {
            return lib.FT_Face_GetVariantsOfChar(face, charcode);
        }

        public uint* FT_Face_GetCharsOfVariant(FT_FaceRec_* face, CULong variantSelector)
        {
            return lib.FT_Face_GetCharsOfVariant(face, variantSelector);
        }

        public CLong FT_MulDiv(CLong a, CLong b, CLong c)
        {
            return lib.FT_MulDiv(a, b, c);
        }

        public CLong FT_MulFix(CLong a, CLong b)
        {
            return lib.FT_MulFix(a, b);
        }

        public CLong FT_DivFix(CLong a, CLong b)
        {
            return lib.FT_DivFix(a, b);
        }

        public CLong FT_RoundFix(CLong a)
        {
            return lib.FT_RoundFix(a);
        }

        public CLong FT_CeilFix(CLong a)
        {
            return lib.FT_CeilFix(a);
        }

        public CLong FT_FloorFix(CLong a)
        {
            return lib.FT_FloorFix(a);
        }

        public void FT_Vector_Transform(FT_Vector_* vector, FT_Matrix_* matrix)
        {
            lib.FT_Vector_Transform(vector, matrix);
        }

        public void FT_Library_Version(FT_LibraryRec_* library, int* amajor, int* aminor, int* apatch)
        {
            lib.FT_Library_Version(library, amajor, aminor, apatch);
        }

        public byte FT_Face_CheckTrueTypePatents(FT_FaceRec_* face)
        {
            return lib.FT_Face_CheckTrueTypePatents(face);
        }

        public byte FT_Face_SetUnpatentedHinting(FT_FaceRec_* face, byte value)
        {
            return lib.FT_Face_SetUnpatentedHinting(face, value);
        }

        public System.Int32 FT_LOAD_DEFAULT => lib.FT_LOAD_DEFAULT;
        public CLong FT_LOAD_NO_SCALE => lib.FT_LOAD_NO_SCALE;
        public CLong FT_LOAD_NO_HINTING => lib.FT_LOAD_NO_HINTING;
        public CLong FT_LOAD_RENDER => lib.FT_LOAD_RENDER;
        public CLong FT_LOAD_NO_BITMAP => lib.FT_LOAD_NO_BITMAP;
        public CLong FT_LOAD_VERTICAL_LAYOUT => lib.FT_LOAD_VERTICAL_LAYOUT;
        public CLong FT_LOAD_FORCE_AUTOHINT => lib.FT_LOAD_FORCE_AUTOHINT;
        public CLong FT_LOAD_CROP_BITMAP => lib.FT_LOAD_CROP_BITMAP;
        public CLong FT_LOAD_PEDANTIC => lib.FT_LOAD_PEDANTIC;
        public CLong FT_LOAD_IGNORE_GLOBAL_ADVANCE_WIDTH => lib.FT_LOAD_IGNORE_GLOBAL_ADVANCE_WIDTH;
        public CLong FT_LOAD_NO_RECURSE => lib.FT_LOAD_NO_RECURSE;
        public CLong FT_LOAD_IGNORE_TRANSFORM => lib.FT_LOAD_IGNORE_TRANSFORM;
        public CLong FT_LOAD_MONOCHROME => lib.FT_LOAD_MONOCHROME;
        public CLong FT_LOAD_LINEAR_DESIGN => lib.FT_LOAD_LINEAR_DESIGN;
        public CLong FT_LOAD_SBITS_ONLY => lib.FT_LOAD_SBITS_ONLY;
        public CLong FT_LOAD_NO_AUTOHINT => lib.FT_LOAD_NO_AUTOHINT;
        public CLong FT_LOAD_COLOR => lib.FT_LOAD_COLOR;
        public CLong FT_LOAD_COMPUTE_METRICS => lib.FT_LOAD_COMPUTE_METRICS;
        public CLong FT_LOAD_BITMAP_METRICS_ONLY => lib.FT_LOAD_BITMAP_METRICS_ONLY;
        public CLong FT_LOAD_NO_SVG => lib.FT_LOAD_NO_SVG;
        public CLong FT_LOAD_ADVANCE_ONLY => lib.FT_LOAD_ADVANCE_ONLY;
        public CLong FT_LOAD_SVG_ONLY => lib.FT_LOAD_SVG_ONLY;
        public CLong FT_FACE_FLAG_SCALABLE => lib.FT_FACE_FLAG_SCALABLE;
        public CLong FT_FACE_FLAG_FIXED_SIZES => lib.FT_FACE_FLAG_FIXED_SIZES;
        public CLong FT_FACE_FLAG_FIXED_WIDTH => lib.FT_FACE_FLAG_FIXED_WIDTH;
        public CLong FT_FACE_FLAG_SFNT => lib.FT_FACE_FLAG_SFNT;
        public CLong FT_FACE_FLAG_HORIZONTAL => lib.FT_FACE_FLAG_HORIZONTAL;
        public CLong FT_FACE_FLAG_VERTICAL => lib.FT_FACE_FLAG_VERTICAL;
        public CLong FT_FACE_FLAG_KERNING => lib.FT_FACE_FLAG_KERNING;
        public CLong FT_FACE_FLAG_FAST_GLYPHS => lib.FT_FACE_FLAG_FAST_GLYPHS;
        public CLong FT_FACE_FLAG_MULTIPLE_MASTERS => lib.FT_FACE_FLAG_MULTIPLE_MASTERS;
        public CLong FT_FACE_FLAG_GLYPH_NAMES => lib.FT_FACE_FLAG_GLYPH_NAMES;
        public CLong FT_FACE_FLAG_EXTERNAL_STREAM => lib.FT_FACE_FLAG_EXTERNAL_STREAM;
        public CLong FT_FACE_FLAG_HINTER => lib.FT_FACE_FLAG_HINTER;
        public CLong FT_FACE_FLAG_CID_KEYED => lib.FT_FACE_FLAG_CID_KEYED;
        public CLong FT_FACE_FLAG_TRICKY => lib.FT_FACE_FLAG_TRICKY;
        public CLong FT_FACE_FLAG_COLOR => lib.FT_FACE_FLAG_COLOR;
        public CLong FT_FACE_FLAG_VARIATION => lib.FT_FACE_FLAG_VARIATION;
        public CLong FT_FACE_FLAG_SVG => lib.FT_FACE_FLAG_SVG;
        public CLong FT_FACE_FLAG_SBIX => lib.FT_FACE_FLAG_SBIX;
        public CLong FT_FACE_FLAG_SBIX_OVERLAY => lib.FT_FACE_FLAG_SBIX_OVERLAY;
        public System.Int32 FT_STYLE_FLAG_ITALIC => lib.FT_STYLE_FLAG_ITALIC;
        public System.Int32 FT_STYLE_FLAG_BOLD => lib.FT_STYLE_FLAG_BOLD;
    }
}