using NSubstitute;
using Wader.Bootstrap.Components.Collapse.Internals;
using Wader.Bootstrap.Components.NavBar;

namespace Wader.Bootstrap.Tests.Components.Navbar;

public class BsNavbarCollapseTests()
    : BsComponentTests<BsNavbarCollapse>("""<div class="collapse navbar-collapse {0}" {1}></div>""")
{
    private readonly IBsCollapseJsInterop _collapseJsInteropMock = Substitute.For<IBsCollapseJsInterop>();

    [Fact]
    public async Task ToggleCallsJsCorrectlyAsync()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.Instance.ToggleAsync();

        // Assert
        await _collapseJsInteropMock.Received(1).ToggleAsync(cut.Instance.HtmlRef);
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
        await _collapseJsInteropMock.Received(1).ShowAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public async Task CollapseCallsJsCorrectlyAsync()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.Instance.CollapseAsync();

        // Assert
        await _collapseJsInteropMock.Received(1).CollapseAsync(cut.Instance.HtmlRef);
    }

    protected override void ConfigureTestContext()
    {
        _ = Services.AddSingleton(_collapseJsInteropMock);
    }
}
