using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap.Components.Accordion.Internals;

public interface IBsAccordionJsFunctions : IBsJsDisposable
{
    Task CollapseAllAsync(ElementReference accordionRef);
    Task ShowAllAsync(ElementReference accordionRef);
    Task CollapseAllButOneAsync(ElementReference accordionRef, ElementReference accordionItemRef);
    Task ToggleAsync(ElementReference accordionItemRef, bool alwaysOpen = false);
    Task ShowAsync(ElementReference accordionItemRef, bool alwaysOpen = false);
    Task CollapseAsync(ElementReference accordionItemRef);

    Task RegisterCollapseCallbackAsync<T>(ElementReference buttonRef, DotNetObjectReference<T> dotNetRef)
        where T : class, IHasCollapseState;
}
