using NSubstitute;
using Wader.Bootstrap.Components.Popover;
using Wader.Bootstrap.Components.Popover.Internals;

namespace Wader.Bootstrap.Tests.Components.Popover;

public partial class BsPopoverTests() : BsComponentTests<BsPopover>("""<div class="{0}" {1}></div>""")
{
    private readonly IBsPopoverJsInterop _offcanvasJsInteropMock = Substitute.For<IBsPopoverJsInterop>();
    protected override string ClassesForDefaultTests => "d-inline-block";

    [Fact]
    public async Task OnAfterRenderCallsJsCorrectlyAsync()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();

        // Assert
        await _offcanvasJsInteropMock
            .Received(1)
            .CreateOrUpdateAsync(cut.Instance.HostElementRef, Arg.Any<PopoverJsOptions>());
    }

    [Fact]
    public async Task ToggleCallsJsCorrectlyAsync()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.Instance.ToggleAsync();

        // Assert
        await _offcanvasJsInteropMock.Received(1).ToggleAsync(cut.Instance.HostElementRef);
    }

    [Fact]
    public async Task ShowCallsJsCorrectlyAsync()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.Instance.ShowAsync();

        // Assert
        await _offcanvasJsInteropMock.Received(1).ShowAsync(cut.Instance.HostElementRef);
    }

    [Fact]
    public async Task HideCallsJsCorrectlyAsync()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.Instance.HideAsync();

        // Assert
        await _offcanvasJsInteropMock.Received(1).HideAsync(cut.Instance.HostElementRef);
    }

    [Fact]
    public async Task UpdatePositionCallsJsCorrectlyAsync()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.Instance.UpdatePositionAsync();

        // Assert
        await _offcanvasJsInteropMock.Received(1).UpdatePositionAsync(cut.Instance.HostElementRef);
    }

    protected override void ConfigureTestContext()
    {
        _ = Services.AddSingleton(_offcanvasJsInteropMock);
    }
}
