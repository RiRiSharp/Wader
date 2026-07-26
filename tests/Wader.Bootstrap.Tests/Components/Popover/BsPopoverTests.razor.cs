using NSubstitute;
using Wader.Bootstrap.Components.Popover;
using Wader.Bootstrap.Components.Popover.Internals;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Popover;

public partial class BsPopoverTests() : BsComponentTests<BsPopover>("""<div class="{0}" {1}></div>""")
{
    private readonly IBsPopoverJsInterop _popoverJsInteropMock = Substitute.For<IBsPopoverJsInterop>();
    protected override string ClassesForDefaultTests => "d-inline-block";

    [Fact]
    public async Task OnAfterRender_CallsCreateOrUpdateJsInterop()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();

        // Assert
        await _popoverJsInteropMock
            .Received(1)
            .CreateOrUpdateAsync(cut.Instance.HostElementRef, Arg.Any<BsPopoverJsOptions>());
    }

    [Fact]
    public async Task Toggle_CallsToggleJsInterop()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.Instance.ToggleAsync();

        // Assert
        await _popoverJsInteropMock.Received(1).ToggleAsync(cut.Instance.HostElementRef);
    }

    [Fact]
    public async Task Show_CallsShowJsInterop()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.Instance.ShowAsync();

        // Assert
        await _popoverJsInteropMock.Received(1).ShowAsync(cut.Instance.HostElementRef);
    }

    [Fact]
    public async Task Hide_CallsHideJsInterop()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.Instance.HideAsync();

        // Assert
        await _popoverJsInteropMock.Received(1).HideAsync(cut.Instance.HostElementRef);
    }

    [Fact]
    public async Task UpdatePosition_CallsUpdatePositionJsInterop()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.Instance.UpdatePositionAsync();

        // Assert
        await _popoverJsInteropMock.Received(1).UpdatePositionAsync(cut.Instance.HostElementRef);
    }

    [Fact]
    public async Task Dispose_CallsDisposeElementJsInterop()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.Instance.DisposeAsync();

        // Assert
        await _popoverJsInteropMock.Received(1).DisposeReferenceAsync(cut.Instance.HostElementRef);
    }

    protected override void ConfigureTestContext()
    {
        _ = Services.AddSingleton(_popoverJsInteropMock);
    }
}
