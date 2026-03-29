using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NSubstitute;
using Wader.Bootstrap.Components.Modal.Internals;

namespace Wader.Bootstrap.UnitTests.Components.Modal.Internals;

public class BsModalJsInteropTests
{
    [Fact]
    public async Task ToggleCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsModalJsInterop(jsObj);
        ElementReference modalRef = default;

        // Act
        await sut.ToggleAsync(modalRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsModalJsInterop.TOGGLE, modalRef);
    }

    [Fact]
    public async Task ShowCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsModalJsInterop(jsObj);
        ElementReference modalRef = default;

        // Act
        await sut.ShowAsync(modalRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsModalJsInterop.SHOW, modalRef);
    }

    [Fact]
    public async Task CloseCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsModalJsInterop(jsObj);
        ElementReference modalRef = default;

        // Act
        await sut.CloseAsync(modalRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsModalJsInterop.CLOSE, modalRef);
    }

    [Fact]
    public async Task HandleUpdateCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsModalJsInterop(jsObj);
        ElementReference modalRef = default;

        // Act
        await sut.HandleUpdateAsync(modalRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsModalJsInterop.HANDLE_UPDATE, modalRef);
    }

    [Fact]
    public async Task DisposeCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsModalJsInterop(jsObj);
        ElementReference modalRef = default;

        // Act
        await sut.DisposeReferenceAsync(modalRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsModalJsInterop.DISPOSE, modalRef);
    }
}
