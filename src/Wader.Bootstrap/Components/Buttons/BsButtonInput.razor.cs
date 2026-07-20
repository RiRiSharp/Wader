using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.Components.Buttons;

public partial class BsButtonInput : BsComponent
{
    protected override string? BsComponentClasses => $"btn {Variant.ToBootstrapClass()} {Size.ToBootstrapClass()}";

    [Parameter]
    public string? Content { get; set; }

    [Parameter]
    public BsButtonVariant Variant { get; set; } = BsButtonVariant.Primary;

    [Parameter]
    public BsButtonSize Size { get; set; }
}
