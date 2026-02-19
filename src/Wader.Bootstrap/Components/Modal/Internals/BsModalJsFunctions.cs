using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap.Components.Modal.Internals;

internal sealed class BsModalJsFunctions : IBsModalJsFunctions, IBsJsFunctionsWrapper, IAsyncDisposable
{
    public static string JsFileName => "modalFunctions.js";
    private readonly IJSObjectReference _bsJsObjectRef;

    public BsModalJsFunctions(IJSObjectReference bsJsObjectRef)
    {
        _bsJsObjectRef = bsJsObjectRef;
    }

    internal const string TOGGLE = "toggle";

    public async Task ToggleAsync(ElementReference modalRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(TOGGLE, modalRef);
    }

    internal const string SHOW = "show";

    public async Task ShowAsync(ElementReference modalRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(SHOW, modalRef);
    }

    internal const string CLOSE = "close";

    public async Task CloseAsync(ElementReference modalRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(CLOSE, modalRef);
    }

    internal const string HANDLE_UPDATE = "handleUpdate";

    public async Task HandleUpdateAsync(ElementReference modalRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(HANDLE_UPDATE, modalRef);
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
