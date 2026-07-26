using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NSubstitute;
using Wader.Bootstrap.Components.Buttons.Internals;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Buttons.Internals;

public class BsButtonJsInteropTests
{
    [Fact]
    public async Task Toggle_CallsToggleJsFunction()
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
    public async Task DisposeReference_CallsDisposeJsFunction()
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

    [Fact]
    public async Task Dispose_CallsJsDisposeAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        var sut = new BsButtonJsInterop(jsObj);

        // Act + Assert
        await AssertJsInterop.Dispose_CallsJsDisposeAsync(sut, jsObj);
    }
}
