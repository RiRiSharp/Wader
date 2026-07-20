using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.Components.Tooltips;

public partial class BsTooltip : BsChildContentComponent
{
    private ElementReference _contentRef;
    protected override string? BsComponentClasses => null;

    [Parameter]
    public RenderFragment? BsTooltipContent { get; set; }

    [Parameter]
    public BsTooltipOptions Options { get; set; } = new();

    /// <summary>
    ///     Overrides the host element used to initialize the Bootstrap popover.
    ///     If not supplied, the component's wrapper element is used.
    /// </summary>
    [Parameter]
    public ElementReference? Attachment { get; set; }
}
