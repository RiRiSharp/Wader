namespace Wader.Bootstrap.Layout.GridColumns;

[Flags]
public enum BsGridStartOptions : long
{
    None = 0,

    Start1 = 1 << 6,
    Start2 = 1 << 7,
    Start3 = 1 << 8,
    Start4 = 1 << 9,
    Start5 = 1 << 10,
    Start6 = 1 << 11,
    Start7 = 1 << 12,
    Start8 = 1 << 13,
    Start9 = 1 << 14,
    Start10 = 1 << 15,
    Start11 = 1 << 16,
    Start12 = 1 << 17,
}

internal static class GridStartOptionsExtensions
{
    internal static string ToBootstrapClass(this BsGridStartOptions gridColumnOptions)
    {
        var classString = "";
        if (gridColumnOptions == BsGridStartOptions.None)
        {
            return classString;
        }

        classString = "g-start";
        classString += gridColumnOptions.ColumnWidth();
        return classString;
    }

    private static string ColumnWidth(this BsGridStartOptions gridColumnOptions)
    {
        if (gridColumnOptions.HasFlag(BsGridStartOptions.Start1))
        {
            return "-1";
        }

        if (gridColumnOptions.HasFlag(BsGridStartOptions.Start2))
        {
            return "-2";
        }

        if (gridColumnOptions.HasFlag(BsGridStartOptions.Start3))
        {
            return "-3";
        }

        if (gridColumnOptions.HasFlag(BsGridStartOptions.Start4))
        {
            return "-4";
        }

        if (gridColumnOptions.HasFlag(BsGridStartOptions.Start5))
        {
            return "-5";
        }

        if (gridColumnOptions.HasFlag(BsGridStartOptions.Start6))
        {
            return "-6";
        }

        if (gridColumnOptions.HasFlag(BsGridStartOptions.Start7))
        {
            return "-7";
        }

        if (gridColumnOptions.HasFlag(BsGridStartOptions.Start8))
        {
            return "-8";
        }

        if (gridColumnOptions.HasFlag(BsGridStartOptions.Start9))
        {
            return "-9";
        }

        if (gridColumnOptions.HasFlag(BsGridStartOptions.Start10))
        {
            return "-10";
        }

        if (gridColumnOptions.HasFlag(BsGridStartOptions.Start11))
        {
            return "-11";
        }

        return gridColumnOptions.HasFlag(BsGridStartOptions.Start12) ? "-12" : "";
    }
}
