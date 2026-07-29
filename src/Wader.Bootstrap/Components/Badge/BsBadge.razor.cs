using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;
using Wader.Bootstrap.Internal.Primitives;

namespace Wader.Bootstrap.Components.Badge;

public partial class BsBadge : BsChildContentComponent
{
    protected override string BsComponentClasses => $"badge {PillShapeClass} {Variant.ToTextBackgroundClass()}";

    [Parameter]
    public bool PillShape { get; set; }

    private string? PillShapeClass => PillShape ? "rounded-pill" : null;

    [Parameter]
    public BsColor Variant { get; set; } = BsColor.Secondary;
}
