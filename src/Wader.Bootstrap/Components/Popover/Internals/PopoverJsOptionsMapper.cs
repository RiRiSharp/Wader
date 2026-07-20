using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Infrastructure.Extensions;

namespace Wader.Bootstrap.Components.Popover.Internals;

internal static class PopoverJsOptionsMapper
{
    [Pure]
    internal static PopoverJsOptions ToPopoverJsOptions(
        this BsPopoverOptions popoverOptions,
        ElementReference? titleRef,
        ElementReference? contentRef
    )
    {
        var options = new PopoverJsOptions
        {
            Animation = popoverOptions.Animation,
            Boundary = popoverOptions.Boundary,
            ContainerString = popoverOptions.ContainerString,
            ContainerRef = popoverOptions.ContainerRef,
            ContentRef = contentRef,
            CustomClass = popoverOptions.CustomClass ?? "",
            Delay = new PopoverDelayJsOptions { Hide = popoverOptions.HideDelay, Show = popoverOptions.ShowDelay },
            Html = true,
            Placement = popoverOptions.Placement.ToPopperPlacementParameter(),
            Sanitize = false,
            TitleRef = titleRef,
            Trigger = popoverOptions.Trigger.ToPopperTriggerString(),
        };

        options.Offset.Add(popoverOptions.Distance);
        options.Offset.Add(popoverOptions.Skidding);
        options.FallbackPlacements.AddRange(
            popoverOptions.FallbackPlacements.Select(f => f.ToPopperPlacementParameter())
        );

        return options;
    }
}
