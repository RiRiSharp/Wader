namespace Wader.Bootstrap.Components.Spinners;

public enum BsSpinnerVariant
{
    Border = 0,
    Grow = 1,
}

public static class BsSpinnerVariantExtensions
{
    public static string ToBootstrapClass(this BsSpinnerVariant variant, BsSpinnerSize size)
    {
        var baseClass = variant switch
        {
            BsSpinnerVariant.Border => "spinner-border",
            BsSpinnerVariant.Grow => "spinner-grow",
            _ => throw new ArgumentOutOfRangeException(nameof(variant), variant, null),
        };

        return size switch
        {
            BsSpinnerSize.Regular => baseClass,
            BsSpinnerSize.Small => $"{baseClass} {baseClass}-sm",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null),
        };
    }
}
