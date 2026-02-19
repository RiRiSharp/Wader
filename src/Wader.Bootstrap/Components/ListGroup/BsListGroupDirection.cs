namespace Wader.Bootstrap.Components.ListGroup;

public enum BsListGroupDirection
{
    Vertical = 0,
    Horizontal = 1,
}

internal static class BsListGroupDirectionExtensions
{
    internal static string? ToBootstrapClass(this BsListGroupDirection direction)
    {
        return direction switch
        {
            BsListGroupDirection.Vertical => null,
            BsListGroupDirection.Horizontal => "list-group-horizontal",
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null),
        };
    }
}
