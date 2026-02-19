using Wader.Bootstrap.Components.Buttons;

namespace Wader.Bootstrap.UnitTests.Components.Buttons;

public class BsButtonOutlineInputTests()
    : BsComponentTests<BsButtonOutlineInput>("""<input class="btn {0}" {1}></input>""")
{
    protected override string ClassesForDefaultTests => "btn-outline-primary";
    protected override Dictionary<string, string> AttributesForDefaultTests => new() { ["type"] = "button" };

    [Theory]
    [InlineData(BsButtonOutlineVariant.Primary, "btn-outline-primary")]
    [InlineData(BsButtonOutlineVariant.Secondary, "btn-outline-secondary")]
    [InlineData(BsButtonOutlineVariant.Success, "btn-outline-success")]
    [InlineData(BsButtonOutlineVariant.Danger, "btn-outline-danger")]
    [InlineData(BsButtonOutlineVariant.Warning, "btn-outline-warning")]
    [InlineData(BsButtonOutlineVariant.Info, "btn-outline-info")]
    [InlineData(BsButtonOutlineVariant.Light, "btn-outline-light")]
    [InlineData(BsButtonOutlineVariant.Dark, "btn-outline-dark")]
    public void VariantAddsCorrectClass(BsButtonOutlineVariant variant, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Variant, variant));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData(BsButtonSize.Regular, "")]
    [InlineData(BsButtonSize.Small, "btn-sm")]
    [InlineData(BsButtonSize.Large, "btn-lg")]
    public void SizeAddsCorrectClass(BsButtonSize size, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Size, size));

        // Assert
        var expectedMarkupString = GetExpectedHtml(
            $"{ClassesForDefaultTests} {expectedClass}",
            AttributesForDefaultTests
        );
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData("")]
    [InlineData("alternative description")]
    [InlineData("https://example.com/an-image.jpg")]
    [InlineData("C0mplex TîtLè ~💪💪")]
    [InlineData("<tag>XML-tag</tag>")]
    public void ContentWorks(string content)
    {
        // Arrange
        ConfigureTestContext();
        var attributeDict = AttributesForDefaultTests;
        attributeDict["value"] = content;

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Content, content));

        // Assert
        cut.MarkupMatches(GetExpectedHtml(ClassesForDefaultTests, attributeDict));
    }

    [Fact]
    public void ButtonTypeCanBeOverriden()
    {
        TestForAllowingOverride("type");
    }
}
