namespace Wader.Bootstrap.Helpers.ColoredLinks;

public enum BsLinkVariant
{
    Primary = 0,
    Secondary = 1,
    Success = 2,
    Info = 3,
    Warning = 4,
    Danger = 5,
    Light = 6,
    Dark = 7,
    Emphasis = 8,
}

public static class BsLinkVariantExtensions
{
    internal static string ToBootstrapClass(this BsLinkVariant variant)
    {
        return variant switch
        {
            BsLinkVariant.Primary => "link-primary",
            BsLinkVariant.Secondary => "link-secondary",
            BsLinkVariant.Success => "link-success",
            BsLinkVariant.Info => "link-info",
            BsLinkVariant.Warning => "link-warning",
            BsLinkVariant.Danger => "link-danger",
            BsLinkVariant.Light => "link-light",
            BsLinkVariant.Dark => "link-dark",
            BsLinkVariant.Emphasis => "link-body-emphasis",
            _ => throw new ArgumentOutOfRangeException(nameof(variant), variant, null),
        };
    }
}
