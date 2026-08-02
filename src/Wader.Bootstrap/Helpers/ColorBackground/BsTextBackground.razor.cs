using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;
using Wader.Bootstrap.Internal.Primitives;

namespace Wader.Bootstrap.Helpers.ColorBackground;

public partial class BsTextBackground : BsChildContentComponent
{
    protected override string BsComponentClasses => Variant.ToTextBackgroundClass();

    [Parameter]
    public BsColor Variant { get; set; }
}
