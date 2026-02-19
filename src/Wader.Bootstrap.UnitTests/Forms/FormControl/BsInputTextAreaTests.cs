using Wader.Bootstrap.Forms;
using Wader.Bootstrap.Forms.FormControl;

namespace Wader.Bootstrap.UnitTests.Forms.FormControl;

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

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Size, formSize));

        // Assert
        cut.MarkupMatches(GetExpectedHtml($"{expected} {ClassesForDefaultTests}", "value=\"\""));
    }

    [Fact]
    public void PlaintextRendersCorrectly()
    {
        // Arrange
        Value = "";

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.ReadonlyPlaintext, true));

        // Assert
        cut.MarkupMatches(GetExpectedHtml("form-control-plaintext", "value=\"\" readonly=\"\""));
    }
}
