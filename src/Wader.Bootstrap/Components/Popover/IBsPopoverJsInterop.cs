using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Infrastructure.JsInterop;

namespace Wader.Bootstrap.Components.Popover;

public interface IBsPopoverJsInterop : IBsJsDisposable
{
    Task CreateOrUpdateAsync(ElementReference hostElementRef, BsPopoverJsOptions bsPopoverJsOptions);
    Task ToggleAsync(ElementReference hostElementRef);
    Task ShowAsync(ElementReference hostElementRef);
    Task HideAsync(ElementReference hostElementRef);
    Task UpdatePositionAsync(ElementReference hostElementRef);
    Task EnableAsync(ElementReference hostElementRef);
    Task DisableAsync(ElementReference hostElementRef);
    Task ToggleEnabledAsync(ElementReference hostElementRef);
}
