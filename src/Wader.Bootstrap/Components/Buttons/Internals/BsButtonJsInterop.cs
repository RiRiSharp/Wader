using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap.Components.Buttons.Internals;

internal sealed class BsButtonJsInterop : IBsButtonJsInterop, IBsJsFunctionsWrapper, IAsyncDisposable
{
    internal const string TOGGLE = "toggle";

    internal const string DISPOSE = "dispose";
    private readonly IJSObjectReference _bsJsObjectRef;

    public BsButtonJsInterop(IJSObjectReference bsJsObjectRef)
    {
        _bsJsObjectRef = bsJsObjectRef;
    }

    public async ValueTask DisposeAsync()
    {
        await _bsJsObjectRef.DisposeAsync();
    }

    public async Task ToggleAsync(ElementReference buttonRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(TOGGLE, buttonRef);
    }

    public async Task DisposeReferenceAsync(ElementReference elementRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(DISPOSE, elementRef);
    }

    public static string JsFileName => "buttonFunctions.js";
}
