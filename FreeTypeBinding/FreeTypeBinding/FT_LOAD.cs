namespace FreeTypeBinding
{
    public enum FT_LOAD : long
    {
        FT_LOAD_DEFAULT = 0x0,
        FT_LOAD_NO_SCALE = (1L << 0),
        FT_LOAD_NO_HINTING = (1L << 1),
        FT_LOAD_RENDER = (1L << 2),
        FT_LOAD_NO_BITMAP = (1L << 3),
        FT_LOAD_VERTICAL_LAYOUT = (1L << 4),
        FT_LOAD_FORCE_AUTOHINT = (1L << 5),
        FT_LOAD_CROP_BITMAP = (1L << 6),
        FT_LOAD_PEDANTIC = (1L << 7),
        FT_LOAD_IGNORE_GLOBAL_ADVANCE_WIDTH = (1L << 9),
        FT_LOAD_NO_RECURSE = (1L << 10),
        FT_LOAD_IGNORE_TRANSFORM = (1L << 11),
        FT_LOAD_MONOCHROME = (1L << 12),
        FT_LOAD_LINEAR_DESIGN = (1L << 13),
        FT_LOAD_SBITS_ONLY = (1L << 14),
        FT_LOAD_NO_AUTOHINT = (1L << 15),
        FT_LOAD_COLOR = (1L << 20),
        FT_LOAD_COMPUTE_METRICS = (1L << 21),
        FT_LOAD_BITMAP_METRICS_ONLY = (1L << 22),
        FT_LOAD_NO_SVG = (1L << 24),
        FT_LOAD_ADVANCE_ONLY = (1L << 8),
        FT_LOAD_SVG_ONLY = (1L << 23)}
}