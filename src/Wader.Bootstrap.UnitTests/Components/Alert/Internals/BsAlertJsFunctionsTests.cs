using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NSubstitute;
using Wader.Bootstrap.Components.Alert;
using Wader.Bootstrap.Components.Alert.Internals;

namespace Wader.Bootstrap.UnitTests.Components.Alert.Internals;

public class BsAlertJsFunctionsTests
{
    [Fact]
    public async Task DismissCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsAlertJsFunctions(jsObj);
        ElementReference alertRef = default;

        // Act
        await sut.DismissAsync(alertRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsAlertJsFunctions.DISMISS, alertRef);
    }

    [Fact]
    public async Task RegisterDismissCallbackCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsAlertJsFunctions(jsObj);
        ElementReference alertRef = default;
        DotNetObjectReference<BsAlert> dotNetRef = null!;

        // Act
        await sut.RegisterDismissCallbackAsync(alertRef, dotNetRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsAlertJsFunctions.REGISTER_DISMISS_CALLBACK, alertRef, dotNetRef);
    }

    [Fact]
    public async Task DisposeCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsAlertJsFunctions(jsObj);
        ElementReference alertRef = default;

        // Act
        await sut.DisposeAsync(alertRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsAlertJsFunctions.DISPOSE, alertRef);
    }
}
