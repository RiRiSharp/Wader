using System.Diagnostics.CodeAnalysis;
using Wader.Bootstrap.Infrastructure.Exceptions;
using Wader.Bootstrap.Infrastructure.JsInterop.Unions;

namespace Wader.Bootstrap.Components.Popover;

public class BsPopoverJsOptions
{
    internal const string CLIPPING_PARENTS = "clippingParents";

    /// <summary>
    ///     A dictionary where the keys are HTML-tags and the values are attributes on that HTML-tag which are allowed.
    /// </summary>
    /// <remarks>
    ///     Setting <see cref="AllowList" /> to <see langword="null" /> will use Bootstrap's
    ///     <see href="https://getbootstrap.com/docs/5.3/getting-started/javascript/#sanitizer">default documentation</see>
    /// </remarks>
    public Dictionary<string, string[]>? AllowList { get; set; }

    public bool? Animation { get; set; }

    public HtmlStringOrElementRef? Boundary
    {
        get;
        set
        {
            if (value is not null && value.TryGetAs<string>(out var stringValue) && stringValue != CLIPPING_PARENTS)
            {
                throw new BsJsInteropOptionsException(
                    $"'{stringValue}' is not allowed as a string value, only '{CLIPPING_PARENTS}' is"
                );
            }

            field = value;
        }
    }

    public HtmlStringElementRefOrBool? Container
    {
        get;
        set
        {
            if (value is not null && value.TryGetAs<bool>(out var boolValue) && boolValue)
            {
                throw new BsJsInteropOptionsException(
                    $"'{boolValue}' is not allowed as a boolean value, only '{false}' is"
                );
            }

            field = value;
        }
    }

    /// <summary>
    ///     The body content to display on the popover.
    /// </summary>
    /// <remarks>
    ///     If the referenced element has the data attribute data-wd-remove-wrapper="true", the inner HTML will be used.
    /// </remarks>
    public HtmlStringOrElementRef? Content { get; set; }

    public string? CustomClass { get; set; }
    public Union<int, BsPopoverDelayJsOptions>? Delay { get; set; }

    public OneOrMore<BsPopoverPlacement>? FallbackPlacements
    {
        get;
        set
        {
            if (
                value is not null
                && value.TryGetAs<BsPopoverPlacement[]>(out var bsPopoverPlacements)
                && bsPopoverPlacements.Contains(BsPopoverPlacement.Auto)
                && bsPopoverPlacements.Length > 1
            )
            {
                throw new BsJsInteropOptionsException(
                    $"{nameof(BsPopoverPlacement.Auto)} cannot be combined with other options"
                );
            }

            field = value;
        }
    }

    /// <summary>
    ///     Whether to allow HTML in the popover.
    /// </summary>
    public bool? Html { get; set; }

    public OneOrMore<int>? Offset
    {
        get;
        set
        {
            if (value is not null && value.TryGetAs<int[]>(out var offsets) && offsets.Length > 2)
            {
                throw new BsJsInteropOptionsException(
                    $"{nameof(BsPopoverPlacement.Auto)} must be exactly of length 2."
                );
            }

            field = value;
        }
    }

    public BsPopoverPlacement? Placement { get; set; }

    [StringSyntax(StringSyntaxAttribute.Json)]
    public string? PopperConfig { get; set; }

    public bool? Sanitize { get; set; }

    public StringOrBool? Selector
    {
        get;
        set
        {
            if (value is not null && value.TryGetAs<bool>(out var boolValue) && boolValue)
            {
                throw new BsJsInteropOptionsException(
                    $"'{boolValue}' is not allowed as a boolean value, only '{false}' is"
                );
            }

            field = value;
        }
    }

    /// <summary>
    ///     The HTML-template to use.
    /// </summary>
    [StringSyntax("Html")]
    public string? Template { get; set; }

    /// <summary>
    ///     The title content to display on the popover.
    /// </summary>
    /// <remarks>
    ///     If the referenced element has the data attribute data-wd-remove-wrapper="true", the inner HTML will be used.
    /// </remarks>
    public HtmlStringOrElementRef? Title { get; set; }

    public OneOrMore<BsPopoverTrigger>? Trigger
    {
        get;
        set
        {
            if (
                value is not null
                && value.TryGetAs<BsPopoverTrigger[]>(out var bsPopoverTrigger)
                && bsPopoverTrigger.Contains(BsPopoverTrigger.Manual)
                && bsPopoverTrigger.Length > 1
            )
            {
                throw new BsJsInteropOptionsException(
                    $"{nameof(BsPopoverTrigger.Manual)} cannot be combined with other options"
                );
            }

            field = value;
        }
    }
}
