using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.Components.Popover.Internals;

public class PopoverJsOptions
{
    public bool Animation { get; set; }
    public ElementReference? Boundary { get; set; }
    public string? ContainerString { get; set; }
    public ElementReference? ContainerRef { get; set; }
    public ElementReference? ContentRef { get; set; }
    public required string CustomClass { get; set; }
    public PopoverDelayOptions? Delay { get; set; }
    public ICollection<string> FallbackPlacements { get; } = [];
    public bool Html { get; set; }
    public ICollection<int> Offset { get; } = [];
    public required string Placement { get; set; }
    public bool Sanitize { get; set; }
    public ElementReference? TitleRef { get; set; }
    public required string Trigger { get; set; }
}
