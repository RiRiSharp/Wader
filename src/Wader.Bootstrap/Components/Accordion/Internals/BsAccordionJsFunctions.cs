using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap.Components.Accordion.Internals;

internal sealed class BsAccordionJsFunctions : IBsAccordionJsFunctions, IBsJsFunctionsWrapper, IAsyncDisposable
{
    public static string JsFileName => "accordionFunctions.js";
    private readonly IJSObjectReference _bsJsObjectRef;

    public BsAccordionJsFunctions(IJSObjectReference bsJsObjectRef)
    {
        _bsJsObjectRef = bsJsObjectRef;
    }

    internal const string COLLAPSE_ALL = "collapseAll";

    public async Task CollapseAllAsync(ElementReference accordionRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(COLLAPSE_ALL, accordionRef);
    }

    internal const string SHOW_ALL = "showAll";

    public async Task ShowAllAsync(ElementReference accordionRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(SHOW_ALL, accordionRef);
    }

    internal const string COLLAPSE_ALL_BUT_ONE = "collapseAllButOne";

    public async Task CollapseAllButOneAsync(ElementReference accordionRef, ElementReference accordionItemRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(COLLAPSE_ALL_BUT_ONE, accordionRef, accordionItemRef);
    }

    internal const string TOGGLE = "toggle";

    public async Task ToggleAsync(ElementReference accordionItemRef, bool alwaysOpen = false)
    {
        await _bsJsObjectRef.InvokeVoidAsync(TOGGLE, accordionItemRef, alwaysOpen);
    }

    internal const string SHOW = "show";

    public async Task ShowAsync(ElementReference accordionItemRef, bool alwaysOpen = false)
    {
        await _bsJsObjectRef.InvokeVoidAsync(SHOW, accordionItemRef, alwaysOpen);
    }

    internal const string COLLAPSE = "collapse";

    public async Task CollapseAsync(ElementReference accordionItemRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(COLLAPSE, accordionItemRef);
    }

    internal const string REGISTER_COLLAPSE_CALLBACK = "registerCollapseCallback";

    public async Task RegisterCollapseCallbackAsync<T>(ElementReference buttonRef, DotNetObjectReference<T> dotNetRef)
        where T : class, IHasCollapseState
    {
        await _bsJsObjectRef.InvokeVoidAsync(REGISTER_COLLAPSE_CALLBACK, buttonRef, dotNetRef);
    }

    internal const string DISPOSE = "dispose";

    /// <summary>
    /// Disposes the references the underlying JS code has to the created accordion item
    /// </summary>
    /// <param name="elementRef">A reference to the accordion-item</param>
    public async Task DisposeAsync(ElementReference elementRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(DISPOSE, elementRef);
    }

    public async ValueTask DisposeAsync()
    {
        await _bsJsObjectRef.DisposeAsync();
    }
}
