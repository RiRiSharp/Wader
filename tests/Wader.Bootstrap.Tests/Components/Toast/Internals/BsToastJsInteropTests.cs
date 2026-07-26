using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NSubstitute;
using Wader.Bootstrap.Components.Toasts.Internals;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Toast.Internals;

public class BsToastJsInteropTests
{
    [Fact]
    public async Task Create_CallsCreateJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsToastJsInterop(jsObj);
        var toastElementRef = new ElementReference("toast");

        // Act
        await sut.CreateAsync(toastElementRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsToastJsInterop.CREATE, toastElementRef, null);
    }

    [Fact]
    public async Task Create_WithOptions_CallsCreateJsFunctionWithOptions()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsToastJsInterop(jsObj);
        var toastElementRef = new ElementReference("toast");
        var options = new ToastJsOptions
        {
            Animation = true,
            AutoHide = false,
            Delay = 67,
        };

        // Act
        await sut.CreateAsync(toastElementRef, options);

        // Assert
        AssertJsInterop.Calls(jsObj, BsToastJsInterop.CREATE, toastElementRef, options);
    }

    [Fact]
    public async Task Create_WithOptions_DoesNotModifyOptions()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsToastJsInterop(jsObj);
        var toastElementRef = new ElementReference("toast");
        var options = new ToastJsOptions
        {
            Animation = true,
            AutoHide = false,
            Delay = 67,
        };

        ToastJsOptions? capturedOptions = null;
        jsObj
            .When(async x => await x.InvokeVoidAsync(Arg.Any<string>(), Arg.Any<object[]>()))
            .Do(call =>
            {
                var args = call.Arg<object[]>();
                capturedOptions = args?[1] as ToastJsOptions;
            });

        // Act
        await sut.CreateAsync(toastElementRef, options);

        // Assert
        Assert.NotNull(capturedOptions);
        Assert.True(capturedOptions!.Animation);
        Assert.False(capturedOptions.AutoHide);
        Assert.Equal(expected: 67, capturedOptions.Delay);
    }

    [Fact]
    public async Task Show_CallsShowJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsToastJsInterop(jsObj);
        var toastElementRef = new ElementReference("toast");

        // Act
        await sut.ShowAsync(toastElementRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsToastJsInterop.SHOW, toastElementRef);
    }

    [Fact]
    public async Task Hide_CallsHideJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsToastJsInterop(jsObj);
        var toastElementRef = new ElementReference("toast");

        // Act
        await sut.HideAsync(toastElementRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsToastJsInterop.HIDE, toastElementRef);
    }

    [Fact]
    public async Task DisposeReference_CallsDisposeJsFunction()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        await using var sut = new BsToastJsInterop(jsObj);
        var elementRef = new ElementReference("toast");

        // Act
        await sut.DisposeReferenceAsync(elementRef);

        // Assert
        AssertJsInterop.Calls(jsObj, BsToastJsInterop.DISPOSE, elementRef);
    }

    [Fact]
    public async Task Dispose_CallsJsDisposeAsync()
    {
        // Arrange
        var jsObj = Substitute.For<IJSObjectReference>();
        var sut = new BsToastJsInterop(jsObj);

        // Act + Assert
        await AssertJsInterop.Dispose_CallsJsDisposeAsync(sut, jsObj);
    }
}
