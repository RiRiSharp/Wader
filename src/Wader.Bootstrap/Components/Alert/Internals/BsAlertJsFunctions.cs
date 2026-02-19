using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap.Components.Alert.Internals;

internal sealed class BsAlertJsFunctions : IBsAlertJsFunctions, IBsJsFunctionsWrapper, IAsyncDisposable
{
    public static string JsFileName => "alertFunctions.js";
    private readonly IJSObjectReference _bsJsObjectRef;

    public BsAlertJsFunctions(IJSObjectReference bsJsObjectRef)
    {
        _bsJsObjectRef = bsJsObjectRef;
    }

    internal const string DISMISS = "dismiss";

    public async Task DismissAsync(ElementReference alertRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(DISMISS, alertRef);
    }

    internal const string REGISTER_DISMISS_CALLBACK = "registerDismissCallback";

    public async Task RegisterDismissCallbackAsync(ElementReference alertRef, DotNetObjectReference<BsAlert> dotNetRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(REGISTER_DISMISS_CALLBACK, alertRef, dotNetRef);
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
