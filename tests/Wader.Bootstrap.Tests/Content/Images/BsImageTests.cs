using Wader.Bootstrap.Content.Images;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Content.Images;

public class BsImageTests() : BsComponentTests<BsImage>("""<img class=" {0}" {1}/>""")
{
    [Fact]
    public void NullSrcDoesNotAddAttribute()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Src, value: null));

        // Assert
        cut.MarkupMatches(GetExpectedHtml(classes: "", attributes: ""));
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
        cut.MarkupMatches(GetExpectedHtml(classes: "", attributeDict));
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
        cut.MarkupMatches(GetExpectedHtml(classes: "", attributeDict));
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
        var cut = GetCut(parameters => parameters.AddUnmatched(name: "src", unmatchedSrc).Add(p => p.Src, src));

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
        var cut = GetCut(parameters => parameters.AddUnmatched(name: "alt", unmatchedAlt).Add(p => p.Alt, alt));

        // Assert
        cut.MarkupMatches(GetExpectedHtml(ClassesForDefaultTests, attributeDict));
    }
}
