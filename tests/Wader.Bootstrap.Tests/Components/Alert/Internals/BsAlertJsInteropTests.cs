using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NSubstitute;
using Wader.Bootstrap.Components.Alert;
using Wader.Bootstrap.Components.Alert.Internals;

namespace Wader.Bootstrap.Tests.Components.Alert.Internals;

public class BsAlertJsInteropTests
{
    [Fact]
    public async Task DismissCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsAlertJsInterop(jsObj);
        var alertRef = new ElementReference("alert");

        // Act
        await sut.DismissAsync(alertRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsAlertJsInterop.DISMISS, alertRef);
    }

    [Fact]
    public async Task RegisterDismissCallbackCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsAlertJsInterop(jsObj);
        var alertRef = new ElementReference("alert");
        DotNetObjectReference<BsAlert> dotNetRef = null!;

        // Act
        await sut.RegisterDismissCallbackAsync(alertRef, dotNetRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsAlertJsInterop.REGISTER_DISMISS_CALLBACK, alertRef, dotNetRef);
    }

    [Fact]
    public async Task DisposeReferenceCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsAlertJsInterop(jsObj);
        var alertRef = new ElementReference("alert");

        // Act
        await sut.DisposeReferenceAsync(alertRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsAlertJsInterop.DISPOSE, alertRef);
    }

    [Fact]
    public async Task DisposeDisposesUnderlyingJsReferenceAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        var sut = new BsAlertJsInterop(jsObj);

        // Act + Assert
        await AssertJsInterop.DisposeDisposesUnderlyingJsReferenceAsync(sut, jsObj);
    }
}
