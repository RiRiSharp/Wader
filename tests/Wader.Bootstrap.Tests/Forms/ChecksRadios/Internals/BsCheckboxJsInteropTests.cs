using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NSubstitute;
using Wader.Bootstrap.Forms.ChecksRadios.Internals;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Forms.ChecksRadios.Internals;

public class BsCheckboxJsInteropTests : BunitContext
{
    [Fact]
    public async Task CallingInitializeIndeterminateCallsCorrectJsFunctionOnceAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsCheckboxJsInterop(jsObj);
        var checkboxRef = new ElementReference("checkbox");

        // Act
        await sut.InitializeIndeterminateAsync(checkboxRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsCheckboxJsInterop.INITIALIZE_INDETERMINATE, checkboxRef);
    }
}
