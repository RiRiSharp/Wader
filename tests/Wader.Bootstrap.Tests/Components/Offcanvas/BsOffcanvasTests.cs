using NSubstitute;
using Wader.Bootstrap.Components.Offcanvas;
using Wader.Bootstrap.Components.Offcanvas.Internals;
using Wader.Bootstrap.Infrastructure.Primitives;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Offcanvas;

public class BsOffcanvasTests() : BsComponentTests<BsOffcanvas>("""<div class="offcanvas {0}" {1}></nav>""")
{
    private readonly IBsOffcanvasJsInterop _offcanvasJsInteropMock = Substitute.For<IBsOffcanvasJsInterop>();
    protected override string ClassesForDefaultTests => "offcanvas-start";

    protected override Dictionary<string, string> AttributesForDefaultTests =>
        new() { ["tabindex"] = "-1", ["data-bs-scroll"] = "false" };

    [Theory]
    [InlineData(BsDirection.Down, "offcanvas-bottom")]
    [InlineData(BsDirection.Up, "offcanvas-top")]
    [InlineData(BsDirection.Start, "offcanvas-start")]
    [InlineData(BsDirection.End, "offcanvas-end")]
    public void DirectionAddsCorrectClass(BsDirection direction, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Direction, direction));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
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
        await _offcanvasJsInteropMock.Received(1).ToggleAsync(cut.Instance.HtmlRef);
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
        await _offcanvasJsInteropMock.Received(1).ShowAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public async Task Close_CallsCloseJsInterop()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.Instance.CloseAsync();

        // Assert
        await _offcanvasJsInteropMock.Received(1).CloseAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public void TabIndexCanBeOverriden()
    {
        TestForAllowingOverride("tabindex");
    }

    protected override void ConfigureTestContext()
    {
        _ = Services.AddSingleton(_offcanvasJsInteropMock);
    }
}
