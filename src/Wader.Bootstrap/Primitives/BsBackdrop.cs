namespace Wader.Bootstrap.Primitives;

public enum BsBackdrop
{
    Regular = 0,
    Static = 1,
    None = 2,
}

internal static class BsBackdropExtensions
{
    internal static string? ToDataBsBackdropValue(this BsBackdrop backdrop)
    {
        return backdrop switch
        {
            BsBackdrop.Regular => null,
            BsBackdrop.Static => "static",
            BsBackdrop.None => "false",
            _ => throw new ArgumentOutOfRangeException(nameof(backdrop), backdrop, null),
        };
    }

    internal static string? ToDataBsKeyboardValue(this BsBackdrop backdrop)
    {
        return backdrop switch
        {
            BsBackdrop.Regular => null,
            BsBackdrop.Static => "false",
            BsBackdrop.None => null,
            _ => throw new ArgumentOutOfRangeException(nameof(backdrop), backdrop, null),
        };
    }
}
