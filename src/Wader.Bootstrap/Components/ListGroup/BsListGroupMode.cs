namespace Wader.Bootstrap.Components.ListGroup;

public enum BsListGroupMode
{
    Regular = 0,
    Flush = 1,
}

internal static class BsListGroupModeExtensions
{
    internal static string? ToBootstrapClass(this BsListGroupMode mode)
    {
        return mode switch
        {
            BsListGroupMode.Regular => null,
            BsListGroupMode.Flush => "list-group-flush",
            _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, null),
        };
    }
}
