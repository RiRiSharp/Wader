namespace Wader.Bootstrap.Components.Carousel.Internals;

public class BsCarouselException : Exception
{
    public BsCarouselException() { }

    public BsCarouselException(string? message)
        : base(message) { }

    public BsCarouselException(string? message, Exception? innerException)
        : base(message, innerException) { }
}
