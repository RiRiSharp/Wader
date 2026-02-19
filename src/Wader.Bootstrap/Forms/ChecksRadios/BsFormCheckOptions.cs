namespace Wader.Bootstrap.Forms.ChecksRadios;

public enum BsFormCheckOptions
{
    Stacked = 0,
    Inline = 1,
    Reverse = 2,
}

internal static class BsFormCheckOptionsExtensions
{
    internal static string? ToBootstrapClass(this BsFormCheckOptions formCheckOptions)
    {
        return formCheckOptions switch
        {
            BsFormCheckOptions.Stacked => null,
            BsFormCheckOptions.Inline => "form-check-inline",
            BsFormCheckOptions.Reverse => "form-check-reverse",
            _ => throw new ArgumentOutOfRangeException(nameof(formCheckOptions)),
        };
    }
}
