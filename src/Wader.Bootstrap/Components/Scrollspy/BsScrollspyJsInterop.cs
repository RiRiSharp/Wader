using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Infrastructure.JsInterop;

namespace Wader.Bootstrap.Components.Scrollspy;

internal sealed class BsScrollspyJsInterop : IBsScrollspyJsInterop, IBsJsFunctionsWrapper, IAsyncDisposable
{
    internal const string CREATE = "create";

    internal const string DISPOSE = "dispose";
    private readonly IJSObjectReference _bsJsObjectRef;

    public BsScrollspyJsInterop(IJSObjectReference bsJsObjectRef)
    {
        _bsJsObjectRef = bsJsObjectRef;
    }

    public async ValueTask DisposeAsync()
    {
        await _bsJsObjectRef.DisposeAsync();
    }

    public static string JsFileName => "scrollspyFunctions.js";

    public async ValueTask CreateAsync(
        ElementReference hostElementRef,
        ElementReference targetElementRef,
        ScrollspyJsOptions? options = null
    )
    {
        options ??= new ScrollspyJsOptions();
        await _bsJsObjectRef.InvokeVoidAsync(CREATE, hostElementRef, targetElementRef, options);
    }

    public async Task DisposeReferenceAsync(ElementReference elementRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(DISPOSE, elementRef);
    }
}
