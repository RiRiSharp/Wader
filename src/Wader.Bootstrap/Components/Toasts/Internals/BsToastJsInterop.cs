using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Internal.JsInterop;

namespace Wader.Bootstrap.Components.Toasts.Internals;

internal sealed class BsToastJsInterop : IBsToastJsInterop, IBsJsFunctionsWrapper, IAsyncDisposable
{
    internal const string CREATE = "create";
    internal const string SHOW = "show";
    internal const string HIDE = "hide";
    internal const string DISPOSE = "dispose";

    private readonly IJSObjectReference _bsJsObjectRef;

    public BsToastJsInterop(IJSObjectReference bsJsObjectRef)
    {
        _bsJsObjectRef = bsJsObjectRef;
    }

    public async ValueTask DisposeAsync()
    {
        await _bsJsObjectRef.DisposeAsync();
    }

    public static string JsFileName => "toastFunctions.js";

    public async Task CreateAsync(ElementReference toastRef, ToastJsOptions? options = null)
    {
        await _bsJsObjectRef.InvokeVoidAsync(CREATE, toastRef, options);
    }

    public async Task ShowAsync(ElementReference toastRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(SHOW, toastRef);
    }

    public async Task HideAsync(ElementReference toastRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(HIDE, toastRef);
    }

    public async Task DisposeReferenceAsync(ElementReference elementRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(DISPOSE, elementRef);
    }
}
