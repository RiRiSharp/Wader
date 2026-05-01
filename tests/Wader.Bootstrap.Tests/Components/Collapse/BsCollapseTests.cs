using NSubstitute;
using Wader.Bootstrap.Components.Collapse;
using Wader.Bootstrap.Components.Collapse.Internals;

namespace Wader.Bootstrap.Tests.Components.Collapse;

public class BsCollapseTests() : BsComponentTests<BsCollapse>("""<div class="{0}" {1}></div>""")
{
    private readonly IBsCollapseJsInterop _collapseJsInteropMock = Substitute.For<IBsCollapseJsInterop>();
    protected override string ClassesForDefaultTests => "collapse";

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ShowAddsCorrectClass(bool show)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Show, show));

        // Assert
        var showClass = show ? "show" : "";
        var expectedMarkupString = GetExpectedHtml($"{ClassesForDefaultTests} {showClass}", AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Fact]
    public async Task Toggle_CallsToggleJsInterop()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.InvokeAsync(cut.Instance.ToggleAsync);

        // Assert
        await _collapseJsInteropMock.Received(1).ToggleAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public async Task CollapseCallJsCorrectlyAsync()
    {
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.InvokeAsync(cut.Instance.CollapseAsync);

        // Assert
        await _collapseJsInteropMock.Received(1).CollapseAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public async Task ShowCallJsCorrectlyAsync()
    {
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.InvokeAsync(cut.Instance.ShowAsync);

        // Assert
        await _collapseJsInteropMock.Received(1).ShowAsync(cut.Instance.HtmlRef);
    }

    protected override void ConfigureTestContext()
    {
        _ = Services.AddSingleton(_collapseJsInteropMock);
    }
}
