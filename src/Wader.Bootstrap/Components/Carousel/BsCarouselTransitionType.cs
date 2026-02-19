namespace Wader.Bootstrap.Components.Carousel;

public enum BsCarouselTransitionType
{
    Slide = 0,
    Crossfade = 1,
}

internal static class BsCarouselTransitionTypeExtensions
{
    internal static string? ToBootstrapClass(this BsCarouselTransitionType transitionType)
    {
        return transitionType switch
        {
            BsCarouselTransitionType.Slide => null,
            BsCarouselTransitionType.Crossfade => "carousel-fade",
            _ => throw new ArgumentOutOfRangeException(nameof(transitionType), transitionType, null),
        };
    }
}
