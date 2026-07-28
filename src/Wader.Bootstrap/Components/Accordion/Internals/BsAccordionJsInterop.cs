using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Internal.JsInterop;

namespace Wader.Bootstrap.Components.Accordion.Internals;

internal sealed class BsAccordionJsInterop : IBsAccordionJsInterop, IBsJsFunctionsWrapper, IAsyncDisposable
{
    internal const string COLLAPSE_ALL = "collapseAll";

    internal const string SHOW_ALL = "showAll";

    internal const string COLLAPSE_ALL_BUT_ONE = "collapseAllButOne";

    internal const string TOGGLE = "toggle";

    internal const string SHOW = "show";

    internal const string COLLAPSE = "collapse";

    internal const string REGISTER_COLLAPSE_CALLBACK = "registerCollapseCallback";

    internal const string DISPOSE = "dispose";
    private readonly IJSObjectReference _bsJsObjectRef;

    public BsAccordionJsInterop(IJSObjectReference bsJsObjectRef)
    {
        _bsJsObjectRef = bsJsObjectRef;
    }

    public async ValueTask DisposeAsync()
    {
        await _bsJsObjectRef.DisposeAsync();
    }

    public async Task CollapseAllAsync(ElementReference accordionRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(COLLAPSE_ALL, accordionRef);
    }

    public async Task ShowAllAsync(ElementReference accordionRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(SHOW_ALL, accordionRef);
    }

    public async Task CollapseAllButOneAsync(ElementReference accordionRef, ElementReference accordionItemRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(COLLAPSE_ALL_BUT_ONE, accordionRef, accordionItemRef);
    }

    public async Task ToggleAsync(ElementReference accordionItemRef, bool alwaysOpen = false)
    {
        await _bsJsObjectRef.InvokeVoidAsync(TOGGLE, accordionItemRef, alwaysOpen);
    }

    public async Task ShowAsync(ElementReference accordionItemRef, bool alwaysOpen = false)
    {
        await _bsJsObjectRef.InvokeVoidAsync(SHOW, accordionItemRef, alwaysOpen);
    }

    public async Task CollapseAsync(ElementReference accordionItemRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(COLLAPSE, accordionItemRef);
    }

    public async Task RegisterCollapseCallbackAsync<T>(ElementReference buttonRef, DotNetObjectReference<T> dotNetRef)
        where T : class, IHasCollapseState
    {
        await _bsJsObjectRef.InvokeVoidAsync(REGISTER_COLLAPSE_CALLBACK, buttonRef, dotNetRef);
    }

    /// <summary>
    ///     Disposes the references the underlying JS code has to the created accordion item
    /// </summary>
    /// <param name="elementRef">A reference to the accordion-item</param>
    public async Task DisposeReferenceAsync(ElementReference elementRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(DISPOSE, elementRef);
    }

    public static string JsFileName => "accordionFunctions.js";
}
