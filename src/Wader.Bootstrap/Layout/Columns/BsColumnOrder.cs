namespace Wader.Bootstrap.Layout.Columns;

public enum BsColumnOrder
{
    Default = 0,
    Order1 = 1,
    Order2 = 2,
    Order3 = 3,
    Order4 = 4,
    Order5 = 5,
    OrderFirst = 6,
    OrderLast = 7,
}

internal static class ColumnOrderExtensions
{
    internal static string? ToBootstrapClass(this BsColumnOrder options)
    {
        return options switch
        {
            BsColumnOrder.Default => null,
            BsColumnOrder.Order1 => "order-1",
            BsColumnOrder.Order2 => "order-2",
            BsColumnOrder.Order3 => "order-3",
            BsColumnOrder.Order4 => "order-4",
            BsColumnOrder.Order5 => "order-5",
            BsColumnOrder.OrderFirst => "order-first",
            BsColumnOrder.OrderLast => "order-last",
            _ => throw new ArgumentOutOfRangeException(nameof(options), options, null),
        };
    }
}
