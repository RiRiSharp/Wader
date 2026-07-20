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
    public async Task Create_WithoutOptions_UsesDefaultOptionValues()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsScrollspyJsInterop(jsObj);
        var hostElementRef = new ElementReference("host");
        var targetElementRef = new ElementReference("target");
        var defaultOptions = new ScrollspyJsOptions();

        ScrollspyJsOptions? capturedOptions = null;
        jsObj
            .When(async x => await x.InvokeVoidAsync(Arg.Any<string>(), Arg.Any<object[]>()))
            .Do(call =>
            {
                var args = call.Arg<object[]>();
                capturedOptions = args?[2] as ScrollspyJsOptions;
            });

        // Act
        await sut.CreateAsync(hostElementRef, targetElementRef);

        // Assert
        Assert.NotNull(capturedOptions);
        Assert.Equivalent(capturedOptions, defaultOptions);
    }

    [Fact]
    public async Task Create_WithOptions_DoesNotModifyOptions()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsScrollspyJsInterop(jsObj);
        var hostElementRef = new ElementReference("host");
        var targetElementRef = new ElementReference("target");
        var options = new ScrollspyJsOptions
        {
            RootMargin = "Epic margin",
            Threshold = [1, 3, 3, 7],
            SmoothScroll = true,
        };

        ScrollspyJsOptions? capturedOptions = null;
        jsObj
            .When(async x => await x.InvokeVoidAsync(Arg.Any<string>(), Arg.Any<object[]>()))
            .Do(call =>
            {
                var args = call.Arg<object[]>();
                capturedOptions = args?[2] as ScrollspyJsOptions;
            });

        // Act
        await sut.CreateAsync(hostElementRef, targetElementRef, options);

        // Assert
        Assert.NotNull(capturedOptions);
        Assert.Equal(expected: "Epic margin", capturedOptions.RootMargin);
        Assert.Equal([1, 3, 3, 7], capturedOptions.Threshold);
        Assert.True(capturedOptions!.SmoothScroll);
    }

    [Fact]
    public async Task DisposeReference_CallsDisposeJsFunction()
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
