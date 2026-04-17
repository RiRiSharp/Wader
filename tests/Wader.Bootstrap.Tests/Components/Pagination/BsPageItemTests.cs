using Wader.Bootstrap.Components.Pagination;

namespace Wader.Bootstrap.Tests.Components.Pagination;

public class BsPageItemTests() : BsComponentTests<BsPageItem>("""<li class="page-item {0}" {1}></ul>""")
{
    [Theory]
    [InlineData(false, null)]
    [InlineData(true, "active")]
    public void ActiveAddsCorrectClass(bool active, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.Active, active));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData(false, null)]
    [InlineData(true, "disabled")]
    public void DisabledAddsCorrectClass(bool disabled, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.Disabled, disabled));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }
}
