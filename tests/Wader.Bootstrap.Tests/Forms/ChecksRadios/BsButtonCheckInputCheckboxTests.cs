using Wader.Bootstrap.Forms.ChecksRadios;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Forms.ChecksRadios;

public class BsButtonCheckInputCheckboxTests()
    : BsInputBaseComponentTests<BsButtonCheckInputCheckbox, bool>("""<input class="btn-check {0}" {1}/>""")
{
    protected override Dictionary<string, string> AttributesForDefaultTests => new() { ["type"] = "checkbox" };

    [Fact]
    public void TrueChecksTheCheckbox()
    {
        // Arrange
        var value = true;
        var attributeDict = AttributesForDefaultTests;
        attributeDict["checked"] = "";

        // Act
        var cut = Render<BsButtonCheckInputCheckbox>(parameters =>
            parameters.Bind(p => p.Value, value, newValue => value = newValue)
        );

        // Assert
        var expectedMarkupString = GetExpectedHtml(classes: "", attributeDict);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData(false, false, false)]
    [InlineData(true, true, true)]
    [InlineData(true, false, false)]
    [InlineData(false, true, true)]
    public void CheckingCheckboxSetsCorrectValue(bool beforeValue, bool afterValue, bool hasCheckedAttribute)
    {
        // Arrange
        var value = beforeValue;
        var attributeDict = AttributesForDefaultTests;
        if (hasCheckedAttribute)
        {
            attributeDict["checked"] = "";
        }

        // Act
        var cut = Render<BsButtonCheckInputCheckbox>(parameters =>
            parameters.Bind(p => p.Value, value, newValue => value = newValue)
        );
        var inputElement = cut.Find("input");
        inputElement.Change(afterValue);

        // Assert
        var expectedMarkupString = GetExpectedHtml(classes: "", attributeDict);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Fact]
    public void InputTypeCannotBeOverriden()
    {
        TestForDisallowingOverride("type");
    }
}
