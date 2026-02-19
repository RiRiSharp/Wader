using NSubstitute;
using Wader.Bootstrap.Components.Collapse;
using Wader.Bootstrap.Components.Collapse.Internals;

namespace Wader.Bootstrap.UnitTests.Components.Collapse;

public class BsCollapseTests() : BsComponentTests<BsCollapse>("""<div class="{0}" {1}></div>""")
{
    protected override string ClassesForDefaultTests => "collapse";
    private readonly IBsCollapseJsFunctions _collapseJsFunctionsMock = Substitute.For<IBsCollapseJsFunctions>();

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
    public async Task ToggleCallsJsCorrectlyAsync()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.InvokeAsync(cut.Instance.ToggleAsync);

        // Assert
        await _collapseJsFunctionsMock.Received(1).ToggleAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public async Task CollapseCallJsCorrectlyAsync()
    {
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.InvokeAsync(cut.Instance.CollapseAsync);

        // Assert
        await _collapseJsFunctionsMock.Received(1).CollapseAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public async Task ShowCallJsCorrectlyAsync()
    {
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.InvokeAsync(cut.Instance.ShowAsync);

        // Assert
        await _collapseJsFunctionsMock.Received(1).ShowAsync(cut.Instance.HtmlRef);
    }

    protected override void ConfigureTestContext()
    {
        _ = Services.AddSingleton(_collapseJsFunctionsMock);
    }
}
