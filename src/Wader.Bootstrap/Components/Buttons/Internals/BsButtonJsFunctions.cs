using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap.Components.Buttons.Internals;

internal sealed class BsButtonJsFunctions : IBsButtonJsFunctions, IBsJsFunctionsWrapper, IAsyncDisposable
{
    public static string JsFileName => "buttonFunctions.js";
    private readonly IJSObjectReference _bsJsObjectRef;

    public BsButtonJsFunctions(IJSObjectReference bsJsObjectRef)
    {
        _bsJsObjectRef = bsJsObjectRef;
    }

    internal const string TOGGLE = "toggle";

    public async Task ToggleAsync(ElementReference buttonRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(TOGGLE, buttonRef);
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
