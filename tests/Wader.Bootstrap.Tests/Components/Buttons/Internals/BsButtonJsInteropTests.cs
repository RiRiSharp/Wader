using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NSubstitute;
using Wader.Bootstrap.Components.Buttons.Internals;

namespace Wader.Bootstrap.Tests.Components.Buttons.Internals;

public class BsButtonJsInteropTests
{
    [Fact]
    public async Task ToggleCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsButtonJsInterop(jsObj);
        var alertRef = new ElementReference("alert");

        // Act
        await sut.ToggleAsync(alertRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsButtonJsInterop.TOGGLE, alertRef);
    }

    [Fact]
    public async Task JsDisposingCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsButtonJsInterop(jsObj);
        var alertRef = new ElementReference("alert");

        // Act
        await sut.DisposeReferenceAsync(alertRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsButtonJsInterop.DISPOSE, alertRef);
    }
}
