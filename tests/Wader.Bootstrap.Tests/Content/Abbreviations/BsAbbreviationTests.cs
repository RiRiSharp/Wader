using Wader.Bootstrap.Content.Abbreviations;

namespace Wader.Bootstrap.Tests.Content.Abbreviations;

public class BsAbbreviationTests() : BsComponentTests<BsAbbreviation>("""<abbr class=" {0}" {1}></abbr>""")
{
    [Fact]
    public void NullFullNameDoesNotAddAttribute()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.FullName, null));

        // Assert
        cut.MarkupMatches(GetExpectedHtml("", ""));
    }

    [Theory]
    [InlineData("")]
    [InlineData("SimpleTitle")]
    [InlineData("C0mplex TîtLè ~💪💪")]
    [InlineData("<tag>XML-tag</tag>")]
    public void FullNameAddsCorrectTitleAttribute(string fullName)
    {
        // Arrange
        ConfigureTestContext();
        var attributeDict = AttributesForDefaultTests;
        attributeDict["title"] = fullName;

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.FullName, fullName));

        // Assert
        cut.MarkupMatches(GetExpectedHtml("", attributeDict));
    }

    [Fact]
    public void TitleCannotBeOverriden()
    {
        TestForDisallowingOverride("title");
    }
}
