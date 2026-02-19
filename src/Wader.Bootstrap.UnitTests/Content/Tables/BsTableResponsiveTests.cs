using Wader.Bootstrap.Content.Tables;

namespace Wader.Bootstrap.UnitTests.Content.Tables;

public class BsTableResponsiveTests() : BsComponentTests<BsTableResponsive>("""<div class="{0}" {1}></div>""")
{
    protected override string ClassesForDefaultTests => "table-responsive";

    [Theory]
    [InlineData(BsTableBreakpoint.Default, "table-responsive")]
    [InlineData(BsTableBreakpoint.Sm, "table-responsive-sm")]
    [InlineData(BsTableBreakpoint.Md, "table-responsive-md")]
    [InlineData(BsTableBreakpoint.Lg, "table-responsive-lg")]
    [InlineData(BsTableBreakpoint.Xl, "table-responsive-xl")]
    [InlineData(BsTableBreakpoint.Xxl, "table-responsive-xxl")]
    public void TableOptionsWorks(BsTableBreakpoint options, string? expectedClass)
    {
        // Arrange + Act
        var cut = GetCut(parameters => parameters.Add(p => p.Breakpoint, options));

        // Assert
        cut.MarkupMatches(GetExpectedHtml(expectedClass));
    }
}
