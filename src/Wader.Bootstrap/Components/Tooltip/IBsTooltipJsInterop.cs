using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Infrastructure.JsInterop;

namespace Wader.Bootstrap.Components.Tooltip;

public interface IBsTooltipJsInterop : IBsJsDisposable
{
    Task CreateOrUpdateAsync(ElementReference hostElementRef, BsTooltipJsOptions bsPopoverJsOptions);
    Task ToggleAsync(ElementReference hostElementRef);
    Task ShowAsync(ElementReference hostElementRef);
    Task HideAsync(ElementReference hostElementRef);
    Task UpdatePositionAsync(ElementReference hostElementRef);
    Task EnableAsync(ElementReference hostElementRef);
    Task DisableAsync(ElementReference hostElementRef);
    Task ToggleEnabledAsync(ElementReference hostElementRef);
}
