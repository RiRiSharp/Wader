using System.Diagnostics.Contracts;

namespace Wader.Bootstrap.Components.Popover.Internals;

internal static class BsPopoverJsOptionsSerializationMapper
{
    [Pure]
    internal static BsPopoverSerializedOptions ToSerializedOptions(this BsPopoverJsOptions popoverJsOptions)
    {
        return new BsPopoverSerializedOptions
        {
            AllowList = popoverJsOptions.AllowList,
            Animation = popoverJsOptions.Animation,
            Boundary = popoverJsOptions.Boundary?.Value,
            Container = popoverJsOptions.Container?.Value,
            Content = popoverJsOptions.Content?.Value,
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
