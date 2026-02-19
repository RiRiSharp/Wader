namespace Wader.Bootstrap.Components.Alert;

public enum BsAlertVariant
{
    Primary = 0,
    Secondary = 1,
    Success = 2,
    Danger = 3,
    Warning = 4,
    Info = 5,
    Light = 6,
    Dark = 7,
}

internal static class BsAlertVariantExtensions
{
    internal static string ToBootstrapClass(this BsAlertVariant variant)
    {
        return variant switch
        {
            BsAlertVariant.Primary => "alert-primary",
            BsAlertVariant.Secondary => "alert-secondary",
            BsAlertVariant.Success => "alert-success",
            BsAlertVariant.Danger => "alert-danger",
            BsAlertVariant.Warning => "alert-warning",
            BsAlertVariant.Info => "alert-info",
            BsAlertVariant.Light => "alert-light",
            BsAlertVariant.Dark => "alert-dark",
            _ => throw new ArgumentOutOfRangeException(nameof(variant), variant, null),
        };
    }
}
