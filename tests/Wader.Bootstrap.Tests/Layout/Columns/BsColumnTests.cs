using Wader.Bootstrap.Layout.Columns;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Layout.Columns;

public class BsColumnTests() : BsComponentTests<BsColumn>("""<div class="{0}" {1}></div>""")
{
    protected override string ClassesForDefaultTests => "col";

    [Fact]
    public void ColumnRenderingWorksInSingularForm()
    {
        // Arrange + Act
        var cut = GetCut(parameters => parameters.Add(p => p.ColOption, BsColumnOptions.Col1));

        // Assert
        cut.MarkupMatches(GetExpectedHtml("col-1"));
    }

    [Fact]
    public void ColumnRenderingWorksInListForm()
    {
        // Arrange + Act
        var cut = GetCut(parameters =>
            parameters.Add(p => p.ColOptions, [BsColumnOptions.ColSm4, BsColumnOptions.ColMd6])
        );

        // Assert
        cut.MarkupMatches(GetExpectedHtml("col-sm-4 col-md-6"));
    }

    [Fact]
    public void ListColumnOptionTakesPrecedenceOverSingularForm()
    {
        var cut = GetCut(parameters =>
            parameters
                .Add(p => p.ColOption, BsColumnOptions.Col1)
                .Add(p => p.ColOptions, [BsColumnOptions.ColSm4, BsColumnOptions.ColMd6])
        );

        cut.MarkupMatches(GetExpectedHtml("col-sm-4 col-md-6"));
    }

    [Fact]
    public void ColumnOffsetRenderingWorksInSingularForm()
    {
        var cut = GetCut(parameters => parameters.Add(p => p.OffsetOption, BsColumnOptions.Col1));

        cut.MarkupMatches(GetExpectedHtml($"{ClassesForDefaultTests} offset-1"));
    }

    [Fact]
    public void ColumnOffsetRenderingWorksInListForm()
    {
        var cut = GetCut(parameters =>
            parameters.Add(p => p.OffsetOptionsList, [BsColumnOptions.ColSm4, BsColumnOptions.ColMd6])
        );

        cut.MarkupMatches(GetExpectedHtml($"{ClassesForDefaultTests} offset-sm-4 offset-md-6"));
    }

    [Fact]
    public void ListColumnOffsetOptionTakesPrecedenceOverSingularForm()
    {
        var cut = GetCut(parameters =>
            parameters
                .Add(p => p.OffsetOption, BsColumnOptions.Col1)
                .Add(p => p.OffsetOptionsList, [BsColumnOptions.ColSm4, BsColumnOptions.ColMd6])
        );

        cut.MarkupMatches(GetExpectedHtml($"{ClassesForDefaultTests} offset-sm-4 offset-md-6"));
    }
}
