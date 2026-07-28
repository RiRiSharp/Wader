using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Internal.JsInterop;

namespace Wader.Bootstrap.Components.Collapse.Internals;

internal sealed class BsCollapseJsInterop : IBsCollapseJsInterop, IBsJsFunctionsWrapper, IAsyncDisposable
{
    internal const string TOGGLE = "toggle";

    internal const string SHOW = "show";

    internal const string COLLAPSE = "collapse";

    internal const string DISPOSE = "dispose";
    private readonly IJSObjectReference _bsJsObjectRef;

    public BsCollapseJsInterop(IJSObjectReference bsJsObjectRef)
    {
        _bsJsObjectRef = bsJsObjectRef;
    }

    public async ValueTask DisposeAsync()
    {
        await _bsJsObjectRef.DisposeAsync();
    }

    public async Task ToggleAsync(ElementReference collapseRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(TOGGLE, collapseRef);
    }

    public async Task ShowAsync(ElementReference collapseRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(SHOW, collapseRef);
    }

    public async Task CollapseAsync(ElementReference collapseRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(COLLAPSE, collapseRef);
    }

    public async Task DisposeReferenceAsync(ElementReference elementRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(DISPOSE, elementRef);
    }

    public static string JsFileName => "collapseFunctions.js";
}
