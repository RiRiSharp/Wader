using NSubstitute;
using Wader.Components.Carousel;
using Wader.Components.Carousel.Internals;

namespace Wader.UnitTests.Components.Carousel;

public class BsCarouselTests() : BsComponentTests<BsCarousel>("""<div class="carousel slide {0}" {1}></div>""")
{
    protected override Dictionary<string, string> AttributesForDefaultTests => new() { ["data-bs-touch"] = "true" };
    private readonly IBsCarouselJsFunctions _carouselJsFunctionsMock = Substitute.For<IBsCarouselJsFunctions>();

    [Theory]
    [InlineData(BsCarouselAutoPlayMode.None, 0)]
    [InlineData(BsCarouselAutoPlayMode.AutoPlay, 1)]
    [InlineData(BsCarouselAutoPlayMode.AutoPlayAfterUserInteraction, 0)]
    public async Task CycleGetsCalledInCorrectUserModeAsync(BsCarouselAutoPlayMode mode, int noOfCalls)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.AutoPlay, mode));

        // Assert
        await _carouselJsFunctionsMock.Received(noOfCalls).CycleAsync(cut.Instance.HtmlRef);
    }

    [Theory]
    [InlineData(BsCarouselAutoPlayMode.None, 0)]
    [InlineData(BsCarouselAutoPlayMode.AutoPlay, 0)]
    [InlineData(BsCarouselAutoPlayMode.AutoPlayAfterUserInteraction, 1)]
    public async Task CycleCallbackGetsCalledInCorrectUserModeAsync(BsCarouselAutoPlayMode mode, int noOfCalls)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.AutoPlay, mode));

        // Assert
        await _carouselJsFunctionsMock.Received(noOfCalls).AddCycleCallbackAsync(cut.Instance.HtmlRef);
    }

    [Theory]
    [InlineData(BsCarouselAutoPlayMode.None, 0)]
    [InlineData(BsCarouselAutoPlayMode.AutoPlay, 0)]
    [InlineData(BsCarouselAutoPlayMode.AutoPlayAfterUserInteraction, 2)] // 2 calls, one after render, one for the actual function call
    public async Task CycleCallbackGetsCalledInCorrectUserModeDuringMoveNextAsync(
        BsCarouselAutoPlayMode mode,
        int noOfCalls
    )
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.AutoPlay, mode));
        await cut.InvokeAsync(cut.Instance.MoveNextAsync);

        // Assert
        await _carouselJsFunctionsMock.Received(noOfCalls).AddCycleCallbackAsync(cut.Instance.HtmlRef);
    }

    [Theory]
    [InlineData(BsCarouselAutoPlayMode.None, 0)]
    [InlineData(BsCarouselAutoPlayMode.AutoPlay, 0)]
    [InlineData(BsCarouselAutoPlayMode.AutoPlayAfterUserInteraction, 2)] // 2 calls, one after render, one for the actual function call
    public async Task CycleCallbackGetsCalledInCorrectUserModeDuringMovePrevAsync(
        BsCarouselAutoPlayMode mode,
        int noOfCalls
    )
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.AutoPlay, mode));
        await cut.InvokeAsync(cut.Instance.MovePrevAsync);

        // Assert
        await _carouselJsFunctionsMock.Received(noOfCalls).AddCycleCallbackAsync(cut.Instance.HtmlRef);
    }

    [Theory]
    [InlineData(BsCarouselAutoPlayMode.None, 1)] // Everything receives one call during startup
    [InlineData(BsCarouselAutoPlayMode.AutoPlay, 1)]
    [InlineData(BsCarouselAutoPlayMode.AutoPlayAfterUserInteraction, 2)]
    public async Task RemoveCycleCallbackGetsCalledInCorrectUserModeDuringPauseAsync(
        BsCarouselAutoPlayMode mode,
        int noOfCalls
    )
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.AutoPlay, mode));
        await cut.InvokeAsync(cut.Instance.PauseAsync);

        // Assert
        await _carouselJsFunctionsMock.Received(noOfCalls).RemoveCycleCallbackAsync(cut.Instance.HtmlRef);
    }

    [Theory]
    [InlineData(BsCarouselTransitionType.Slide, "")]
    [InlineData(BsCarouselTransitionType.Crossfade, "carousel-fade")]
    public void TransitionTypeAddsCorrectClass(BsCarouselTransitionType variant, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.TransitionType, variant));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData(true, "true")]
    [InlineData(false, "false")]
    public void TouchEnabledAddsCorrectAttribute(bool enableTouch, string expectedAttributeValue)
    {
        // Arrange
        ConfigureTestContext();
        var attributes = AttributesForDefaultTests;
        attributes["data-bs-touch"] = expectedAttributeValue;

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.EnableTouch, enableTouch));

        // Assert
        var expectedMarkupString = GetExpectedHtml(ClassesForDefaultTests, attributes);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Fact]
    public async Task MoveNextCallsJsMoveNextAsync()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.InvokeAsync(cut.Instance.MoveNextAsync);

        // Assert
        await _carouselJsFunctionsMock.Received(1).MoveNextAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public async Task MovePrevCallsJsMovePrevAsync()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.InvokeAsync(cut.Instance.MovePrevAsync);

        // Assert
        await _carouselJsFunctionsMock.Received(1).MovePrevAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public async Task CycleCallsJsCycleAsync()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.InvokeAsync(cut.Instance.CycleAsync);

        // Assert
        await _carouselJsFunctionsMock.Received(1).CycleAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public async Task PauseCallsJsPauseAsync()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.InvokeAsync(cut.Instance.PauseAsync);

        // Assert
        await _carouselJsFunctionsMock.Received(1).PauseAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public void CarouselContextIsCascading()
    {
        TestForCascadingValue<IBsCarouselContext>();
    }

    protected override void ConfigureTestContext()
    {
        _ = Services.AddSingleton(_carouselJsFunctionsMock);
    }
}
