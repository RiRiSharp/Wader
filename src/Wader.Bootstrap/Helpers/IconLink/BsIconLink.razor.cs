using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;

namespace Wader.Bootstrap.Helpers.IconLink;

public partial class BsIconLink : BsChildContentComponent
{
    protected override string BsComponentClasses => $"icon-link {AnimateClass}";

    [Parameter]
    public bool HoverAnimate { get; set; }

    public string? AnimateClass => HoverAnimate ? "icon-link-hover" : null;
}
