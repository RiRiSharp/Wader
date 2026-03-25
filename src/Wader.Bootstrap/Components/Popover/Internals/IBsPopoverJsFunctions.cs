using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap.Components.Popover.Internals;

public interface IBsPopoverJsFunctions : IBsJsDisposable
{
    Task ToggleAsync(ElementReference popoverRef);
    Task ShowAsync(ElementReference popoverRef);
    Task HideAsync(ElementReference popoverRef);
    Task UpdateAsync(ElementReference popoverRef);
}
