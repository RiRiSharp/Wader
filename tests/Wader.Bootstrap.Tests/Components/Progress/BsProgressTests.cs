using Wader.Bootstrap.Components.Progress;
using Wader.Bootstrap.Internal.Constants;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Progress;

public class BsProgressTests() : BsComponentTests<BsProgress>("""<div class="progress {0}" {1}></div>""")
{
    // TODO: Test for missing parameters, moreover, when width is set, max and min shouldn't be also set.
    protected override Dictionary<string, string> AttributesForDefaultTests => new() { ["role"] = "progressbar" };

    [Theory]
    [InlineData(25.0, "25")]
    [InlineData(75.0, "75")]
    public void ValueNowRendersCorrectAriaAttribute(double valueNow, string expected)
    {
        ConfigureTestContext();
        var attributes = AttributesForDefaultTests;
        attributes["aria-valuenow"] = expected;

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.ValueNow, valueNow));

        // Assert
        var expectedMarkupString = GetExpectedHtml(ClassesForDefaultTests, attributes);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData(10.0, "10")]
    [InlineData(20.0, "20")]
    public void ValueMinRendersCorrectAriaAttribute(double valueMin, string expected)
    {
        // Arrange
        ConfigureTestContext();
        var attributes = AttributesForDefaultTests;
        attributes["aria-valuemin"] = expected;

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.ValueMin, valueMin));

        // Assert
        var expectedMarkupString = GetExpectedHtml(ClassesForDefaultTests, attributes);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData(50.0, "50")]
    [InlineData(200.0, "200")]
    public void ValueMaxRendersCorrectAriaAttribute(double valueMax, string expected)
    {
        // Arrange
        ConfigureTestContext();
        var attributes = AttributesForDefaultTests;
        attributes["aria-valuemax"] = expected;

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.ValueMax, valueMax));

        // Assert
        var expectedMarkupString = GetExpectedHtml(ClassesForDefaultTests, attributes);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Fact]
    public void WidthDoesNotRenderStyleWhenNotStacked()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = Render<BsProgress>(parameters => parameters.Add(x => x.Width, value: 50.0));

        // Assert
        var expectedMarkupString = GetExpectedHtml(ClassesForDefaultTests, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData(0.0, "width: 0%")]
    [InlineData(50.0, "width: 50%")]
    [InlineData(100.0, "width: 100%")]
    public void WidthRendersStyleWhenStacked(double width, string expectedStyle)
    {
        // Arrange
        ConfigureTestContext();
        var attributes = AttributesForDefaultTests;
        attributes["style"] = expectedStyle;

        // Act
        var cut = Render<BsProgress>(parameters =>
            _ = parameters
                .Add(x => x.Width, width)
                .AddCascadingValue(CascadingValueNames.PROGRESS_IS_STACKED, cascadingValue: true)
        );

        // Assert
        var expectedMarkupString = GetExpectedHtml(ClassesForDefaultTests, attributes);
        cut.MarkupMatches(expectedMarkupString);
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
        var cut = GetCut(parameters =>
        {
            _ = parameters
                .AddUnmatched(attributeKey, addedStyle)
                .AddCascadingValue(CascadingValueNames.PROGRESS_IS_STACKED, cascadingValue: true);
        });

        // Assert
        var expectedMarkupString = GetExpectedHtml(ClassesForDefaultTests, attributes);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Fact]
    public void RoleCanBeOverridden()
    {
        TestForAllowingOverride("role");
    }

    [Fact]
    public void AriaValueNowCanBeOverridden()
    {
        TestForAllowingOverride("aria-valuenow");
    }

    [Fact]
    public void AriaValueMinCanBeOverridden()
    {
        TestForAllowingOverride("aria-valuemin");
    }

    [Fact]
    public void AriaValueMaxCanBeOverridden()
    {
        TestForAllowingOverride("aria-valuemax");
    }

    [Fact]
    public void WidthIsCascading()
    {
        TestForCascadingValue<double>(CascadingValueNames.PROGRESS_WIDTH);
    }

    protected override void BindParameters(ComponentParameterCollectionBuilder<BsProgress> parameterBuilder)
    {
        base.BindParameters(parameterBuilder);
        _ = parameterBuilder.Add(b => b.Width, value: 0);
    }
}
