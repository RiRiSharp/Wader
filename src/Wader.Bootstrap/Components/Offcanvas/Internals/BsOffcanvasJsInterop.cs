using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap.Components.Offcanvas.Internals;

internal sealed class BsOffcanvasJsInterop : IBsOffcanvasJsInterop, IBsJsFunctionsWrapper, IAsyncDisposable
{
    internal const string TOGGLE = "toggle";

    internal const string SHOW = "show";

    internal const string CLOSE = "close";

    internal const string DISPOSE = "dispose";
    private readonly IJSObjectReference _bsJsObjectRef;

    public BsOffcanvasJsInterop(IJSObjectReference bsJsObjectRef)
    {
        _bsJsObjectRef = bsJsObjectRef;
    }

    public async ValueTask DisposeAsync()
    {
        await _bsJsObjectRef.DisposeAsync();
    }

    public static string JsFileName => "offcanvasFunctions.js";

    public async Task ToggleAsync(ElementReference offcanvasRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(TOGGLE, offcanvasRef);
    }

    public async Task ShowAsync(ElementReference offcanvasRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(SHOW, offcanvasRef);
    }

    public async Task CloseAsync(ElementReference offcanvasRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(CLOSE, offcanvasRef);
    }

    public async Task DisposeReferenceAsync(ElementReference elementRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(DISPOSE, elementRef);
    }
}
