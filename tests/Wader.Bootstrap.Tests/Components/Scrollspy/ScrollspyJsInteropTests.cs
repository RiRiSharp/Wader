using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NSubstitute;
using Wader.Bootstrap.Components.Scrollspy;

namespace Wader.Bootstrap.Tests.Components.Scrollspy;

public class ScrollspyJsInteropTests
{
    [Fact]
    public async Task Create_CallsCreateJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsScrollspyJsInterop(jsObj);
        var hostElementRef = new ElementReference("host");
        var targetElementRef = new ElementReference("target");
        var options = new ScrollspyJsOptions();

        // Act
        await sut.CreateAsync(hostElementRef, targetElementRef, options);

        // Assert
        AssertJsInterop.Calls(jsObj, BsScrollspyJsInterop.CREATE, hostElementRef, targetElementRef, options);
    }

    [Fact]
    public async Task CreateWithoutOptionsGetsOptionsAssignedAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsScrollspyJsInterop(jsObj);
        var hostElementRef = new ElementReference("host");
        var targetElementRef = new ElementReference("target");

        // Act
        await sut.CreateAsync(hostElementRef, targetElementRef);

        // Assert
        await jsObj
            .Received(1)
            .InvokeVoidAsync(
                BsScrollspyJsInterop.CREATE,
                Arg.Is<object[]>(args => args.Length == 3 && args[2] is ScrollspyJsOptions)
            );
    }

    [Fact]
    public async Task CreateWithoutOptionsUsesExpectedDefaultOptionValuesAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsScrollspyJsInterop(jsObj);
        var hostElementRef = new ElementReference("host");
        var targetElementRef = new ElementReference("target");

        ScrollspyJsOptions? capturedOptions = null;
        jsObj
            .When(async x => await x.InvokeVoidAsync(Arg.Any<string>(), Arg.Any<object[]>()))
            .Do(call =>
            {
                var args = call.Arg<object[]>();
                capturedOptions = args[2] as ScrollspyJsOptions;
            });

        // Act
        await sut.CreateAsync(hostElementRef, targetElementRef);

        // Assert
        Assert.NotNull(capturedOptions);
        Assert.Equal("0px 0px -25%", capturedOptions!.RootMargin);
        Assert.Equal([0.1, 0.5, 1], capturedOptions.Threshold);
    }

    [Fact]
    public async Task DisposeReference_CallsCorrectJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsScrollspyJsInterop(jsObj);
        var hostElementRef = new ElementReference("hostElement");

        // Act
        await sut.DisposeReferenceAsync(hostElementRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsScrollspyJsInterop.DISPOSE, hostElementRef);
    }

    [Fact]
    public async Task Dispose_CallsJsDispose()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        var sut = new BsScrollspyJsInterop(jsObj);

        // Act + Assert
        await AssertJsInterop.Dispose_CallsJsDisposeAsync(sut, jsObj);
    }
}
