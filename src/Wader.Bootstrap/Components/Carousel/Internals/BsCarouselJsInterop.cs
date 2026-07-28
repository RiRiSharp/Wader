using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Internal.JsInterop;

namespace Wader.Bootstrap.Components.Carousel.Internals;

internal sealed class BsCarouselJsInterop : IBsCarouselJsInterop, IBsJsFunctionsWrapper, IAsyncDisposable
{
    internal const string MOVE_TO_SLIDE = "moveToSlide";

    internal const string MOVE_PREV = "movePrev";

    internal const string MOVE_NEXT = "moveNext";

    internal const string CYCLE = "cycle";

    internal const string PAUSE = "pause";

    internal const string ADD_CYCLE_CALLBACK = "addCycleCallback";

    internal const string REMOVE_CYCLE_CALLBACK = "removeCycleCallback";

    internal const string DISPOSE = "dispose";
    private readonly IJSObjectReference _bsJsObjectRef;

    public BsCarouselJsInterop(IJSObjectReference bsJsObjectRef)
    {
        _bsJsObjectRef = bsJsObjectRef;
    }

    public async ValueTask DisposeAsync()
    {
        await _bsJsObjectRef.DisposeAsync();
    }

    public async Task MoveToSlideAsync(ElementReference carouselRef, int slideNumber)
    {
        await _bsJsObjectRef.InvokeVoidAsync(MOVE_TO_SLIDE, carouselRef, slideNumber);
    }

    public async Task MovePrevAsync(ElementReference carouselRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(MOVE_PREV, carouselRef);
    }

    public async Task MoveNextAsync(ElementReference carouselRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(MOVE_NEXT, carouselRef);
    }

    public async Task CycleAsync(ElementReference carouselRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(CYCLE, carouselRef);
    }

    public async Task PauseAsync(ElementReference carouselRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(PAUSE, carouselRef);
    }

    public async Task AddCycleCallbackAsync(ElementReference carouselRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(ADD_CYCLE_CALLBACK, carouselRef);
    }

    public async Task RemoveCycleCallbackAsync(ElementReference carouselRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(REMOVE_CYCLE_CALLBACK, carouselRef);
    }

    public async Task DisposeReferenceAsync(ElementReference carouselRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(DISPOSE, carouselRef);
    }

    public static string JsFileName => "carouselFunctions.js";
}
