using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap.Components.Popover.Internals;

public interface IBsPopoverJsInterop : IBsJsDisposable
{
    Task CreateOrUpdateAsync(ElementReference hostElementRef, PopoverJsOptions popoverOptions);
    Task ToggleAsync(ElementReference hostElementRef);
    Task ShowAsync(ElementReference hostElementRef);
    Task HideAsync(ElementReference hostElementRef);
    Task UpdatePositionAsync(ElementReference hostElementRef);
}
