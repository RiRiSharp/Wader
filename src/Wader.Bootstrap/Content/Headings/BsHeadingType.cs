namespace Wader.Bootstrap.Content.Headings;

public enum BsHeadingType
{
    H1 = 0,
    H2 = 1,
    H3 = 2,
    H4 = 3,
    H5 = 4,
    H6 = 5,
}

internal static class HeadingTypeExtensions
{
    internal static string ToBootstrapClass(this BsHeadingType headingType)
    {
        return headingType.ToString().ToLowerInvariant();
    }
}
