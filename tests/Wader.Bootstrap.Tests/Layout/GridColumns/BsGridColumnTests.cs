using Wader.Bootstrap.Layout.GridColumns;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Layout.GridColumns;

public class BsGridColumnTests() : BsComponentTests<BsGridColumn>("""<div class=" {0}" {1}></div>""")
{
    [Fact]
    public void ColumnRenderingWorksInSingularForm()
    {
        // Arrange + Act
        var cut = GetCut(parameters => parameters.Add(p => p.GridOption, BsGridColumnOptions.GCol1));

        // Assert
        cut.MarkupMatches(GetExpectedHtml(classes: "g-col-1"));
    }

    [Fact]
    public void ColumnRenderingWorksInListForm()
    {
        // Arrange + Act
        var cut = GetCut(parameters =>
            parameters.Add(p => p.GridOptions, [BsGridColumnOptions.GColSm4, BsGridColumnOptions.GColMd6])
        );

        // Assert
        cut.MarkupMatches(GetExpectedHtml(classes: "g-col-sm-4 g-col-md-6"));
    }

    [Fact]
    public void ListColumnOptionTakesPrecedenceOverSingularForm()
    {
        // Arrange + Act
        var cut = GetCut(parameters =>
            parameters
                .Add(p => p.GridOption, BsGridColumnOptions.GCol1)
                .Add(p => p.GridOptions, [BsGridColumnOptions.GColSm4, BsGridColumnOptions.GColMd6])
        );

        // Assert
        cut.MarkupMatches(GetExpectedHtml(classes: "g-col-sm-4 g-col-md-6"));
    }
}
