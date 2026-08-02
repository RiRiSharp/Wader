using Wader.Bootstrap.Forms;
using Wader.Bootstrap.Forms.FormControl;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Forms.FormControl;

public class BsInputTextAreaTests()
    : BsInputBaseComponentTests<BsInputTextArea, string?>("""<textarea class="{0}" {1}></textarea>""")
{
    protected override string ClassesForDefaultTests => "form-control";

    [Theory]
    [InlineData(BsFormSize.Large, "form-control-lg")]
    [InlineData(BsFormSize.Regular, "")]
    [InlineData(BsFormSize.Small, "form-control-sm")]
    public void PassingParametersRendersIntoCorrectBsClass(BsFormSize formSize, string expected)
    {
        // Arrange
        Value = "";
        var attributes = AttributesForDefaultTests;
        attributes["value"] = Value;

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Size, formSize));

        // Assert
        cut.MarkupMatches(GetExpectedHtml($"{expected} {ClassesForDefaultTests}", attributes));
    }

    [Fact]
    public void PlaintextRendersCorrectly()
    {
        // Arrange
        Value = "";
        var attributes = AttributesForDefaultTests;
        attributes["value"] = Value;
        attributes["readonly"] = "";

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.ReadonlyPlaintext, value: true));

        // Assert
        cut.MarkupMatches(GetExpectedHtml(classes: "form-control-plaintext", attributes));
    }
}
