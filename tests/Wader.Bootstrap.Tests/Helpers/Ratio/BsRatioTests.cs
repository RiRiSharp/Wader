using Wader.Bootstrap.Helpers.Ratio;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Helpers.Ratio;

public class BsRatioTests() : BsComponentTests<BsRatio>("""<div class="ratio {0}" {1}></div>""")
{
    [Theory]
    [InlineData(BsRatioVariant.R1X1, "ratio-1x1")]
    [InlineData(BsRatioVariant.R4X3, "ratio-4x3")]
    [InlineData(BsRatioVariant.R16X9, "ratio-16x9")]
    [InlineData(BsRatioVariant.R21X9, "ratio-21x9")]
    public void VariantAddsCorrectClass(BsRatioVariant position, string expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Variant, position));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }
}
