namespace Wader.Bootstrap.Components.Buttons;

public enum BsButtonSize
{
    Regular = 0,
    Small = 1,
    Large = 2,
}

internal static class BsButtonSizeExtensions
{
    internal static string? ToBootstrapClass(this BsButtonSize size)
    {
        return size switch
        {
            BsButtonSize.Regular => null,
            BsButtonSize.Small => "btn-sm",
            BsButtonSize.Large => "btn-lg",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null),
        };
    }
}
