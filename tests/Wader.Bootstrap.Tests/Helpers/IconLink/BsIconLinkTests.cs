using Wader.Bootstrap.Helpers.IconLink;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Helpers.IconLink;

public class BsIconLinkTests() : BsComponentTests<BsIconLink>("""<a class="icon-link {0}" {1}></a>""")
{
    [Theory]
    [InlineData(false, "")]
    [InlineData(true, "icon-link-hover")]
    public void HoverAnimateAddsCorrectClass(bool animate, string expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.HoverAnimate, animate));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }
}
