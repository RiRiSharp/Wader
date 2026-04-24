using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap.Components.Scrollspy.Internals;

public sealed class BsScrollspyJsInterop : IBsScrollspyJsInterop, IBsJsFunctionsWrapper, IAsyncDisposable
{
    private readonly IJSObjectReference _bsJsObjectRef;

    public BsScrollspyJsInterop(IJSObjectReference bsJsObjectRef)
    {
        _bsJsObjectRef = bsJsObjectRef;
    }

    public async ValueTask DisposeAsync()
    {
        await _bsJsObjectRef.DisposeAsync();
    }

    internal const string CREATE = "create";

    public async ValueTask CreateAsync(ElementReference hostElementRef, ScrollspyJsOptions? options = null)
    {
        await _bsJsObjectRef.InvokeVoidAsync(CREATE, hostElementRef, options);
    }

    internal const string DISPOSE = "dispose";

    public async Task DisposeReferenceAsync(ElementReference elementRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(DISPOSE, elementRef);
    }

    public static string JsFileName => "scrollspyFunctions.js";
}
