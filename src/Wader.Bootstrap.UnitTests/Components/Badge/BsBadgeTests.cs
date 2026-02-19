using Wader.Bootstrap.Components.Badge;

namespace Wader.Bootstrap.UnitTests.Components.Badge;

public class BsBadgeTests() : BsComponentTests<BsBadge>("""<span class="badge {0}" {1}></span>""")
{
    protected override string ClassesForDefaultTests => "text-bg-secondary";

    [Theory]
    [InlineData(BsBadgeColor.Primary, "text-bg-primary")]
    [InlineData(BsBadgeColor.Secondary, "text-bg-secondary")]
    [InlineData(BsBadgeColor.Success, "text-bg-success")]
    [InlineData(BsBadgeColor.Danger, "text-bg-danger")]
    [InlineData(BsBadgeColor.Warning, "text-bg-warning")]
    [InlineData(BsBadgeColor.Info, "text-bg-info")]
    [InlineData(BsBadgeColor.Light, "text-bg-light")]
    [InlineData(BsBadgeColor.Dark, "text-bg-dark")]
    public void BackgroundRendersCorrectClass(BsBadgeColor color, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Background, color));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }
}
