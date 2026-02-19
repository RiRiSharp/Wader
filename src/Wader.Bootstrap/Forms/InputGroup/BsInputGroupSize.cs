namespace Wader.Bootstrap.Forms.InputGroup;

public enum BsInputGroupSize
{
    Regular = 0,
    Small = 1,
    Large = 2,
}

internal static class InputGroupSizeExtensions
{
    internal static string? ToBootstrapClass(this BsInputGroupSize size)
    {
        return size switch
        {
            BsInputGroupSize.Regular => null,
            BsInputGroupSize.Small => "input-group-sm",
            BsInputGroupSize.Large => "input-group-lg",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null),
        };
    }
}
