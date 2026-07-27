using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Infrastructure.BaseComponents;

namespace Wader.Bootstrap.Helpers;

public partial class BsDisplayFlex : BsChildContentComponent
{
    protected override string? BsComponentClasses => $"d-flex {Justify.ToBootstrapClass()}";

    [Parameter]
    public BsJustification Justify { get; set; }
}
