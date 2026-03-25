using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Components.Popover.Internals;
using Wader.Bootstrap.Primitives;

namespace Wader.Bootstrap.Components.Popover;

public partial class BsPopover : ComponentBase
{
    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public RenderFragment? Content { get; set; }

    [Parameter]
    public BsDirection Direction { get; set; }

    [Inject]
    public IBsPopoverJsFunctions BsPopoverJsFunctions { get; set; } = null!;
}
