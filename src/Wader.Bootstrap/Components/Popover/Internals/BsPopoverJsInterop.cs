using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap.Components.Popover.Internals;

internal sealed class BsPopoverJsInterop : IBsPopoverJsInterop, IBsJsFunctionsWrapper, IAsyncDisposable
{
    internal const string CREATE_OR_UPDATE = "createOrUpdate";
    internal const string TOGGLE = "toggle";
    internal const string SHOW = "show";
    internal const string HIDE = "hide";
    internal const string UPDATE_POSITION = "updatePosition";
    internal const string DISPOSE = "dispose";

    private readonly IJSObjectReference _bsJsObjectRef;

    public BsPopoverJsInterop(IJSObjectReference bsJsObjectRef)
    {
        _bsJsObjectRef = bsJsObjectRef;
    }

    public async ValueTask DisposeAsync()
    {
        await _bsJsObjectRef.DisposeAsync();
    }

    public static string JsFileName => "popoverFunctions.js";

    public async Task CreateOrUpdateAsync(ElementReference hostElementRef, PopoverJsOptions popoverOptions)
    {
        await _bsJsObjectRef.InvokeVoidAsync(CREATE_OR_UPDATE, hostElementRef, popoverOptions);
    }

    public async Task ToggleAsync(ElementReference hostElementRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(TOGGLE, hostElementRef);
    }

    public async Task ShowAsync(ElementReference hostElementRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(SHOW, hostElementRef);
    }

    public async Task HideAsync(ElementReference hostElementRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(HIDE, hostElementRef);
    }

    public async Task UpdatePositionAsync(ElementReference hostElementRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(UPDATE_POSITION, hostElementRef);
    }

    public async Task DisposeReferenceAsync(ElementReference elementRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(DISPOSE, elementRef);
    }
}
