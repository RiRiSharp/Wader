namespace Wader.Bootstrap.Helpers.Position;

public enum BsStickyPosition
{
    Top = 0,
    Bottom = 1,
}

public static class BsStickyPositionExtensions
{
    internal static string ToBootstrapClass(this BsStickyPosition position)
    {
        return position switch
        {
            BsStickyPosition.Top => "sticky-top",
            BsStickyPosition.Bottom => "sticky-bottom",
            _ => throw new ArgumentOutOfRangeException(nameof(position), position, null),
        };
    }
}
