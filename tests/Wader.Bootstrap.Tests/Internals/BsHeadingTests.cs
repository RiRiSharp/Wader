using Wader.Bootstrap.Infrastructure;

namespace Wader.Bootstrap.Tests.Internals;

public class BsHeadingTests() : BsComponentTests<BsHeading>("""<h1 class="{0}" {1}></h1>""")
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    public void SupplyingHeaderNumberDrawsCorrectHtmlTag(int value)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.Value, value));

        // Assert
        cut.MarkupMatches($"<h{value} diff:ignoreAttributes></h{value}>");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(7)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    public void SupplyingUnsupportedHeadingNumberThrowsOutOfRange(int value)
    {
        // Arrange
        ConfigureTestContext();

        // Act + Assert
        _ = Assert.Throws<ArgumentOutOfRangeException>(() => GetCut(parameters => parameters.Add(x => x.Value, value)));
    }
}
