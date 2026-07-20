using System.Text;
using Wader.Bootstrap.Infrastructure.Exceptions;

namespace Wader.Bootstrap.Content.Tables;

[Flags]
public enum BsTableOptions : long
{
    None = 0,

    TablePrimary = 1 << 0,
    TableSecondary = 1 << 1,
    TableSuccess = 1 << 2,
    TableDanger = 1 << 3,
    TableWarning = 1 << 4,
    TableInfo = 1 << 5,
    TableLight = 1 << 6,
    TableDark = 1 << 7,

    TableStriped = 1 << 8,
    TableStripedColumns = 1 << 9,

    TableHover = 1 << 10,

    TableBordered = 1 << 11,

    TableBorderless = 1 << 12,
    BorderPrimary = 1 << 13,
    BorderSecondary = 1 << 14,
    BorderSuccess = 1 << 15,
    BorderDanger = 1 << 16,
    BorderWarning = 1 << 17,
    BorderInfo = 1 << 18,
    BorderLight = 1 << 19,
    BorderDark = 1 << 20,

    TableSmall = 1 << 21,

    CaptionTop = 1 << 22,

    TableActive = 1 << 23,
}

internal static class TableOptionsExtensions
{
    private const BsTableOptions COLOR_MASK =
        BsTableOptions.TablePrimary
        | BsTableOptions.TableSecondary
        | BsTableOptions.TableSuccess
        | BsTableOptions.TableDanger
        | BsTableOptions.TableWarning
        | BsTableOptions.TableInfo
        | BsTableOptions.TableLight
        | BsTableOptions.TableDark;

    private const BsTableOptions STRIPED_MASK = BsTableOptions.TableStriped | BsTableOptions.TableStripedColumns;

    private const BsTableOptions TABLE_BORDER_MASK = BsTableOptions.TableBordered | BsTableOptions.TableBorderless;

    private const BsTableOptions BORDER_COLOR_MASK =
        BsTableOptions.TableBorderless
        | BsTableOptions.BorderPrimary
        | BsTableOptions.BorderSecondary
        | BsTableOptions.BorderSuccess
        | BsTableOptions.BorderDanger
        | BsTableOptions.BorderWarning
        | BsTableOptions.BorderInfo
        | BsTableOptions.BorderLight
        | BsTableOptions.BorderDark;

    /// <summary>
    ///     For table everything is an allowable option, except table active
    /// </summary>
    private const BsTableOptions TABLE_MASK = ~BsTableOptions.TableActive;

    private const BsTableOptions ROW_MASK =
        BsTableOptions.TablePrimary
        | BsTableOptions.TableSecondary
        | BsTableOptions.TableSuccess
        | BsTableOptions.TableDanger
        | BsTableOptions.TableWarning
        | BsTableOptions.TableInfo
        | BsTableOptions.TableLight
        | BsTableOptions.TableDark
        | BsTableOptions.TableActive;

    private const BsTableOptions TABLE_HEAD_MASK =
        BsTableOptions.TablePrimary
        | BsTableOptions.TableSecondary
        | BsTableOptions.TableSuccess
        | BsTableOptions.TableDanger
        | BsTableOptions.TableWarning
        | BsTableOptions.TableInfo
        | BsTableOptions.TableLight
        | BsTableOptions.TableDark;

    private static readonly Dictionary<BsTableOptions, string> _classMapping = new()
    {
        { BsTableOptions.TablePrimary, "table-primary" },
        { BsTableOptions.TableSecondary, "table-secondary" },
        { BsTableOptions.TableSuccess, "table-success" },
        { BsTableOptions.TableDanger, "table-danger" },
        { BsTableOptions.TableWarning, "table-warning" },
        { BsTableOptions.TableInfo, "table-info" },
        { BsTableOptions.TableLight, "table-light" },
        { BsTableOptions.TableDark, "table-dark" },
        { BsTableOptions.TableStriped, "table-striped" },
        { BsTableOptions.TableStripedColumns, "table-striped-columns" },
        { BsTableOptions.TableHover, "table-hover" },
        { BsTableOptions.TableBordered, "table-bordered" },
        { BsTableOptions.TableBorderless, "table-borderless" },
        { BsTableOptions.BorderPrimary, "border-primary" },
        { BsTableOptions.BorderSecondary, "border-secondary" },
        { BsTableOptions.BorderSuccess, "border-success" },
        { BsTableOptions.BorderDanger, "border-danger" },
        { BsTableOptions.BorderWarning, "border-warning" },
        { BsTableOptions.BorderInfo, "border-info" },
        { BsTableOptions.BorderLight, "border-light" },
        { BsTableOptions.BorderDark, "border-dark" },
        { BsTableOptions.TableSmall, "table-sm" },
        { BsTableOptions.CaptionTop, "caption-top" },
    };

    internal static string ToBootstrapTableClass(this BsTableOptions options)
    {
        var relevantTableOptions = options & TABLE_MASK;
        relevantTableOptions.ValidateIllegalCombinations();

        return options.BuildBootstrapClassInner();
    }

    internal static string ToBootstrapRowOrDataClass(this BsTableOptions options)
    {
        var relevantRowOptions = options & ROW_MASK;
        relevantRowOptions.ValidateIllegalCombinations();

        return options.BuildBootstrapClassInner();
    }

    internal static string ToBootstrapTableHeadClass(this BsTableOptions options)
    {
        var relevantTableHeadOptions = options & TABLE_HEAD_MASK;
        relevantTableHeadOptions.ValidateIllegalCombinations();

        return options.BuildBootstrapClassInner();
    }

    private static void ValidateIllegalCombinations(this BsTableOptions tableOptions)
    {
        var isValid =
            tableOptions.HasZeroOrOneBitsSetInMask(COLOR_MASK)
            && tableOptions.HasZeroOrOneBitsSetInMask(STRIPED_MASK)
            && tableOptions.HasZeroOrOneBitsSetInMask(TABLE_BORDER_MASK)
            && tableOptions.HasZeroOrOneBitsSetInMask(BORDER_COLOR_MASK);
        if (!isValid)
        {
            throw new BsInvalidTableOptionsException();
        }
    }

    private static string BuildBootstrapClassInner(this BsTableOptions tableOptions)
    {
        var returnClass = new StringBuilder();

        foreach (var entry in _classMapping)
        {
            if (tableOptions.HasFlag(entry.Key))
            {
                _ = returnClass.Append(' ').Append(entry.Value);
            }
        }

        return returnClass.ToString();
    }

    private static bool HasZeroOrOneBitsSetInMask(this BsTableOptions tableOptions, BsTableOptions mask)
    {
        var relevantPart = tableOptions & mask;
        return relevantPart == 0 || (relevantPart & (relevantPart - 1)) == 0;
    }
}
