namespace Wader.Bootstrap.Components.Collapse;

public enum BsCollapseDirection
{
    Vertical = 0,
    Horizontal = 1,
}

internal static class BsCollapseDirectionExtensions
{
    internal static string? ToBootstrapClass(this BsCollapseDirection collapseDirection)
    {
        return collapseDirection switch
        {
            BsCollapseDirection.Vertical => null,
            BsCollapseDirection.Horizontal => "collapse-horizontal",
            _ => throw new ArgumentOutOfRangeException(nameof(collapseDirection), collapseDirection, null),
        };
    }
}
