namespace Wader.Bootstrap.Content.Typography.Headings;

public enum BsDisplayHeadingType
{
    Display1 = 0,
    Display2 = 1,
    Display3 = 2,
    Display4 = 3,
    Display5 = 4,
    Display6 = 5,
}

internal static class DisplayHeadingTypeExtensions
{
    internal static string ToBootstrapClass(this BsDisplayHeadingType displayHeadingType)
    {
        return displayHeadingType switch
        {
            BsDisplayHeadingType.Display1 => "display-1",
            BsDisplayHeadingType.Display2 => "display-2",
            BsDisplayHeadingType.Display3 => "display-3",
            BsDisplayHeadingType.Display4 => "display-4",
            BsDisplayHeadingType.Display5 => "display-5",
            BsDisplayHeadingType.Display6 => "display-6",
            _ => throw new ArgumentOutOfRangeException(nameof(displayHeadingType), displayHeadingType, null),
        };
    }
}
