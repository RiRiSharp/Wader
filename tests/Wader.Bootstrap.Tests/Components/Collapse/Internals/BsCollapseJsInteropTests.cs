using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NSubstitute;
using Wader.Bootstrap.Components.Collapse.Internals;

namespace Wader.Bootstrap.Tests.Components.Collapse.Internals;

public class BsCollapseJsInteropTests
{
    [Fact]
    public async Task Toggle_CallsToggleJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCollapseJsInterop(jsObj);
        var collapseRef = new ElementReference("collapse");

        // Act
        await sut.ToggleAsync(collapseRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCollapseJsInterop.TOGGLE, collapseRef);
    }

    [Fact]
    public async Task Show_CallsShowJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCollapseJsInterop(jsObj);
        var collapseRef = new ElementReference("collapse");

        // Act
        await sut.ShowAsync(collapseRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCollapseJsInterop.SHOW, collapseRef);
    }

    [Fact]
    public async Task Collapse_CallsCollapseJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCollapseJsInterop(jsObj);
        var collapseRef = new ElementReference("collapse");

        // Act
        await sut.CollapseAsync(collapseRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCollapseJsInterop.COLLAPSE, collapseRef);
    }

    [Fact]
    public async Task DisposeReference_CallsDisposeJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCollapseJsInterop(jsObj);
        var collapseRef = new ElementReference("collapse");

        // Act
        await sut.DisposeReferenceAsync(collapseRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCollapseJsInterop.DISPOSE, collapseRef);
    }

    [Fact]
    public async Task Dispose_CallsJsDisposeAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        var sut = new BsCollapseJsInterop(jsObj);

        // Act + Assert
        await AssertJsInterop.Dispose_CallsJsDisposeAsync(sut, jsObj);
    }
}
