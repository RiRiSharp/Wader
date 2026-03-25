using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NSubstitute;
using Wader.Bootstrap.Components.Carousel.Internals;

namespace Wader.Bootstrap.UnitTests.Components.Carousel.Internals;

public class BsCarouselJsFunctionsTests
{
    [Fact]
    public async Task MoveToSlideCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCarouselJsFunctions(jsObj);
        ElementReference carouselRef = default;
        const int slideNumber = 1337;

        // Act
        await sut.MoveToSlideAsync(carouselRef, slideNumber);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCarouselJsFunctions.MOVE_TO_SLIDE, carouselRef, slideNumber);
    }

    [Fact]
    public async Task MovePrevCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCarouselJsFunctions(jsObj);
        ElementReference carouselRef = default;

        // Act
        await sut.MovePrevAsync(carouselRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCarouselJsFunctions.MOVE_PREV, carouselRef);
    }

    [Fact]
    public async Task MoveNextCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCarouselJsFunctions(jsObj);
        ElementReference carouselRef = default;

        // Act
        await sut.MoveNextAsync(carouselRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCarouselJsFunctions.MOVE_NEXT, carouselRef);
    }

    [Fact]
    public async Task CycleCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCarouselJsFunctions(jsObj);
        ElementReference carouselRef = default;

        // Act
        await sut.CycleAsync(carouselRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCarouselJsFunctions.CYCLE, carouselRef);
    }

    [Fact]
    public async Task PauseCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCarouselJsFunctions(jsObj);
        ElementReference carouselRef = default;

        // Act
        await sut.PauseAsync(carouselRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCarouselJsFunctions.PAUSE, carouselRef);
    }

    [Fact]
    public async Task AddCycleCallbackCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCarouselJsFunctions(jsObj);
        ElementReference carouselRef = default;

        // Act
        await sut.AddCycleCallbackAsync(carouselRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCarouselJsFunctions.ADD_CYCLE_CALLBACK, carouselRef);
    }

    [Fact]
    public async Task RemoveCycleCallbackCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCarouselJsFunctions(jsObj);
        ElementReference carouselRef = default;

        // Act
        await sut.RemoveCycleCallbackAsync(carouselRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCarouselJsFunctions.REMOVE_CYCLE_CALLBACK, carouselRef);
    }

    [Fact]
    public async Task DisposeCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCarouselJsFunctions(jsObj);
        ElementReference carouselRef = default;

        // Act
        await sut.DisposeReferenceAsync(carouselRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCarouselJsFunctions.DISPOSE, carouselRef);
    }
}
