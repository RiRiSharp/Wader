using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Infrastructure.JsInterop.Unions;

namespace Wader.Bootstrap.Components.Tooltip.Internals;

internal static class TooltipJsOptionsMapper
{
    [Pure]
    internal static BsTooltipJsOptions ToTooltipJsOptions(
        this BsTooltipOptions popoverOptions,
        ElementReference? titleRef
    )
    {
        HtmlStringOrElementRef title = "";
        if (titleRef is not null)
        {
            title = titleRef;
        }

        return new BsTooltipJsOptions
        {
            AllowList = popoverOptions.AllowList,
            Animation = popoverOptions.Animation,
            Boundary = popoverOptions.Boundary,
            Container = popoverOptions.Container,
            CustomClass = popoverOptions.CustomClass,
            Delay = popoverOptions.Delay,
            FallbackPlacements = popoverOptions.FallbackPlacements,
            Html = true,
            Offset = popoverOptions.Offset,
            Placement = popoverOptions.Placement,
            PopperConfig = popoverOptions.PopperConfig,
            Sanitize = false,
            Selector = popoverOptions.Selector,
            Title = title,
            Trigger = popoverOptions.Trigger,
        };
    }
}
