namespace Wader.Bootstrap.Forms;

public enum BsFormSize
{
    Regular = 0,
    Small = 1,
    Large = 2,
}

internal static class FormSizeExtensions
{
    internal static string? ToBootstrapClass(this BsFormSize formSize)
    {
        return formSize switch
        {
            BsFormSize.Regular => null,
            BsFormSize.Small => "form-control-sm",
            BsFormSize.Large => "form-control-lg",
            _ => throw new ArgumentOutOfRangeException(nameof(formSize), formSize, null),
        };
    }
}
