using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap.Components.Carousel.Internals;

public interface IBsCarouselJsInterop : IBsJsDisposable
{
    Task MoveToSlideAsync(ElementReference carouselRef, int slideNumber);
    Task MovePrevAsync(ElementReference carouselRef);
    Task MoveNextAsync(ElementReference carouselRef);
    Task CycleAsync(ElementReference carouselRef);
    Task PauseAsync(ElementReference carouselRef);
    internal Task AddCycleCallbackAsync(ElementReference carouselRef);
    internal Task RemoveCycleCallbackAsync(ElementReference carouselRef);
}
