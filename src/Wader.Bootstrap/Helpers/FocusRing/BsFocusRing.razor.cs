using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;
using Wader.Bootstrap.Internal.Primitives;

namespace Wader.Bootstrap.Helpers.FocusRing;

public partial class BsFocusRing : BsChildContentComponent
{
    protected override string BsComponentClasses => $"focus-ring {Variant?.ToFocusRingClass()}";

    [Parameter]
    public BsColor? Variant { get; set; }
}
