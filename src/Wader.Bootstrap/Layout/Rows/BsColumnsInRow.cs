namespace Wader.Bootstrap.Layout.Rows;

public enum BsColumnsInRow
{
    None = 0,
    Cols1 = 1,
    Cols2 = 2,
    Cols3 = 3,
    Cols4 = 4,
    Cols5 = 5,
    Cols6 = 6,
    Cols7 = 7,
    Cols8 = 8,
    Cols9 = 9,
    Cols10 = 10,
    Cols11 = 11,
    Cols12 = 12,
    ColsAuto = 13,
}

internal static class RowOptsExtensions
{
    internal static string? ToBootstrapClass(this BsColumnsInRow options)
    {
        return options switch
        {
            BsColumnsInRow.None => null,
            BsColumnsInRow.Cols1 => "row-cols-1",
            BsColumnsInRow.Cols2 => "row-cols-2",
            BsColumnsInRow.Cols3 => "row-cols-3",
            BsColumnsInRow.Cols4 => "row-cols-4",
            BsColumnsInRow.Cols5 => "row-cols-5",
            BsColumnsInRow.Cols6 => "row-cols-6",
            BsColumnsInRow.Cols7 => "row-cols-7",
            BsColumnsInRow.Cols8 => "row-cols-8",
            BsColumnsInRow.Cols9 => "row-cols-9",
            BsColumnsInRow.Cols10 => "row-cols-10",
            BsColumnsInRow.Cols11 => "row-cols-11",
            BsColumnsInRow.Cols12 => "row-cols-12",
            BsColumnsInRow.ColsAuto => "row-cols-auto",
            _ => throw new ArgumentOutOfRangeException(nameof(options), options, null),
        };
    }
}
