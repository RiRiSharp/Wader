using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NSubstitute;
using Wader.Bootstrap.Components.Carousel.Internals;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Carousel.Internals;

public class BsCarouselJsInteropTests
{
    [Fact]
    public async Task MoveToSlide_CallsMoveToSlideJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCarouselJsInterop(jsObj);
        var carouselRef = new ElementReference("carousel");
        const int slideNumber = 1337;

        // Act
        await sut.MoveToSlideAsync(carouselRef, slideNumber);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCarouselJsInterop.MOVE_TO_SLIDE, carouselRef, slideNumber);
    }

    [Fact]
    public async Task MovePrev_CallsMovePrevJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCarouselJsInterop(jsObj);
        var carouselRef = new ElementReference("carousel");

        // Act
        await sut.MovePrevAsync(carouselRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCarouselJsInterop.MOVE_PREV, carouselRef);
    }

    [Fact]
    public async Task MoveNext_CallsMoveNextJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCarouselJsInterop(jsObj);
        var carouselRef = new ElementReference("carousel");

        // Act
        await sut.MoveNextAsync(carouselRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCarouselJsInterop.MOVE_NEXT, carouselRef);
    }

    [Fact]
    public async Task Cycle_CallsCycleJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCarouselJsInterop(jsObj);
        var carouselRef = new ElementReference("carousel");

        // Act
        await sut.CycleAsync(carouselRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCarouselJsInterop.CYCLE, carouselRef);
    }

    [Fact]
    public async Task Pause_CallsPauseJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCarouselJsInterop(jsObj);
        var carouselRef = new ElementReference("carousel");

        // Act
        await sut.PauseAsync(carouselRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCarouselJsInterop.PAUSE, carouselRef);
    }

    [Fact]
    public async Task AddCycleCallback_CallsAddCycleCallbackJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCarouselJsInterop(jsObj);
        var carouselRef = new ElementReference("carousel");

        // Act
        await sut.AddCycleCallbackAsync(carouselRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCarouselJsInterop.ADD_CYCLE_CALLBACK, carouselRef);
    }

    [Fact]
    public async Task RemoveCycleCallback_CallsRemoveCycleCallbackJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCarouselJsInterop(jsObj);
        var carouselRef = new ElementReference("carousel");

        // Act
        await sut.RemoveCycleCallbackAsync(carouselRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCarouselJsInterop.REMOVE_CYCLE_CALLBACK, carouselRef);
    }

    [Fact]
    public async Task DisposeReference_CallsDisposeJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCarouselJsInterop(jsObj);
        var carouselRef = new ElementReference("carousel");

        // Act
        await sut.DisposeReferenceAsync(carouselRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCarouselJsInterop.DISPOSE, carouselRef);
    }

    [Fact]
    public async Task Dispose_CallsJsDisposeAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        var sut = new BsCarouselJsInterop(jsObj);

        // Act + Assert
        await AssertJsInterop.Dispose_CallsJsDisposeAsync(sut, jsObj);
    }
}
