using Wader.Bootstrap.Content.Tables;

namespace Wader.Bootstrap.Tests.Content.Tables;

public class BsTableBodyTests() : BsComponentTests<BsTableBody>("""<tbody class=" {0}" {1}></tbody>""")
{
    [Theory]
    [InlineData(false, "")]
    [InlineData(true, "table-group-divider")]
    public void DividerGeneratesCorrectClass(bool hasDivider, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.TableGroupDivider, hasDivider));

        // Assert
        cut.MarkupMatches(GetExpectedHtml(expectedClass, ""));
    }
}
