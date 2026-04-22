using Wader.Bootstrap.Components.Progress;
using Wader.Bootstrap.Internals.Constants;

namespace Wader.Bootstrap.Tests.Components.Progress;

public class BsProgressTests() : BsComponentTests<BsProgress>("""<div class="progress {0}" {1}></div>""")
{
    // TODO: Test for missing parameters, moreover, when width is set, max and min shouldn't be also set.
    protected override Dictionary<string, string> AttributesForDefaultTests => new() { ["role"] = "progressbar" };

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

    [Theory]
    [InlineData(25.0, "25")]
    [InlineData(75.0, "75")]
    public void ValueNowRendersCorrectAriaAttribute(double valueNow, string expected)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.ValueNow, valueNow));

        // Assert
        cut.MarkupMatches(
            $"""<div class="progress" role="progressbar" aria-valuenow="{expected}" aria-valuemin="0" aria-valuemax="100"></div>"""
        );
    }

    [Theory]
    [InlineData(10.0, "10")]
    [InlineData(20.0, "20")]
    public void ValueMinRendersCorrectAriaAttribute(double valueMin, string expected)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.ValueMin, valueMin));

        // Assert
        cut.MarkupMatches(
            $"""<div class="progress" role="progressbar" aria-valuenow="0" aria-valuemin="{expected}" aria-valuemax="100"></div>"""
        );
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
        var cut = GetCut(parameters => parameters.Add(x => x.Width, 50.0));

        // Assert
        cut.MarkupMatches(
            """<div class="progress" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>"""
        );
    }

    [Theory]
    [InlineData(0.0, "width: 0%")]
    [InlineData(50.0, "width: 50%")]
    [InlineData(100.0, "width: 100%")]
    public void WidthRendersStyleWhenStacked(double width, string expectedStyle)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters =>
        {
            _ = parameters.AddCascadingValue(CascadingValueNames.PROGRESS_IS_STACKED, true);
            _ = parameters.Add(x => x.Width, width);
        });

        // Assert
        cut.MarkupMatches(
            $"""<div class="progress" style="{expectedStyle}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>"""
        );
    }

    protected override void BindParameters(ComponentParameterCollectionBuilder<BsProgress> parameterBuilder)
    {
        base.BindParameters(parameterBuilder);
        _ = parameterBuilder.Add(b => b.Width, 0);
    }
}
