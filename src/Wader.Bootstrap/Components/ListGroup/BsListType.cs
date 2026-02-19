namespace Wader.Bootstrap.Components.ListGroup;

public enum BsListType
{
    ContentDivision = 0,
    UnorderedList = 1,
    OrderedList = 2,
}

internal static class BsListTypeExtensions
{
    internal static string? ToBootstrapClass(this BsListType type)
    {
        return type switch
        {
            BsListType.ContentDivision => null,
            BsListType.UnorderedList => null,
            BsListType.OrderedList => "list-group-numbered",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null),
        };
    }
}
