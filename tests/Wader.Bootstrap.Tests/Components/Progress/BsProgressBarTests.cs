using Wader.Bootstrap.Components.Progress;
using Wader.Bootstrap.Internal.Constants;
using Wader.Bootstrap.Internal.Primitives;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Progress;

public class BsProgressBarTests() : BsComponentTests<BsProgressBar>("""<div class="progress-bar {0}" {1}></div>""")
{
    protected override string ClassesForDefaultTests => "bg-primary";
    protected override Dictionary<string, string> AttributesForDefaultTests => new() { ["style"] = "width: 0%" };

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
        cut.MarkupMatches($"""<div class="progress-bar {ClassesForDefaultTests}" style="{expectedStyle}"></div>""");
    }

    [Theory]
    [InlineData("color: purple", "color: purple; width: 0%")]
    [InlineData("width: 50%", "width: 0%")]
    public void ExtraStylingCanBeAdded(string addedStyle, string expectedStyle)
    {
        // Arrange
        ConfigureTestContext();
        var attributes = AttributesForDefaultTests;
        const string attributeKey = "style";
        attributes["style"] = expectedStyle;

        // Act
        var cut = GetCut(parameters => _ = parameters.AddUnmatched(attributeKey, addedStyle));

        // Assert
        cut.MarkupMatches(GetExpectedHtml(ClassesForDefaultTests, attributes));
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
                .AddCascadingValue(CascadingValueNames.PROGRESS_IS_STACKED, cascadingValue: true)
                .AddCascadingValue(CascadingValueNames.PROGRESS_WIDTH, width)
        );

        // Assert
        cut.MarkupMatches($"""<div class="progress-bar {ClassesForDefaultTests}"></div>""");
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
        var expectedMarkupString = GetExpectedHtml(
            $"{ClassesForDefaultTests} {expectedClass}",
            AttributesForDefaultTests
        );
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
        var expectedMarkupString = GetExpectedHtml(
            $"{ClassesForDefaultTests} {expectedClass}",
            AttributesForDefaultTests
        );
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData(BsColor.Primary, "bg-primary")]
    [InlineData(BsColor.Success, "bg-success")]
    [InlineData(BsColor.Info, "bg-info")]
    [InlineData(BsColor.Warning, "bg-warning")]
    [InlineData(BsColor.Danger, "bg-danger")]
    public void VariantRendersCorrectClass(BsColor variant, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.Variant, variant));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    protected override void BindParameters(ComponentParameterCollectionBuilder<BsProgressBar> parameterBuilder)
    {
        base.BindParameters(parameterBuilder);
        _ = parameterBuilder.AddCascadingValue(CascadingValueNames.PROGRESS_WIDTH, cascadingValue: 0d);
    }
}
