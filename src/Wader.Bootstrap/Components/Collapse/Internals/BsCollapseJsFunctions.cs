using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap.Components.Collapse.Internals;

internal sealed class BsCollapseJsFunctions : IBsCollapseJsFunctions, IBsJsFunctionsWrapper, IAsyncDisposable
{
    public static string JsFileName => "collapseFunctions.js";
    private readonly IJSObjectReference _bsJsObjectRef;

    public BsCollapseJsFunctions(IJSObjectReference bsJsObjectRef)
    {
        _bsJsObjectRef = bsJsObjectRef;
    }

    internal const string TOGGLE = "toggle";

    public async Task ToggleAsync(ElementReference collapseRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(TOGGLE, collapseRef);
    }

    internal const string SHOW = "show";

    public async Task ShowAsync(ElementReference collapseRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(SHOW, collapseRef);
    }

    internal const string COLLAPSE = "collapse";

    public async Task CollapseAsync(ElementReference collapseRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(COLLAPSE, collapseRef);
    }

    internal const string DISPOSE = "dispose";

    public async Task DisposeAsync(ElementReference elementRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(DISPOSE, elementRef);
    }

    public async ValueTask DisposeAsync()
    {
        await _bsJsObjectRef.DisposeAsync();
    }
}
