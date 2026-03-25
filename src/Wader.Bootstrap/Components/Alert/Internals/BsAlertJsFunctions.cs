using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap.Components.Alert.Internals;

internal sealed class BsAlertJsFunctions : IBsAlertJsFunctions, IBsJsFunctionsWrapper, IAsyncDisposable
{
    internal const string DISMISS = "dismiss";

    internal const string REGISTER_DISMISS_CALLBACK = "registerDismissCallback";

    internal const string DISPOSE = "dispose";
    private readonly IJSObjectReference _bsJsObjectRef;

    public BsAlertJsFunctions(IJSObjectReference bsJsObjectRef)
    {
        _bsJsObjectRef = bsJsObjectRef;
    }

    public async ValueTask DisposeAsync()
    {
        await _bsJsObjectRef.DisposeAsync();
    }

    public async Task DismissAsync(ElementReference alertRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(DISMISS, alertRef);
    }

    public async Task RegisterDismissCallbackAsync(ElementReference alertRef, DotNetObjectReference<BsAlert> dotNetRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(REGISTER_DISMISS_CALLBACK, alertRef, dotNetRef);
    }

    public async Task DisposeReferenceAsync(ElementReference elementRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(DISPOSE, elementRef);
    }

    public static string JsFileName => "alertFunctions.js";
}
