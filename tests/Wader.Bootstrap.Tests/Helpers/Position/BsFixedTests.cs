using Wader.Bootstrap.Helpers.Position;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Helpers.Position;

public class BsFixedTests() : BsComponentTests<BsFixed>("""<div class="{0}" {1}></div>""")
{
    protected override string ClassesForDefaultTests => "fixed-top";

    [Theory]
    [InlineData(BsGluePosition.Top, "fixed-top")]
    [InlineData(BsGluePosition.Bottom, "fixed-bottom")]
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
