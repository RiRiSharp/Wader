using NSubstitute;
using Wader.Bootstrap.Components.Tooltip;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Tooltip;

public partial class BsTooltipTests() : BsComponentTests<BsTooltip>("""<span class="{0}" {1}></span>""")
{
    private readonly IBsTooltipJsInterop _tooltipJsInteropMock = Substitute.For<IBsTooltipJsInterop>();

    [Fact]
    public async Task OnAfterRender_CallsCreateOrUpdateJsInterop()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();

        // Assert
        await _tooltipJsInteropMock
            .Received(1)
            .CreateOrUpdateAsync(cut.Instance.HostElementRef, Arg.Any<BsTooltipJsOptions>());
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
        await _tooltipJsInteropMock.Received(1).ToggleAsync(cut.Instance.HostElementRef);
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
        await _tooltipJsInteropMock.Received(1).ShowAsync(cut.Instance.HostElementRef);
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
        await _tooltipJsInteropMock.Received(1).HideAsync(cut.Instance.HostElementRef);
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
        await _tooltipJsInteropMock.Received(1).UpdatePositionAsync(cut.Instance.HostElementRef);
    }

    [Fact]
    public async Task ToggleEnabled_CallsToggleEnabledJsInterop()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.Instance.ToggleEnabledAsync();

        // Assert
        await _tooltipJsInteropMock.Received(1).ToggleEnabledAsync(cut.Instance.HostElementRef);
    }

    [Fact]
    public async Task Enable_CallsUpdatePositionJsInterop()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.Instance.EnableAsync();

        // Assert
        await _tooltipJsInteropMock.Received(1).EnableAsync(cut.Instance.HostElementRef);
    }

    [Fact]
    public async Task Disable_CallsUpdatePositionJsInterop()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.Instance.DisableAsync();

        // Assert
        await _tooltipJsInteropMock.Received(1).DisableAsync(cut.Instance.HostElementRef);
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
        await _tooltipJsInteropMock.Received(1).DisposeReferenceAsync(cut.Instance.HostElementRef);
    }

    protected override void ConfigureTestContext()
    {
        _ = Services.AddSingleton(_tooltipJsInteropMock);
    }
}
