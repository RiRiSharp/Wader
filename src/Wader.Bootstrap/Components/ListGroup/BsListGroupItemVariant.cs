namespace Wader.Bootstrap.Components.ListGroup;

public enum BsListGroupItemVariant
{
    None = 0,
    Primary = 1,
    Secondary = 2,
    Success = 3,
    Danger = 4,
    Warning = 5,
    Info = 6,
    Light = 7,
    Dark = 8,
}

internal static class BsListGroupItemVariantExtensions
{
    internal static string? ToBootstrapClass(this BsListGroupItemVariant variant)
    {
        return variant switch
        {
            BsListGroupItemVariant.None => null,
            BsListGroupItemVariant.Primary => "list-group-item-primary",
            BsListGroupItemVariant.Secondary => "list-group-item-secondary",
            BsListGroupItemVariant.Success => "list-group-item-success",
            BsListGroupItemVariant.Danger => "list-group-item-danger",
            BsListGroupItemVariant.Warning => "list-group-item-warning",
            BsListGroupItemVariant.Info => "list-group-item-info",
            BsListGroupItemVariant.Light => "list-group-item-light",
            BsListGroupItemVariant.Dark => "list-group-item-dark",
            _ => throw new ArgumentOutOfRangeException(nameof(variant), variant, null),
        };
    }
}
