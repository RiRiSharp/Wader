namespace Wader.Bootstrap.Components.Popover;

public enum BsPopoverPlacement
{
    Auto = 0,
    Bottom = 1,
    Top = 2,
    Right = 3,
    Left = 4,
}

public static class BsPopoverPlacementExtensions
{
    internal static string ToPopperPlacementParameter(this BsPopoverPlacement placement)
    {
        return placement switch
        {
            BsPopoverPlacement.Auto => "auto",
            BsPopoverPlacement.Bottom => "bottom",
            BsPopoverPlacement.Top => "top",
            BsPopoverPlacement.Right => "right",
            BsPopoverPlacement.Left => "left",
            _ => throw new ArgumentOutOfRangeException(nameof(placement), placement, null),
        };
    }
}
