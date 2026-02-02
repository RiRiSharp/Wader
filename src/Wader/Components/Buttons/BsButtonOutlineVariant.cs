namespace Wader.Components.Buttons;

public enum BsButtonOutlineVariant
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

internal static class BsButtonOutlineVariantExtensions
{
    internal static string? ToBootstrapClass(this BsButtonOutlineVariant variant)
    {
        return variant switch
        {
            BsButtonOutlineVariant.Primary => "btn-outline-primary",
            BsButtonOutlineVariant.Secondary => "btn-outline-secondary",
            BsButtonOutlineVariant.Success => "btn-outline-success",
            BsButtonOutlineVariant.Danger => "btn-outline-danger",
            BsButtonOutlineVariant.Warning => "btn-outline-warning",
            BsButtonOutlineVariant.Info => "btn-outline-info",
            BsButtonOutlineVariant.Light => "btn-outline-light",
            BsButtonOutlineVariant.Dark => "btn-outline-dark",
            _ => throw new ArgumentOutOfRangeException(nameof(variant), variant, null),
        };
    }
}
