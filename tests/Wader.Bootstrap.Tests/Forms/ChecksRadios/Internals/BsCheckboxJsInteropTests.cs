using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NSubstitute;
using Wader.Bootstrap.Forms.ChecksRadios.Internals;

namespace Wader.Bootstrap.Tests.Forms.ChecksRadios.Internals;

public class BsCheckboxJsInteropTests : BunitContext
{
    [Fact]
    public async Task CallingInitializeIndeterminateCallsCorrectJsFunctionOnceAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCheckboxJsInterop(jsObj);
        ElementReference checkboxRef = default;

        // Act
        await sut.InitializeIndeterminateAsync(checkboxRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCheckboxJsInterop.INITIALIZE_INDETERMINATE, checkboxRef);
    }
}
