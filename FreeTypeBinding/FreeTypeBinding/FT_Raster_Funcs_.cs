namespace FreeTypeBinding
{
    public unsafe struct FT_Raster_Funcs_
    {
        public FT_Glyph_Format glyph_format;
        public FT_Raster_NewFunc raster_new;
        public FT_Raster_ResetFunc raster_reset;
        public FT_Raster_SetModeFunc raster_set_mode;
        public FT_Raster_RenderFunc raster_render;
        public FT_Raster_DoneFunc raster_done;
    }
}