using System.Diagnostics.CodeAnalysis;
using Wader.Bootstrap.Infrastructure.Exceptions;
using Wader.Bootstrap.Infrastructure.JsInterop.Unions;

namespace Wader.Bootstrap.Components.Popover.Internals;

public class PopoverJsOptions
{
    /// <summary>
    ///     A dictionary where the keys are HTML-tags and the values are attributes on that HTML-tag which are allowed.
    /// </summary>
    /// <remarks>
    ///     Setting <see cref="AllowList" /> to <see langword="null" /> will use Bootstrap's
    ///     <see href="https://getbootstrap.com/docs/5.3/getting-started/javascript/#sanitizer">default documentation</see>
    /// </remarks>
    public Dictionary<string, string[]>? AllowList { get; set; }

    public bool Animation { get; set; } = true;
    public HtmlStringOrElementRef Boundary { get; set; } = "clippingElement";
    public HtmlStringElementRefOrBool Container { get; set; } = false;
    public HtmlStringOrElementRef Content { get; set; } = "";
    public string CustomClass { get; set; } = "";
    public Union<int, PopoverDelayJsOptions> Delay { get; set; } = 0;

    public OneOrMore<BsPopoverPlacement> FallbackPlacements
    {
        get;
        set
        {
            if (
                value.TryGetAs<BsPopoverPlacement[]>(out var bsPopoverPlacements)
                && bsPopoverPlacements.Contains(BsPopoverPlacement.Auto)
                && bsPopoverPlacements.Length > 1
            )
            {
                throw new BsJsInteropOptionsException(
                    $"{nameof(BsPopoverPlacement.Auto)} cannot be combined with other options"
                );
            }
        }
    } = new[] { BsPopoverPlacement.Top, BsPopoverPlacement.Right, BsPopoverPlacement.Bottom, BsPopoverPlacement.Left };

    /// <summary>
    ///     Whether to allow HTML in the popover.
    /// </summary>
    public bool Html { get; set; }

    public OneOrMore<int> Offset
    {
        get;
        set
        {
            if (value.TryGetAs<int[]>(out var offsets) && offsets.Length != 2)
            {
                throw new BsJsInteropOptionsException(
                    $"{nameof(BsPopoverPlacement.Auto)} must be exactly of length 2."
                );
            }
        }
    } = new[] { 0, 8 };

    public required BsPopoverPlacement Placement { get; set; }

    [StringSyntax(StringSyntaxAttribute.Json)]
    public string? PopperConfig { get; set; }

    public bool Sanitize { get; set; } = true;
    public StringOrBool Selector { get; set; } = false;

    /// <summary>
    ///     The HTML-template to use.
    /// </summary>
    /// <remarks>
    ///     Defaults to <see langword="null" />, in contrast to Bootstrap defaults, which means it will use the Bootstrap
    ///     default.
    /// </remarks>
    [StringSyntax("Html")]
    public string? Template { get; set; }

    public HtmlStringOrElementRef Title { get; set; } = "";
    public required string Trigger { get; set; } = "click";
}
