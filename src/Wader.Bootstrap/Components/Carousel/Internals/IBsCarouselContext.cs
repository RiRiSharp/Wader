namespace Wader.Bootstrap.Components.Carousel.Internals;

public interface IBsCarouselContext
{
    Task MoveToSlideAsync(int n);
    Task MovePrevAsync();
    Task MoveNextAsync();
    Task CycleAsync();
    Task PauseAsync();
}
