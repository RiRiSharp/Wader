using Wader.Layout.Containers;
using Wader.Primitives;

namespace Wader.UnitTests.Layout.Containers;

public class BsContainerTests() : BsComponentTests<BsContainer>("""<div class="{0}" {1}></div>""")
{
    protected override string ClassesForDefaultTests => "container";

    [Theory]
    [InlineData(BsBreakpoint.ExtraSmall, "container")]
    [InlineData(BsBreakpoint.Small, "container-sm")]
    [InlineData(BsBreakpoint.Medium, "container-md")]
    [InlineData(BsBreakpoint.Large, "container-lg")]
    [InlineData(BsBreakpoint.ExtraLarge, "container-xl")]
    [InlineData(BsBreakpoint.ExtraExtraLarge, "container-xxl")]
    public void BreakpointAddsCorrectClass(BsBreakpoint breakpoint, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Breakpoint, breakpoint));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }
}
