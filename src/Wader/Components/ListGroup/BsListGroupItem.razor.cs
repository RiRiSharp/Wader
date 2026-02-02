using Microsoft.AspNetCore.Components;
using Wader.BaseComponents;

namespace Wader.Components.ListGroup;

public partial class BsListGroupItem : BsChildContentComponent
{
    protected override string BsComponentClasses => $"list-group-item {VariantClass} {ActiveClass} {DisabledClass}";

    /// <summary>
    /// Decides what html-tag should be used for drawing this component.
    /// </summary>
    /// <remark>
    /// Has a different name because button also has a type tag, and those two cannot coexist.
    /// </remark>
    [Parameter]
    public BsListGroupItemType ItemType { get; set; }

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
