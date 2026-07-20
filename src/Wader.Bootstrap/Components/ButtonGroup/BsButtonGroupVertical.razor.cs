using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.Components.ButtonGroup;

public partial class BsButtonGroupVertical : BsChildContentComponent
{
    protected override string? BsComponentClasses => $"btn-group-vertical {Size.ToBootstrapClass()}";

    [Parameter]
    public BsButtonGroupSize Size { get; set; }
}
