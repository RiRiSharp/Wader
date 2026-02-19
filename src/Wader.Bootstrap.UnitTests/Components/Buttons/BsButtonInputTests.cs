using Wader.Bootstrap.Components.Buttons;

namespace Wader.Bootstrap.UnitTests.Components.Buttons;

public class BsButtonInputTests() : BsComponentTests<BsButtonInput>("""<input class="btn {0}" {1}></input>""")
{
    protected override string ClassesForDefaultTests => "btn-primary";
    protected override Dictionary<string, string> AttributesForDefaultTests => new() { ["type"] = "button" };

    [Theory]
    [InlineData(BsButtonVariant.Primary, "btn-primary")]
    [InlineData(BsButtonVariant.Secondary, "btn-secondary")]
    [InlineData(BsButtonVariant.Success, "btn-success")]
    [InlineData(BsButtonVariant.Danger, "btn-danger")]
    [InlineData(BsButtonVariant.Warning, "btn-warning")]
    [InlineData(BsButtonVariant.Info, "btn-info")]
    [InlineData(BsButtonVariant.Light, "btn-light")]
    [InlineData(BsButtonVariant.Dark, "btn-dark")]
    [InlineData(BsButtonVariant.Link, "btn-link")]
    public void VariantAddsCorrectClass(BsButtonVariant variant, string? expectedClass)
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
