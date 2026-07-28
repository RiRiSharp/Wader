using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Internal.JsInterop;

namespace Wader.Bootstrap.Forms.ChecksRadios.Internals;

internal sealed class BsCheckboxJsInterop : IBsCheckboxJsInterop, IBsJsFunctionsWrapper, IAsyncDisposable
{
    internal const string INITIALIZE_INDETERMINATE = "initializeIndeterminate";
    private readonly IJSObjectReference _bsJsObjectRef;

    internal BsCheckboxJsInterop(IJSObjectReference js)
    {
        _bsJsObjectRef = js;
    }

    public async ValueTask DisposeAsync()
    {
        await _bsJsObjectRef.DisposeAsync();
    }

    public async ValueTask InitializeIndeterminateAsync(ElementReference checkboxReference)
    {
        await _bsJsObjectRef.InvokeVoidAsync(INITIALIZE_INDETERMINATE, checkboxReference);
    }

    public static string JsFileName => "BsCheckboxJsFunctions.js";
}
