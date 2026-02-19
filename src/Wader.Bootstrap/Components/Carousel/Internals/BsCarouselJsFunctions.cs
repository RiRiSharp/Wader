using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap.Components.Carousel.Internals;

internal sealed class BsCarouselJsFunctions : IBsCarouselJsFunctions, IBsJsFunctionsWrapper, IAsyncDisposable
{
    public static string JsFileName => "carouselFunctions.js";
    private readonly IJSObjectReference _bsJsObjectRef;

    public BsCarouselJsFunctions(IJSObjectReference bsJsObjectRef)
    {
        _bsJsObjectRef = bsJsObjectRef;
    }

    internal const string MOVE_TO_SLIDE = "moveToSlide";

    public async Task MoveToSlideAsync(ElementReference carouselRef, int slideNumber)
    {
        await _bsJsObjectRef.InvokeVoidAsync(MOVE_TO_SLIDE, carouselRef, slideNumber);
    }

    internal const string MOVE_PREV = "movePrev";

    public async Task MovePrevAsync(ElementReference carouselRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(MOVE_PREV, carouselRef);
    }

    internal const string MOVE_NEXT = "moveNext";

    public async Task MoveNextAsync(ElementReference carouselRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(MOVE_NEXT, carouselRef);
    }

    internal const string CYCLE = "cycle";

    public async Task CycleAsync(ElementReference carouselRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(CYCLE, carouselRef);
    }

    internal const string PAUSE = "pause";

    public async Task PauseAsync(ElementReference carouselRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(PAUSE, carouselRef);
    }

    internal const string ADD_CYCLE_CALLBACK = "addCycleCallback";

    public async Task AddCycleCallbackAsync(ElementReference carouselRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(ADD_CYCLE_CALLBACK, carouselRef);
    }

    internal const string REMOVE_CYCLE_CALLBACK = "removeCycleCallback";

    public async Task RemoveCycleCallbackAsync(ElementReference carouselRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(REMOVE_CYCLE_CALLBACK, carouselRef);
    }

    internal const string DISPOSE = "dispose";

    public async Task DisposeAsync(ElementReference carouselRef)
    {
        await _bsJsObjectRef.InvokeVoidAsync(DISPOSE, carouselRef);
    }

    public async ValueTask DisposeAsync()
    {
        await _bsJsObjectRef.DisposeAsync();
    }
}
