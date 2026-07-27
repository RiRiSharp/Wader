using Wader.Bootstrap.Components.Popover;

namespace Wader.Bootstrap.Components.Tooltip.Internals;

internal class BsTooltipSerializedOptions
{
    public Dictionary<string, string[]>? AllowList { get; set; }
    public bool? Animation { get; set; }
    public object? Boundary { get; set; }
    public object? Container { get; set; }
    public string? CustomClass { get; set; }
    public object? Delay { get; set; }
    public object? FallbackPlacements { get; set; }
    public bool? Html { get; set; }
    public object? Offset { get; set; }
    public BsPopoverPlacement? Placement { get; set; }
    public string? PopperConfig { get; set; }
    public bool? Sanitize { get; set; }
    public object? Selector { get; set; }
    public string? Template { get; set; }
    public object? Title { get; set; }
    public object? Trigger { get; set; }
}
