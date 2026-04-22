using Wader.Bootstrap.Components.Progress;
using Wader.Bootstrap.Internals.Constants;
using Wader.Bootstrap.Primitives;

namespace Wader.Bootstrap.Tests.Components.Progress;

public class BsProgressBarTests() : BsComponentTests<BsProgressBar>("""<div class="progress-bar {0}" {1}></div>""")
{
    protected override Dictionary<string, string> AttributesForDefaultTests => new() { ["style"] = "width: 0%" };

    [Fact]
    public void StyleCanBeOverridden()
    {
        TestForAllowingOverride("style");
    }

    [Theory]
    [InlineData(0.0, "width: 0%")]
    [InlineData(50.0, "width: 50%")]
    [InlineData(100.0, "width: 100%")]
    public void WidthRendersStyleWhenNotStacked(double width, string expectedStyle)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = Render<BsProgressBar>(parameters =>
            parameters.AddCascadingValue(CascadingValueNames.PROGRESS_WIDTH, width)
        );

        // Assert
        cut.MarkupMatches($"""<div class="progress-bar" style="{expectedStyle}"></div>""");
    }

    [Fact]
    public void WidthDoesNotRenderStyleWhenStacked()
    {
        // Arrange
        ConfigureTestContext();
        const int width = 50;

        // Act
        var cut = GetCut(parameters =>
            _ = parameters
                .AddCascadingValue(CascadingValueNames.PROGRESS_IS_STACKED, true)
                .AddCascadingValue(CascadingValueNames.PROGRESS_WIDTH, width)
        );

        // Assert
        cut.MarkupMatches("""<div class="progress-bar"></div>""");
    }

    [Theory]
    [InlineData(false, null)]
    [InlineData(true, "progress-bar-striped")]
    public void StripedAddsCorrectClass(bool striped, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.Striped, striped));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData(false, null)]
    [InlineData(true, "progress-bar-animated")]
    public void AnimatedAddsCorrectClass(bool animated, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.Animated, animated));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData(BsTextBackground.Default, null)]
    [InlineData(BsTextBackground.Success, "bg-success")]
    [InlineData(BsTextBackground.Info, "bg-info")]
    [InlineData(BsTextBackground.Warning, "bg-warning")]
    [InlineData(BsTextBackground.Danger, "bg-danger")]
    public void BackgroundRendersCorrectClass(BsTextBackground background, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.Background, background));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    protected override void BindParameters(ComponentParameterCollectionBuilder<BsProgressBar> parameterBuilder)
    {
        base.BindParameters(parameterBuilder);
        _ = parameterBuilder.AddCascadingValue(CascadingValueNames.PROGRESS_WIDTH, 0d);
    }
}
