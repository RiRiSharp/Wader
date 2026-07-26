using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Components.Popover;
using Wader.Bootstrap.Infrastructure.JsInterop;

namespace Wader.Bootstrap.Components.Tooltips.Internals;

public interface IBsTooltipJsInterop : IBsJsDisposable
{
    Task CreateOrUpdateAsync(ElementReference hostElementRef, BsPopoverJsOptions bsPopoverJsOptions);
    Task ToggleAsync(ElementReference hostElementRef);
    Task ShowAsync(ElementReference hostElementRef);
    Task HideAsync(ElementReference hostElementRef);
    Task UpdatePositionAsync(ElementReference hostElementRef);
    Task EnableAsync(ElementReference hostElementRef);
    Task DisableAsync(ElementReference hostElementRef);
    Task ToggleEnableAsync(ElementReference hostElementRef);
}
