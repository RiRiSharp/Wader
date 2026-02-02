using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NSubstitute;
using Wader.Components.Buttons.Internals;

namespace Wader.UnitTests.Components.Buttons.Internals;

public class BsButtonJsFunctionsTests
{
    [Fact]
    public async Task ToggleCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsButtonJsFunctions(jsObj);
        ElementReference alertRef = default;

        // Act
        await sut.ToggleAsync(alertRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsButtonJsFunctions.TOGGLE, alertRef);
    }

    [Fact]
    public async Task JsDisposingCallsCorrectJsFunctionAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsButtonJsFunctions(jsObj);
        ElementReference alertRef = default;

        // Act
        await sut.DisposeAsync(alertRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsButtonJsFunctions.DISPOSE, alertRef);
    }
}
