namespace Wader.Bootstrap.Helpers.Ratio;

public enum BsRatioVariant
{
    R1X1 = 0,
    R4X3 = 1,
    R16X9 = 2,
    R21X9 = 3,
}

public static class BsRatioVariantExtensions
{
    internal static string ToBootstrapClass(this BsRatioVariant variant)
    {
        return variant switch
        {
            BsRatioVariant.R1X1 => "ratio-1x1",
            BsRatioVariant.R4X3 => "ratio-4x3",
            BsRatioVariant.R16X9 => "ratio-16x9",
            BsRatioVariant.R21X9 => "ratio-21x9",
            _ => throw new ArgumentOutOfRangeException(nameof(variant), variant, null),
        };
    }
}
