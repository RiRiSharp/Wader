using System.Diagnostics.Contracts;

namespace Wader.Bootstrap.Components.Tooltip.Internals;

internal static class BsTooltipJsOptionsSerializationMapper
{
    [Pure]
    internal static BsTooltipSerializedOptions ToSerializedOptions(this BsTooltipJsOptions popoverJsOptions)
    {
        return new BsTooltipSerializedOptions
        {
            AllowList = popoverJsOptions.AllowList,
            Animation = popoverJsOptions.Animation,
            Boundary = popoverJsOptions.Boundary?.Value,
            Container = popoverJsOptions.Container?.Value,
            CustomClass = popoverJsOptions.CustomClass,
            Delay = popoverJsOptions.Delay?.Value,
            FallbackPlacements = popoverJsOptions.FallbackPlacements?.Value,
            Html = popoverJsOptions.Html,
            Offset = popoverJsOptions.Offset?.Value,
            Placement = popoverJsOptions.Placement,
            PopperConfig = popoverJsOptions.PopperConfig,
            Sanitize = popoverJsOptions.Sanitize,
            Selector = popoverJsOptions.Selector?.Value,
            Template = popoverJsOptions.Template,
            Title = popoverJsOptions.Title?.Value,
            Trigger = popoverJsOptions.Trigger?.Value,
        };
    }
}
