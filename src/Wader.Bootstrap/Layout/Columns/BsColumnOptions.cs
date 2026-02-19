namespace Wader.Bootstrap.Layout.Columns;

[Flags]
public enum BsColumnOptions : long
{
    None = 0,
    Sm = 1 << 1,
    Md = 1 << 2,
    Lg = 1 << 3,
    Xl = 1 << 4,
    Xxl = 1 << 5,

    Col1 = 1 << 6,

    ColSm1 = Sm | Col1,

    ColMd1 = Md | Col1,

    ColLg1 = Lg | Col1,

    ColXl1 = Xl | Col1,

    ColXxl1 = Xxl | Col1,
    Col2 = 1 << 7,
    ColSm2 = Sm | Col2,
    ColMd2 = Md | Col2,
    ColLg2 = Lg | Col2,
    ColXl2 = Xl | Col2,
    ColXxl2 = Xxl | Col2,
    Col3 = 1 << 8,
    ColSm3 = Sm | Col3,
    ColMd3 = Md | Col3,
    ColLg3 = Lg | Col3,
    ColXl3 = Xl | Col3,
    ColXxl3 = Xxl | Col3,
    Col4 = 1 << 9,
    ColSm4 = Sm | Col4,
    ColMd4 = Md | Col4,
    ColLg4 = Lg | Col4,
    ColXl4 = Xl | Col4,
    ColXxl4 = Xxl | Col4,
    Col5 = 1 << 10,
    ColSm5 = Sm | Col5,
    ColMd5 = Md | Col5,
    ColLg5 = Lg | Col5,
    ColXl5 = Xl | Col5,
    ColXxl5 = Xxl | Col5,
    Col6 = 1 << 11,
    ColSm6 = Sm | Col6,
    ColMd6 = Md | Col6,
    ColLg6 = Lg | Col6,
    ColXl6 = Xl | Col6,
    ColXxl6 = Xxl | Col6,
    Col7 = 1 << 12,
    ColSm7 = Sm | Col7,
    ColMd7 = Md | Col7,
    ColLg7 = Lg | Col7,
    ColXl7 = Xl | Col7,
    ColXxl7 = Xxl | Col7,
    Col8 = 1 << 13,
    ColSm8 = Sm | Col8,
    ColMd8 = Md | Col8,
    ColLg8 = Lg | Col8,
    ColXl8 = Xl | Col8,
    ColXxl8 = Xxl | Col8,
    Col9 = 1 << 14,
    ColSm9 = Sm | Col9,
    ColMd9 = Md | Col9,
    ColLg9 = Lg | Col9,
    ColXl9 = Xl | Col9,
    ColXxl9 = Xxl | Col9,
    Col10 = 1 << 15,
    ColSm10 = Sm | Col10,
    ColMd10 = Md | Col10,
    ColLg10 = Lg | Col10,
    ColXl10 = Xl | Col10,
    ColXxl10 = Xxl | Col10,
    Col11 = 1 << 16,
    ColSm11 = Sm | Col11,
    ColMd11 = Md | Col11,
    ColLg11 = Lg | Col11,
    ColXl11 = Xl | Col11,
    ColXxl11 = Xxl | Col11,
    Col12 = 1 << 17,
    ColSm12 = Sm | Col12,
    ColMd12 = Md | Col12,
    ColLg12 = Lg | Col12,
    ColXl12 = Xl | Col12,
    ColXxl12 = Xxl | Col12,
    ColAuto = 1 << 18,
    ColSmAuto = Sm | ColAuto,
    ColMdAuto = Md | ColAuto,
    ColLgAuto = Lg | ColAuto,
    ColXlAuto = Xl | ColAuto,
    ColXxlAuto = Xxl | ColAuto,
}

internal static class ColumnOptsExtensions
{
    internal static string ToBootstrapColClass(this BsColumnOptions breakpoint)
    {
        var classString = "col";
        classString += breakpoint.SizeClass();
        classString += breakpoint.ColumnWidth();
        return classString;
    }

    internal static string ToBootstrapOffsetClass(this BsColumnOptions breakpoint)
    {
        var classString = "";
        if (breakpoint == BsColumnOptions.None)
        {
            return classString;
        }

        classString = "offset";
        classString += breakpoint.SizeClass();
        classString += breakpoint.ColumnWidth();
        return classString;
    }

    private static string SizeClass(this BsColumnOptions breakpoint)
    {
        if (breakpoint.HasFlag(BsColumnOptions.Sm))
        {
            return "-sm";
        }

        if (breakpoint.HasFlag(BsColumnOptions.Md))
        {
            return "-md";
        }

        if (breakpoint.HasFlag(BsColumnOptions.Lg))
        {
            return "-lg";
        }

        if (breakpoint.HasFlag(BsColumnOptions.Xl))
        {
            return "-xl";
        }

        return breakpoint.HasFlag(BsColumnOptions.Xxl) ? "-xxl" : "";
    }

    private static string ColumnWidth(this BsColumnOptions breakpoint)
    {
        if (breakpoint.HasFlag(BsColumnOptions.Col1))
        {
            return "-1";
        }

        if (breakpoint.HasFlag(BsColumnOptions.Col2))
        {
            return "-2";
        }

        if (breakpoint.HasFlag(BsColumnOptions.Col3))
        {
            return "-3";
        }

        if (breakpoint.HasFlag(BsColumnOptions.Col4))
        {
            return "-4";
        }

        if (breakpoint.HasFlag(BsColumnOptions.Col5))
        {
            return "-5";
        }

        if (breakpoint.HasFlag(BsColumnOptions.Col6))
        {
            return "-6";
        }

        if (breakpoint.HasFlag(BsColumnOptions.Col7))
        {
            return "-7";
        }

        if (breakpoint.HasFlag(BsColumnOptions.Col8))
        {
            return "-8";
        }

        if (breakpoint.HasFlag(BsColumnOptions.Col9))
        {
            return "-9";
        }

        if (breakpoint.HasFlag(BsColumnOptions.Col10))
        {
            return "-10";
        }

        if (breakpoint.HasFlag(BsColumnOptions.Col11))
        {
            return "-11";
        }

        if (breakpoint.HasFlag(BsColumnOptions.Col12))
        {
            return "-12";
        }

        if (breakpoint.HasFlag(BsColumnOptions.ColAuto))
        {
            return "-auto";
        }

        return "";
    }
}
