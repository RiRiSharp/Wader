using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internals.Extensions;

namespace Wader.Bootstrap.Components.Popover.Internals;

public static class PopoverOptionsMapper
{
    public static PopoverJsOptions ToPopoverJsOptions(
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
            Container = popoverOptions.ContainerRef,
            Content = contentRef,
            CustomClass = popoverOptions.CustomClass ?? "",
            Delay = new PopoverDelayOptions { Hide = popoverOptions.HideDelay, Show = popoverOptions.ShowDelay },
            Html = true,
            Placement = popoverOptions.Placement.ToPopperPlacementParameter(),
            Sanitize = false,
            Title = titleRef,
            Trigger = popoverOptions.Trigger.ToPopperTriggerString(),
        };

        options.Offset.Add(popoverOptions.OffsetX);
        options.Offset.Add(popoverOptions.OffsetY);
        options.FallbackPlacements.AddRange(
            popoverOptions.FallbackPlacements.Select(f => f.ToPopperPlacementParameter())
        );

        return options;
    }
}
