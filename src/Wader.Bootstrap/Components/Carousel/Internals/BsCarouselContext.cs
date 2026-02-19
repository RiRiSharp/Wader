namespace Wader.Bootstrap.Components.Carousel.Internals;

internal class BsCarouselContext(BsCarousel carousel) : IBsCarouselContext
{
    public async Task MoveToSlideAsync(int n)
    {
        await carousel.MoveToSlideAsync(n);
    }

    public async Task MovePrevAsync()
    {
        await carousel.MovePrevAsync();
    }

    public async Task MoveNextAsync()
    {
        await carousel.MoveNextAsync();
    }

    public async Task CycleAsync()
    {
        await carousel.CycleAsync();
    }

    public async Task PauseAsync()
    {
        await carousel.PauseAsync();
    }
}
