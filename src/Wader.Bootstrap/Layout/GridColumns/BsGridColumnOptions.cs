namespace Wader.Bootstrap.Layout.GridColumns;

[Flags]
public enum BsGridColumnOptions : long
{
    None = 0,
    Sm = 1 << 1,
    Md = 1 << 2,
    Lg = 1 << 3,
    Xl = 1 << 4,
    Xxl = 1 << 5,

    GCol1 = 1 << 6,

    GColSm1 = Sm | GCol1,

    GColMd1 = Md | GCol1,

    GColLg1 = Lg | GCol1,

    GColXl1 = Xl | GCol1,

    GColXxl1 = Xxl | GCol1,
    GCol2 = 1 << 7,
    GColSm2 = Sm | GCol2,
    GColMd2 = Md | GCol2,
    GColLg2 = Lg | GCol2,
    GColXl2 = Xl | GCol2,
    GColXxl2 = Xxl | GCol2,
    GCol3 = 1 << 8,
    GColSm3 = Sm | GCol3,
    GColMd3 = Md | GCol3,
    GColLg3 = Lg | GCol3,
    GColXl3 = Xl | GCol3,
    GColXxl3 = Xxl | GCol3,
    GCol4 = 1 << 9,
    GColSm4 = Sm | GCol4,
    GColMd4 = Md | GCol4,
    GColLg4 = Lg | GCol4,
    GColXl4 = Xl | GCol4,
    GColXxl4 = Xxl | GCol4,
    GCol5 = 1 << 10,
    GColSm5 = Sm | GCol5,
    GColMd5 = Md | GCol5,
    GColLg5 = Lg | GCol5,
    GColXl5 = Xl | GCol5,
    GColXxl5 = Xxl | GCol5,
    GCol6 = 1 << 11,
    GColSm6 = Sm | GCol6,
    GColMd6 = Md | GCol6,
    GColLg6 = Lg | GCol6,
    GColXl6 = Xl | GCol6,
    GColXxl6 = Xxl | GCol6,
    GCol7 = 1 << 12,
    GColSm7 = Sm | GCol7,
    GColMd7 = Md | GCol7,
    GColLg7 = Lg | GCol7,
    GColXl7 = Xl | GCol7,
    GColXxl7 = Xxl | GCol7,
    GCol8 = 1 << 13,
    GColSm8 = Sm | GCol8,
    GColMd8 = Md | GCol8,
    GColLg8 = Lg | GCol8,
    GColXl8 = Xl | GCol8,
    GColXxl8 = Xxl | GCol8,
    GCol9 = 1 << 14,
    GColSm9 = Sm | GCol9,
    GColMd9 = Md | GCol9,
    GColLg9 = Lg | GCol9,
    GColXl9 = Xl | GCol9,
    GColXxl9 = Xxl | GCol9,
    GCol10 = 1 << 15,
    GColSm10 = Sm | GCol10,
    GColMd10 = Md | GCol10,
    GColLg10 = Lg | GCol10,
    GColXl10 = Xl | GCol10,
    GColXxl10 = Xxl | GCol10,
    GCol11 = 1 << 16,
    GColSm11 = Sm | GCol11,
    GColMd11 = Md | GCol11,
    GColLg11 = Lg | GCol11,
    GColXl11 = Xl | GCol11,
    GColXxl11 = Xxl | GCol11,
    GCol12 = 1 << 17,
    GColSm12 = Sm | GCol12,
    GColMd12 = Md | GCol12,
    GColLg12 = Lg | GCol12,
    GColXl12 = Xl | GCol12,
    GColXxl12 = Xxl | GCol12,
    GColAuto = 1 << 18,
    GColSmAuto = Sm | GColAuto,
    GColMdAuto = Md | GColAuto,
    GColLgAuto = Lg | GColAuto,
    GColXlAuto = Xl | GColAuto,
    GColXxlAuto = Xxl | GColAuto,
}

internal static class GridColumnOptionsExtensions
{
    internal static string ToBootstrapClass(this BsGridColumnOptions gridColumnOptions)
    {
        if (gridColumnOptions == BsGridColumnOptions.None)
        {
            return "";
        }

        var classString = "g-col";
        classString += gridColumnOptions.SizeClass();
        classString += gridColumnOptions.ColumnWidth();
        return classString;
    }

    private static string SizeClass(this BsGridColumnOptions gridColumnOptions)
    {
        if (gridColumnOptions.HasFlag(BsGridColumnOptions.Sm))
        {
            return "-sm";
        }

        if (gridColumnOptions.HasFlag(BsGridColumnOptions.Md))
        {
            return "-md";
        }

        if (gridColumnOptions.HasFlag(BsGridColumnOptions.Lg))
        {
            return "-lg";
        }

        if (gridColumnOptions.HasFlag(BsGridColumnOptions.Xl))
        {
            return "-xl";
        }

        return gridColumnOptions.HasFlag(BsGridColumnOptions.Xxl) ? "-xxl" : "";
    }

    private static string ColumnWidth(this BsGridColumnOptions gridColumnOptions)
    {
        if (gridColumnOptions.HasFlag(BsGridColumnOptions.GCol1))
        {
            return "-1";
        }

        if (gridColumnOptions.HasFlag(BsGridColumnOptions.GCol2))
        {
            return "-2";
        }

        if (gridColumnOptions.HasFlag(BsGridColumnOptions.GCol3))
        {
            return "-3";
        }

        if (gridColumnOptions.HasFlag(BsGridColumnOptions.GCol4))
        {
            return "-4";
        }

        if (gridColumnOptions.HasFlag(BsGridColumnOptions.GCol5))
        {
            return "-5";
        }

        if (gridColumnOptions.HasFlag(BsGridColumnOptions.GCol6))
        {
            return "-6";
        }

        if (gridColumnOptions.HasFlag(BsGridColumnOptions.GCol7))
        {
            return "-7";
        }

        if (gridColumnOptions.HasFlag(BsGridColumnOptions.GCol8))
        {
            return "-8";
        }

        if (gridColumnOptions.HasFlag(BsGridColumnOptions.GCol9))
        {
            return "-9";
        }

        if (gridColumnOptions.HasFlag(BsGridColumnOptions.GCol10))
        {
            return "-10";
        }

        if (gridColumnOptions.HasFlag(BsGridColumnOptions.GCol11))
        {
            return "-11";
        }

        if (gridColumnOptions.HasFlag(BsGridColumnOptions.GCol12))
        {
            return "-12";
        }

        if (gridColumnOptions.HasFlag(BsGridColumnOptions.GColAuto))
        {
            return "-auto";
        }

        return "";
    }
}
