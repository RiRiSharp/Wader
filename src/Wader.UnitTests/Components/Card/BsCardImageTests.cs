using Wader.Components.Card;

namespace Wader.UnitTests.Components.Card;

public class BsCardImageTests() : BsComponentTests<BsCardImage>("""<img class="{0}" {1}/>""")
{
    protected override string ClassesForDefaultTests => "card-img-top";
    protected override Dictionary<string, string> AttributesForDefaultTests => [];

    [Theory]
    [InlineData(BsCardImagePosition.Top, "card-img-top")]
    [InlineData(BsCardImagePosition.Bottom, "card-img-bottom")]
    [InlineData(BsCardImagePosition.Overlay, "card-img")]
    public void PositionAddsCorrectClass(BsCardImagePosition position, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Position, position));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData("")]
    [InlineData("source")]
    [InlineData("https://example.com/an-image.jpg")]
    [InlineData("C0mplex TîtLè ~💪💪")]
    [InlineData("<tag>XML-tag</tag>")]
    public void SrcWorks(string src)
    {
        // Arrange
        ConfigureTestContext();
        var attributeDict = AttributesForDefaultTests;
        attributeDict["src"] = src;

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Src, src));

        // Assert
        cut.MarkupMatches(GetExpectedHtml(ClassesForDefaultTests, attributeDict));
    }

    [Theory]
    [InlineData("")]
    [InlineData("alternative description")]
    [InlineData("https://example.com/an-image.jpg")]
    [InlineData("C0mplex TîtLè ~💪💪")]
    [InlineData("<tag>XML-tag</tag>")]
    public void AltWorks(string alt)
    {
        // Arrange
        ConfigureTestContext();
        var attributeDict = AttributesForDefaultTests;
        attributeDict["alt"] = alt;

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Alt, alt));

        // Assert
        cut.MarkupMatches(GetExpectedHtml(ClassesForDefaultTests, attributeDict));
    }

    [Fact]
    public void SourceCannotBeOverriden()
    {
        // Arrange
        ConfigureTestContext();
        const string unmatchedSrc = "some-unique-value";
        const string src = "some-other-unique-value";
        var attributeDict = AttributesForDefaultTests;
        attributeDict["src"] = src;

        // Act
        var cut = GetCut(parameters => parameters.AddUnmatched("src", unmatchedSrc).Add(p => p.Src, src));

        // Assert
        cut.MarkupMatches(GetExpectedHtml(ClassesForDefaultTests, attributeDict));
    }

    [Fact]
    public void AlternativeCannotBeOverriden()
    {
        // Arrange
        ConfigureTestContext();
        const string unmatchedAlt = "some-unique-value";
        const string alt = "some-other-unique-value";
        var attributeDict = AttributesForDefaultTests;
        attributeDict["alt"] = alt;

        // Act
        var cut = GetCut(parameters => parameters.AddUnmatched("alt", unmatchedAlt).Add(p => p.Alt, alt));

        // Assert
        cut.MarkupMatches(GetExpectedHtml(ClassesForDefaultTests, attributeDict));
    }
}
