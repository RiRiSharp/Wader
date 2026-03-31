using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.Components.Popover;

public class BsPopoverOptions
{
    public bool Animation { get; set; } = true;
    public ElementReference? Boundary { get; set; }
    public string? ContainerString { get; set; }
    public ElementReference? ContainerRef { get; set; }
    public string? CustomClass { get; set; }
    public int ShowDelay { get; set; }
    public int HideDelay { get; set; }
    public ICollection<BsPopoverPlacement> FallbackPlacements { get; } = [];
    public int Skidding { get; set; } = 8;
    public int Distance { get; set; }
    public BsPopoverPlacement Placement { get; set; } = BsPopoverPlacement.Right;
    public BsPopoverTrigger Trigger { get; set; } = BsPopoverTrigger.Click;
}
