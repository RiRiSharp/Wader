using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Infrastructure.JsInterop.Unions;

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
        HtmlStringOrElementRef content = "";
        if (contentRef is not null)
        {
            content = contentRef;
        }

        HtmlStringOrElementRef title = "";
        if (titleRef is not null)
        {
            title = titleRef;
        }

        return new PopoverJsOptions
        {
            AllowList = popoverOptions.AllowList,
            Animation = popoverOptions.Animation,
            Boundary = popoverOptions.Boundary,
            Container = popoverOptions.Container,
            Content = content,
            CustomClass = popoverOptions.CustomClass,
            Delay = popoverOptions.Delay,
            Html = true,
            Placement = popoverOptions.Placement,
            Sanitize = false,
            Title = title,
            Trigger = popoverOptions.Trigger.ToPopperTriggerString(),
        };
    }
}
