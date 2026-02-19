using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NSubstitute;
using Wader.Bootstrap.Components.Collapse.Internals;

namespace Wader.Bootstrap.UnitTests.Components.Collapse.Internals;

public class BsCollapseJsFunctionsTests
{
    [Fact]
    public async Task ToggleCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCollapseJsFunctions(jsObj);
        ElementReference collapseRef = default;

        // Act
        await sut.ToggleAsync(collapseRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCollapseJsFunctions.TOGGLE, collapseRef);
    }

    [Fact]
    public async Task ShowCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCollapseJsFunctions(jsObj);
        ElementReference collapseRef = default;

        // Act
        await sut.ShowAsync(collapseRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCollapseJsFunctions.SHOW, collapseRef);
    }

    [Fact]
    public async Task CollapseCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCollapseJsFunctions(jsObj);
        ElementReference collapseRef = default;

        // Act
        await sut.CollapseAsync(collapseRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCollapseJsFunctions.COLLAPSE, collapseRef);
    }

    [Fact]
    public async Task DisposeCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCollapseJsFunctions(jsObj);
        ElementReference collapseRef = default;

        // Act
        await sut.DisposeAsync(collapseRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCollapseJsFunctions.DISPOSE, collapseRef);
    }
}
