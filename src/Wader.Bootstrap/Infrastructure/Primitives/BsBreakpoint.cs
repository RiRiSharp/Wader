namespace Wader.Bootstrap.Infrastructure.Primitives;

public enum BsBreakpoint
{
    /// <summary>
    ///     Default breakpoint, usually invisible because of "mobile first"
    /// </summary>
    ExtraSmall = 0,
    Small = 1,
    Medium = 2,
    Large = 3,
    ExtraLarge = 4,
    ExtraExtraLarge = 5,
}

public static class BsBreakpointExtensions
{
    public static string? ToBootstrapClass(this BsBreakpoint breakpoint)
    {
        return breakpoint switch
        {
            BsBreakpoint.ExtraSmall => null,
            BsBreakpoint.Small => "sm",
            BsBreakpoint.Medium => "md",
            BsBreakpoint.Large => "lg",
            BsBreakpoint.ExtraLarge => "xl",
            BsBreakpoint.ExtraExtraLarge => "xxl",
            _ => throw new ArgumentOutOfRangeException(nameof(breakpoint), breakpoint, null),
        };
    }

    public static string ToBootstrapSuffix(this BsBreakpoint breakpoint)
    {
        var breakpointClass = breakpoint.ToBootstrapClass();
        return breakpointClass is null ? "" : $"-{breakpointClass}";
    }

    public static string ToBootstrapContainerClass(this BsBreakpoint breakpoint)
    {
        return $"container{breakpoint.ToBootstrapSuffix()}";
    }
}
