using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Helpers;
using Wader.Bootstrap.Internal.BaseComponents;

namespace Wader.Bootstrap.Utilities.Flex;

public partial class BsDisplayFlex : BsChildContentComponent
{
    protected override string BsComponentClasses => $"d-flex {Justify.ToBootstrapClass()}";

    [Parameter]
    public BsJustify Justify { get; set; }
}
