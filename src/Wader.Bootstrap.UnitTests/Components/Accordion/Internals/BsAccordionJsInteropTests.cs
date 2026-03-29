using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NSubstitute;
using Wader.Bootstrap.Components.Accordion.Internals;

namespace Wader.Bootstrap.UnitTests.Components.Accordion.Internals;

public class BsAccordionJsInteropTests : BunitContext
{
    [Fact]
    public async Task CollapseAllCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsAccordionJsInterop(jsObj);
        ElementReference accordionRef = default;

        // Act
        await sut.CollapseAllAsync(accordionRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsAccordionJsInterop.COLLAPSE_ALL, accordionRef);
    }

    [Fact]
    public async Task ShowAllCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsAccordionJsInterop(jsObj);
        ElementReference accordionRef = default;

        // Act
        await sut.ShowAllAsync(accordionRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsAccordionJsInterop.SHOW_ALL, accordionRef);
    }

    [Fact]
    public async Task CollapseAllButOneCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsAccordionJsInterop(jsObj);
        ElementReference accordionRef = default;
        ElementReference itemRef = default;

        // Act
        await sut.CollapseAllButOneAsync(accordionRef, itemRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsAccordionJsInterop.COLLAPSE_ALL_BUT_ONE, accordionRef, itemRef);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task ToggleCallsCorrectJsFunctionAsync(bool alwaysOpen)
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsAccordionJsInterop(jsObj);
        ElementReference itemRef = default;

        // Act
        await sut.ToggleAsync(itemRef, alwaysOpen);

        // Assert
        AssertJsInterop.Calls(jsObj, BsAccordionJsInterop.TOGGLE, itemRef, alwaysOpen);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task ShowCallsCorrectJsFunctionAsync(bool alwaysOpen)
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsAccordionJsInterop(jsObj);
        ElementReference itemRef = default;

        // Act
        await sut.ShowAsync(itemRef, alwaysOpen);

        // Assert
        AssertJsInterop.Calls(jsObj, BsAccordionJsInterop.SHOW, itemRef, alwaysOpen);
    }

    [Fact]
    public async Task CollapseCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsAccordionJsInterop(jsObj);
        ElementReference itemRef = default;

        // Act
        await sut.CollapseAsync(itemRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsAccordionJsInterop.COLLAPSE, itemRef);
    }

    [Fact]
    public async Task RegisterCollapseCallbackCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsAccordionJsInterop(jsObj);
        ElementReference buttonRef = default;
        DotNetObjectReference<IHasCollapseState> dotNetRef = null!;

        // Act
        await sut.RegisterCollapseCallbackAsync(buttonRef, dotNetRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsAccordionJsInterop.REGISTER_COLLAPSE_CALLBACK, buttonRef, dotNetRef);
    }

    [Fact]
    public async Task DisposeCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsAccordionJsInterop(jsObj);
        ElementReference accordionItemRef = default;

        // Act
        await sut.DisposeReferenceAsync(accordionItemRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsAccordionJsInterop.DISPOSE, accordionItemRef);
    }
}
