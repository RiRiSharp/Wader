using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Infrastructure.JsInterop;

namespace Wader.Bootstrap.Components.Modal.Internals;

internal sealed class BsModalJsInterop : IBsModalJsInterop, IBsJsFunctionsWrapper, IAsyncDisposable
{
    internal const string TOGGLE = "toggle";

    internal const string SHOW = "show";

    internal const string CLOSE = "close";

    internal const string HANDLE_UPDATE = "handleUpdate";

    internal const string DISPOSE = "dispose";
    private readonly IJSObjectReference _bsJsObjectRef;

    public BsModalJsInterop(IJSObjectReference bsJsObjectRef)
    {
        _bsJsObjectRef = bsJsObjectRef;
    }

    public async ValueTask DisposeAsync()
    {
        await _bsJsObjectRef.DisposeAsync();
    }

    public static string JsFileName => "modalFunctions.js";

    public async Task ToggleAsync(ElementReference modalRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(TOGGLE, modalRef);
    }

    public async Task ShowAsync(ElementReference modalRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(SHOW, modalRef);
    }

    public async Task CloseAsync(ElementReference modalRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(CLOSE, modalRef);
    }

    public async Task HandleUpdateAsync(ElementReference modalRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(HANDLE_UPDATE, modalRef);
    }

    public async Task DisposeReferenceAsync(ElementReference elementRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(DISPOSE, elementRef);
    }
}
