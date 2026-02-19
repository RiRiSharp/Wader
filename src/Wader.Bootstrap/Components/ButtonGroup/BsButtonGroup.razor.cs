using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.Components.ButtonGroup;

public partial class BsButtonGroup : BsChildContentComponent
{
    protected override string BsComponentClasses => $"btn-group {Size.ToBootstrapClass()}";

    [Parameter]
    public BsButtonGroupSize Size { get; set; }
}
