using Wader.Bootstrap.Components.Pagination;

namespace Wader.Bootstrap.UnitTests.Components.Pagination;

public class BsPaginationTests() : BsComponentTests<BsPagination>("""<ul class="pagination {0}" {1}></ul>""")
{
    [Theory]
    [InlineData(BsPaginationSize.Regular, null)]
    [InlineData(BsPaginationSize.Small, "pagination-sm")]
    [InlineData(BsPaginationSize.Large, "pagination-lg")]
    public void SizeAddsCorrectClass(BsPaginationSize size, string? expectedClass)
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
