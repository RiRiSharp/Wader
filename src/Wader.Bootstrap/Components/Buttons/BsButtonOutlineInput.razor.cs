using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;

namespace Wader.Bootstrap.Components.Buttons;

public partial class BsButtonOutlineInput : BsComponent
{
    protected override string? BsComponentClasses => $"btn {Variant.ToBootstrapClass()} {Size.ToBootstrapClass()}";

    [Parameter]
    public string? Content { get; set; }

    [Parameter]
    public BsButtonOutlineVariant Variant { get; set; }

    [Parameter]
    public BsButtonSize Size { get; set; }
}
