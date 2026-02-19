namespace Wader.Bootstrap.Components.Buttons;

public enum BsButtonVariant
{
    Primary = 0,
    Secondary = 1,
    Success = 2,
    Danger = 3,
    Warning = 4,
    Info = 5,
    Light = 6,
    Dark = 7,
    Link = 8,
}

internal static class BsButtonVariantExtensions
{
    internal static string? ToBootstrapClass(this BsButtonVariant variant)
    {
        return variant switch
        {
            BsButtonVariant.Primary => "btn-primary",
            BsButtonVariant.Secondary => "btn-secondary",
            BsButtonVariant.Success => "btn-success",
            BsButtonVariant.Danger => "btn-danger",
            BsButtonVariant.Warning => "btn-warning",
            BsButtonVariant.Info => "btn-info",
            BsButtonVariant.Light => "btn-light",
            BsButtonVariant.Dark => "btn-dark",
            BsButtonVariant.Link => "btn-link",
            _ => throw new ArgumentOutOfRangeException(nameof(variant), variant, null),
        };
    }
}
