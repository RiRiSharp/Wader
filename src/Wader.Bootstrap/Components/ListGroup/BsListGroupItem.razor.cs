using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.Components.ListGroup;

public partial class BsListGroupItem : BsChildContentComponent
{
    protected override string? BsComponentClasses =>
        $"list-group-item {TypeActionClass} {VariantClass} {ActiveClass} {DisabledClass}";

    /// <summary>
    ///     Decides what html-tag should be used for drawing this component.
    /// </summary>
    /// <remark>
    ///     Has a different name because button also has a type tag, and those two cannot coexist.
    ///     Also adds the `list-group-item-action` class to the element to give a :hover-background.
    /// </remark>
    [Parameter]
    public BsListGroupItemType ElType { get; set; }

    public string? TypeActionClass => ElType == BsListGroupItemType.ListItem ? null : "list-group-item-action";

    [Parameter]
    public BsListGroupItemVariant Variant { get; set; }

    private string? VariantClass => Variant.ToBootstrapClass();

    [Parameter]
    public bool Active { get; set; }

    private string? ActiveClass => Active ? "active" : null;

    [Parameter]
    public bool Disabled { get; set; }

    private string? DisabledClass => Disabled ? "disabled" : null;
}
