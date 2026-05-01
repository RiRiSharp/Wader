using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NSubstitute;
using Wader.Bootstrap.Components.Modal.Internals;

namespace Wader.Bootstrap.Tests.Components.Modal.Internals;

public class BsModalJsInteropTests
{
    [Fact]
    public async Task Toggle_CallsToggleJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsModalJsInterop(jsObj);
        var modalRef = new ElementReference("modal");

        // Act
        await sut.ToggleAsync(modalRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsModalJsInterop.TOGGLE, modalRef);
    }

    [Fact]
    public async Task Show_CallsShowJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsModalJsInterop(jsObj);
        var modalRef = new ElementReference("modal");

        // Act
        await sut.ShowAsync(modalRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsModalJsInterop.SHOW, modalRef);
    }

    [Fact]
    public async Task Close_CallsCloseJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsModalJsInterop(jsObj);
        var modalRef = new ElementReference("modal");

        // Act
        await sut.CloseAsync(modalRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsModalJsInterop.CLOSE, modalRef);
    }

    [Fact]
    public async Task HandleUpdate_CallsHandleUpdateJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsModalJsInterop(jsObj);
        var modalRef = new ElementReference("modal");

        // Act
        await sut.HandleUpdateAsync(modalRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsModalJsInterop.HANDLE_UPDATE, modalRef);
    }

    [Fact]
    public async Task Dispose_CallsDisposeJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsModalJsInterop(jsObj);
        var modalRef = new ElementReference("modal");

        // Act
        await sut.DisposeReferenceAsync(modalRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsModalJsInterop.DISPOSE, modalRef);
    }

    [Fact]
    public async Task Dispose_CallsJsDisposeAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        var sut = new BsModalJsInterop(jsObj);

        // Act + Assert
        await AssertJsInterop.Dispose_CallsJsDisposeAsync(sut, jsObj);
    }
}
