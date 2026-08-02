using Wader.Bootstrap.Helpers.FocusRing;
using Wader.Bootstrap.Internal.Primitives;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Helpers.FocusRing;

public class BsFocusRingTests() : BsComponentTests<BsFocusRing>("""<a class="focus-ring {0}" {1}></a>""")
{
    [Theory]
    [InlineData(BsColor.Primary, "focus-ring-primary")]
    [InlineData(BsColor.Secondary, "focus-ring-secondary")]
    [InlineData(BsColor.Success, "focus-ring-success")]
    [InlineData(BsColor.Danger, "focus-ring-danger")]
    [InlineData(BsColor.Warning, "focus-ring-warning")]
    [InlineData(BsColor.Info, "focus-ring-info")]
    [InlineData(BsColor.Light, "focus-ring-light")]
    [InlineData(BsColor.Dark, "focus-ring-dark")]
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
