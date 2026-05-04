using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NSubstitute;
using Wader.Bootstrap.Components.Popover.Internals;

namespace Wader.Bootstrap.Tests.Components.Popover.Internals;

public class BsPopoverJsInteropTests
{
    [Fact]
    public async Task CreateOrUpdate_CallsCreateOrUpdateJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsPopoverJsInterop(jsObj);
        var hostElementRef = new ElementReference("hostElement");
        var options = new PopoverJsOptions
        {
            CustomClass = "",
            Placement = "top",
            Trigger = "click",
        };

        // Act
        await sut.CreateOrUpdateAsync(hostElementRef, options);

        // Assert
        AssertJsInterop.Calls(jsObj, BsPopoverJsInterop.CREATE_OR_UPDATE, hostElementRef, options);
    }

    [Fact]
    public async Task Toggle_CallsToggleJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsPopoverJsInterop(jsObj);
        var hostElementRef = new ElementReference("hostElement");

        // Act
        await sut.ToggleAsync(hostElementRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsPopoverJsInterop.TOGGLE, hostElementRef);
    }

    [Fact]
    public async Task Show_CallsShowJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsPopoverJsInterop(jsObj);
        var hostElementRef = new ElementReference("hostElement");

        // Act
        await sut.ShowAsync(hostElementRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsPopoverJsInterop.SHOW, hostElementRef);
    }

    [Fact]
    public async Task Hide_CallsHideJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsPopoverJsInterop(jsObj);
        var hostElementRef = new ElementReference("hostElement");

        // Act
        await sut.HideAsync(hostElementRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsPopoverJsInterop.HIDE, hostElementRef);
    }

    [Fact]
    public async Task UpdatePosition_CallsUpdatePositionJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsPopoverJsInterop(jsObj);
        var hostElementRef = new ElementReference("hostElement");

        // Act
        await sut.UpdatePositionAsync(hostElementRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsPopoverJsInterop.UPDATE_POSITION, hostElementRef);
    }

    [Fact]
    public async Task DisposeReference_CallsDisposeJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsPopoverJsInterop(jsObj);
        var elementRef = new ElementReference("hostElement");

        // Act
        await sut.DisposeReferenceAsync(elementRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsPopoverJsInterop.DISPOSE, elementRef);
    }

    [Fact]
    public async Task Dispose_CallsJsDisposeAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        var sut = new BsPopoverJsInterop(jsObj);

        // Act + Assert
        await AssertJsInterop.Dispose_CallsJsDisposeAsync(sut, jsObj);
    }
}
