namespace Wader.Bootstrap.Components.Pagination;

public enum BsPaginationSize
{
    Regular = 0,
    Small = 1,
    Large = 2,
}

public static class BsPaginationSizeExtensions
{
    public static string? ToBootstrapClass(this BsPaginationSize size)
    {
        return size switch
        {
            BsPaginationSize.Regular => null,
            BsPaginationSize.Small => "pagination-sm",
            BsPaginationSize.Large => "pagination-lg",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null),
        };
    }
}
