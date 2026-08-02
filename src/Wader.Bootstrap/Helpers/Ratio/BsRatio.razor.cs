using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;

namespace Wader.Bootstrap.Helpers.Ratio;

public partial class BsVstack : BsChildContentComponent
{
    protected override string BsComponentClasses => $"ratio {Variant?.ToBootstrapClass()}";

    [Parameter]
    public BsRatioVariant? Variant { get; set; }
}
