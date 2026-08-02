using Wader.Bootstrap.Helpers.ColorBackground;
using Wader.Bootstrap.Internal.Primitives;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Helpers.ColorBackground;

public class BsTextBackgroundTests() : BsComponentTests<BsTextBackground>("""<div class="{0}" {1}></div>""")
{
    protected override string ClassesForDefaultTests => "text-bg-primary";

    [Theory]
    [InlineData(BsColor.Primary, "text-bg-primary")]
    [InlineData(BsColor.Secondary, "text-bg-secondary")]
    [InlineData(BsColor.Success, "text-bg-success")]
    [InlineData(BsColor.Danger, "text-bg-danger")]
    [InlineData(BsColor.Warning, "text-bg-warning")]
    [InlineData(BsColor.Info, "text-bg-info")]
    [InlineData(BsColor.Light, "text-bg-light")]
    [InlineData(BsColor.Dark, "text-bg-dark")]
    public void VariantRendersCorrectClass(BsColor variant, string expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Variant, variant));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }
}
