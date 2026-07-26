using Wader.Bootstrap.Components.Placeholders;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Placeholders;

public class BsPlaceholderTests() : BsComponentTests<BsPlaceholder>("""<span class="placeholder {0}" {1}></span>""")
{
    [Theory]
    [InlineData(BsPlaceholderSize.ExtraSmall, "placeholder-xs")]
    [InlineData(BsPlaceholderSize.Small, "placeholder-sm")]
    [InlineData(BsPlaceholderSize.Regular, null)]
    [InlineData(BsPlaceholderSize.Large, "placeholder-lg")]
    public void SizeAddsCorrectClass(BsPlaceholderSize size, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.Size, size));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }
}
