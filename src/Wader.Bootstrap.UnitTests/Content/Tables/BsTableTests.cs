using Wader.Bootstrap.Content.Tables;

namespace Wader.Bootstrap.UnitTests.Content.Tables;

public class BsTableTests() : BsComponentTests<BsTable>("""<table class="table {0}" {1}></table>""")
{
    [Theory]
    [InlineData(BsTableOptions.TableBordered | BsTableOptions.BorderDanger, "table-bordered border-danger")]
    [InlineData(BsTableOptions.CaptionTop, "caption-top")]
    [InlineData(BsTableOptions.TableBorderless, "table-borderless")]
    public void TableOptionsWorks(BsTableOptions options, string? expectedClass)
    {
        // Arrange + Act
        var cut = GetCut(parameters => parameters.Add(p => p.Options, options));

        // Assert
        cut.MarkupMatches(GetExpectedHtml(expectedClass));
    }
}
