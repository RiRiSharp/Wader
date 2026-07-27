using System.Diagnostics.CodeAnalysis;
using Wader.Bootstrap.Components.Popover;
using Wader.Bootstrap.Infrastructure.JsInterop.Unions;

namespace Wader.Bootstrap.Components.Tooltip;

/// <summary>
///     The options, including defaults, to display a Tooltip.
/// </summary>
/// <remarks>Looks awfully similar to <see cref="Scrollspy.ScrollspyJsOptions" />, might change in the future.</remarks>
public class BsTooltipOptions
{
    public Dictionary<string, string[]>? AllowList { get; set; }
    public bool? Animation { get; set; }
    public HtmlStringOrElementRef? Boundary { get; set; }
    public HtmlStringElementRefOrBool? Container { get; set; }
    public string? CustomClass { get; set; }
    public Union<int, BsPopoverDelayJsOptions>? Delay { get; set; }
    public OneOrMore<BsPopoverPlacement>? FallbackPlacements { get; set; }
    public OneOrMore<int>? Offset { get; set; }
    public BsPopoverPlacement? Placement { get; set; }

    [StringSyntax(StringSyntaxAttribute.Json)]
    public string? PopperConfig { get; set; }

    public StringOrBool? Selector { get; set; }
    public BsPopoverTrigger? Trigger { get; set; }
}
