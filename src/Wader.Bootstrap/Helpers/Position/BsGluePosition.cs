namespace Wader.Bootstrap.Helpers.Position;

public enum BsGluePosition
{
    Top = 0,
    Bottom = 1,
}

public static class BsGluePositionExtensions
{
    internal static string ToFixedClass(this BsGluePosition position)
    {
        return position switch
        {
            BsGluePosition.Top => "fixed-top",
            BsGluePosition.Bottom => "fixed-bottom",
            _ => throw new ArgumentOutOfRangeException(nameof(position), position, null),
        };
    }

    internal static string ToStickyClass(this BsGluePosition position)
    {
        return position switch
        {
            BsGluePosition.Top => "sticky-top",
            BsGluePosition.Bottom => "sticky-bottom",
            _ => throw new ArgumentOutOfRangeException(nameof(position), position, null),
        };
    }
}
