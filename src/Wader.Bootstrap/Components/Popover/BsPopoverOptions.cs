using Wader.Bootstrap.Components.Popover.Internals;
using Wader.Bootstrap.Infrastructure.Exceptions;
using Wader.Bootstrap.Infrastructure.JsInterop.Unions;

namespace Wader.Bootstrap.Components.Popover;

public class BsPopoverOptions
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

    public BsPopoverPlacement Placement { get; set; } = BsPopoverPlacement.Right;
    public BsPopoverTrigger Trigger { get; set; } = BsPopoverTrigger.Click;
}
