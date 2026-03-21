namespace Wader.Bootstrap.Components.Placeholders;

public enum BsPlaceholderSize
{
    ExtraSmall = 0,
    Small = 1,
    Regular = 2,
    Large = 3,
}

public static class BsPlaceholderSizeExtensions
{
    public static string? ToBootstrapClass(this BsPlaceholderSize size)
    {
        return size switch
        {
            BsPlaceholderSize.ExtraSmall => "placeholder-xs",
            BsPlaceholderSize.Small => "placeholder-sm",
            BsPlaceholderSize.Regular => null,
            BsPlaceholderSize.Large => "placeholder-lg",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null),
        };
    }
}
