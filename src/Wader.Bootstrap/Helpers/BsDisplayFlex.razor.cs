using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;

namespace Wader.Bootstrap.Helpers;

public partial class BsDisplayFlex : BsChildContentComponent
{
    protected override string? BsComponentClasses => $"d-flex {Justify.ToBootstrapClass()}";

    [Parameter]
    public BsJustify Justify { get; set; }
}
