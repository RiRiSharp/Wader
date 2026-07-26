using Wader.Bootstrap.Components.Pagination;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Pagination;

public class BsPageLinkTests() : BsComponentTests<BsPageLink>("""<a class="page-link {0}" {1}></a>""")
{
    [Theory]
    [InlineData(BsPageLinkType.Link, "a")]
    [InlineData(BsPageLinkType.Span, "span")]
    public void LinkTypeCreatesCorrectTag(BsPageLinkType type, string expectedTag)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.LinkType, type));

        // Assert
        cut.MarkupMatches($"<{expectedTag} diff:ignoreAttributes></{expectedTag}>");
    }
}
