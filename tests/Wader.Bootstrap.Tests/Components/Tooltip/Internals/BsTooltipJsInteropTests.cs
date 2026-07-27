using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NSubstitute;
using Wader.Bootstrap.Components.Popover;
using Wader.Bootstrap.Components.Tooltip;
using Wader.Bootstrap.Components.Tooltip.Internals;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Tooltip.Internals;

public class BsTooltipJsInteropTests
{
    [Fact]
    public async Task CreateOrUpdate_CallsCreateOrUpdateJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsTooltipJsInterop(jsObj);
        var hostElementRef = new ElementReference("hostElement");
        var options = new BsTooltipJsOptions
        {
            CustomClass = "",
            Placement = BsPopoverPlacement.Top,
            Trigger = BsPopoverTrigger.Click,
        };
        var serializedOptions = options.ToSerializedOptions();

        // Act
        await sut.CreateOrUpdateAsync(hostElementRef, options);

        // Assert
        AssertJsInterop.Calls(jsObj, BsTooltipJsInterop.CREATE_OR_UPDATE, hostElementRef, serializedOptions);
    }

    [Fact]
    public async Task Toggle_CallsToggleJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsTooltipJsInterop(jsObj);
        var hostElementRef = new ElementReference("hostElement");

        // Act
        await sut.ToggleAsync(hostElementRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsTooltipJsInterop.TOGGLE, hostElementRef);
    }

    [Fact]
    public async Task Show_CallsShowJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsTooltipJsInterop(jsObj);
        var hostElementRef = new ElementReference("hostElement");

        // Act
        await sut.ShowAsync(hostElementRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsTooltipJsInterop.SHOW, hostElementRef);
    }

    [Fact]
    public async Task Hide_CallsHideJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsTooltipJsInterop(jsObj);
        var hostElementRef = new ElementReference("hostElement");

        // Act
        await sut.HideAsync(hostElementRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsTooltipJsInterop.HIDE, hostElementRef);
    }

    [Fact]
    public async Task UpdatePosition_CallsUpdatePositionJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsTooltipJsInterop(jsObj);
        var hostElementRef = new ElementReference("hostElement");

        // Act
        await sut.UpdatePositionAsync(hostElementRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsTooltipJsInterop.UPDATE_POSITION, hostElementRef);
    }

    [Fact]
    public async Task Enable_CallsUpdatePositionJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsTooltipJsInterop(jsObj);
        var hostElementRef = new ElementReference("hostElement");

        // Act
        await sut.EnableAsync(hostElementRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsTooltipJsInterop.ENABLE, hostElementRef);
    }

    [Fact]
    public async Task Disable_CallsUpdatePositionJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsTooltipJsInterop(jsObj);
        var hostElementRef = new ElementReference("hostElement");

        // Act
        await sut.DisableAsync(hostElementRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsTooltipJsInterop.DISABLE, hostElementRef);
    }

    [Fact]
    public async Task ToggleEnable_CallsUpdatePositionJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsTooltipJsInterop(jsObj);
        var hostElementRef = new ElementReference("hostElement");

        // Act
        await sut.ToggleEnabledAsync(hostElementRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsTooltipJsInterop.TOGGLE_ENABLE, hostElementRef);
    }

    [Fact]
    public async Task DisposeReference_CallsDisposeJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsTooltipJsInterop(jsObj);
        var elementRef = new ElementReference("hostElement");

        // Act
        await sut.DisposeReferenceAsync(elementRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsTooltipJsInterop.DISPOSE, elementRef);
    }

    [Fact]
    public async Task Dispose_CallsJsDisposeAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        var sut = new BsTooltipJsInterop(jsObj);

        // Act + Assert
        await AssertJsInterop.Dispose_CallsJsDisposeAsync(sut, jsObj);
    }
}
