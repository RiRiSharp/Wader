using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap.Forms.ChecksRadios.Internals;

internal sealed class BsCheckboxJsFunctions : IBsCheckboxJsFunctions, IBsJsFunctionsWrapper, IAsyncDisposable
{
    public static string JsFileName => "BsCheckboxJsFunctions.js";
    private readonly IJSObjectReference _bsJsObjectRef;

    internal BsCheckboxJsFunctions(IJSObjectReference js)
    {
        _bsJsObjectRef = js;
    }

    internal const string INITIALIZE_INDETERMINATE = "initializeIndeterminate";

    public async ValueTask InitializeIndeterminateAsync(ElementReference checkboxReference)
    {
        await _bsJsObjectRef.InvokeVoidAsync(INITIALIZE_INDETERMINATE, checkboxReference);
    }

    public async ValueTask DisposeAsync()
    {
        await _bsJsObjectRef.DisposeAsync();
    }
}
