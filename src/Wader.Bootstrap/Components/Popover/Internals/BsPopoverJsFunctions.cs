using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap.Components.Popover.Internals;

public sealed class BsPopoverJsFunctions : IBsPopoverJsFunctions, IBsJsFunctionsWrapper, IAsyncDisposable
{
    internal const string TOGGLE = "toggle";

    internal const string SHOW = "show";

    internal const string HIDE = "hide";

    internal const string UPDATE = "update";

    internal const string DISPOSE = "dispose";
    private readonly IJSObjectReference _bsJsObjectRef;

    public BsPopoverJsFunctions(IJSObjectReference bsJsObjectRef)
    {
        _bsJsObjectRef = bsJsObjectRef;
    }

    public async ValueTask DisposeAsync()
    {
        await _bsJsObjectRef.DisposeAsync();
    }

    public static string JsFileName => "popoverFunctions.js";

    public async Task ToggleAsync(ElementReference popoverRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(TOGGLE, popoverRef);
    }

    public async Task ShowAsync(ElementReference popoverRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(SHOW, popoverRef);
    }

    public async Task HideAsync(ElementReference popoverRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(HIDE, popoverRef);
    }

    public async Task UpdateAsync(ElementReference popoverRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(UPDATE, popoverRef);
    }

    public async Task DisposeReferenceAsync(ElementReference elementRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(DISPOSE, elementRef);
    }
}
