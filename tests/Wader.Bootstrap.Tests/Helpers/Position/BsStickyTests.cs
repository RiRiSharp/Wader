using Wader.Bootstrap.Helpers.Position;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Helpers.Position;

public class BsStickyTests() : BsComponentTests<BsSticky>("""<div class="{0}" {1}></div>""")
{
    protected override string ClassesForDefaultTests => "sticky-top";

    [Theory]
    [InlineData(BsGluePosition.Top, "sticky-top")]
    [InlineData(BsGluePosition.Bottom, "sticky-bottom")]
    public void PositionAddsCorrectClass(BsGluePosition position, string expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Position, position));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }
}
