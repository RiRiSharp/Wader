namespace Wader.Bootstrap.Primitives;

public enum BsDirection
{
    Down = 0,
    Up = 1,
    Start = 2,
    End = 3,
}

internal static class DropdownDirectionExtensions
{
    internal static string ToDropDirectionBootstrapClass(this BsDirection direction)
    {
        return direction switch
        {
            BsDirection.Down => "dropdown",
            BsDirection.Up => "dropup",
            BsDirection.Start => "dropstart",
            BsDirection.End => "dropend",
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null),
        };
    }

    internal static string? ToDropdownBootstrapClass(this BsDirection direction)
    {
        return direction switch
        {
            BsDirection.Start => null,
            BsDirection.End => "dropdown-menu-end",
            BsDirection.Down or BsDirection.Up => throw new ArgumentOutOfRangeException(
                nameof(direction),
                direction,
                $"Only {nameof(BsDirection.Start)} or {nameof(BsDirection.End)} are valid for dropdown menu alignment"
            ),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null),
        };
    }

    internal static string ToOffcanvasBootstrapClass(this BsDirection direction)
    {
        return direction switch
        {
            BsDirection.Down => "offcanvas-bottom",
            BsDirection.Up => "offcanvas-top",
            BsDirection.Start => "offcanvas-start",
            BsDirection.End => "offcanvas-end",
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null),
        };
    }

    internal static string ToPopperPlacementParameter(this BsDirection direction)
    {
        return direction switch
        {
            BsDirection.Down => "bottom",
            BsDirection.Up => "top",
            BsDirection.Start => "right", // Yeah that's a quirk on Bootstrap's side
            BsDirection.End => "left",
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null),
        };
    }
}
