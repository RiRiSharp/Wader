namespace Wader.Bootstrap.Content.Tables;

public enum BsTableBreakpoint
{
    Default = 0,
    Sm = 1,
    Md = 2,
    Lg = 3,
    Xl = 4,
    Xxl = 5,
}

internal static class TableResponsivenessExtensions
{
    internal static string ToBootstrapClass(this BsTableBreakpoint tableBreakpoint)
    {
        return tableBreakpoint switch
        {
            BsTableBreakpoint.Default => "table-responsive",
            BsTableBreakpoint.Sm => "table-responsive-sm",
            BsTableBreakpoint.Md => "table-responsive-md",
            BsTableBreakpoint.Lg => "table-responsive-lg",
            BsTableBreakpoint.Xl => "table-responsive-xl",
            BsTableBreakpoint.Xxl => "table-responsive-xxl",
            _ => throw new ArgumentOutOfRangeException(nameof(tableBreakpoint), tableBreakpoint, null),
        };
    }
}
