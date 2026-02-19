namespace Wader.Bootstrap.Components.Badge;

public enum BsBadgeColor
{
    Primary = 0,
    Secondary = 1,
    Success = 2,
    Danger = 3,
    Warning = 4,
    Info = 5,
    Light = 6,
    Dark = 7,
}

internal static class BsBadgeColorExtensions
{
    internal static string ToBootstrapClass(this BsBadgeColor color)
    {
        return color switch
        {
            BsBadgeColor.Primary => "text-bg-primary",
            BsBadgeColor.Secondary => "text-bg-secondary",
            BsBadgeColor.Success => "text-bg-success",
            BsBadgeColor.Danger => "text-bg-danger",
            BsBadgeColor.Warning => "text-bg-warning",
            BsBadgeColor.Info => "text-bg-info",
            BsBadgeColor.Light => "text-bg-light",
            BsBadgeColor.Dark => "text-bg-dark",
            _ => throw new ArgumentOutOfRangeException(nameof(color), color, null),
        };
    }
}
