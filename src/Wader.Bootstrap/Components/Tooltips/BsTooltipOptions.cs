using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Components.Popover;

namespace Wader.Bootstrap.Components.Tooltips;

/// <summary>
///     The options, including defaults, to display a Tooltip.
/// </summary>
/// <remarks>Looks awfully similar to <see cref="Scrollspy.ScrollspyJsOptions" />, might change in the future.</remarks>
public class BsTooltipOptions
{
    public bool Animation { get; set; } = true;
    public ElementReference? Boundary { get; set; }
    public string? ContainerString { get; set; }
    public ElementReference? ContainerRef { get; set; }
    public string? CustomClass { get; set; }
    public int ShowDelay { get; set; }
    public int HideDelay { get; set; }

    /// <summary>
    ///     A list of placements in order of preference.
    /// </summary>
    /// <remarks>
    ///     Order matters, that's why we use a collection here.
    /// </remarks>
    public ICollection<BsPopoverPlacement> FallbackPlacements { get; } = [];

    public int Skidding { get; set; } = 8;
    public int Distance { get; set; }
    public BsPopoverPlacement Placement { get; set; } = BsPopoverPlacement.Top;
    public BsPopoverTrigger Trigger { get; set; } = BsPopoverTrigger.Hover | BsPopoverTrigger.Focus;
}
