using Wader.Bootstrap.Forms.InputGroup;

namespace Wader.Bootstrap.Tests.Forms.InputGroup;

public class BsInputGroupTests()
    : BsComponentTests<BsInputGroup>("""<div class="input-group has-validation {0}" {1}></div>""")
{
    [Theory]
    [InlineData(BsInputGroupSize.Small, "input-group-sm")]
    [InlineData(BsInputGroupSize.Regular, "")]
    [InlineData(BsInputGroupSize.Large, "input-group-lg")]
    public void PassingParametersRendersIntoCorrectBsClass(BsInputGroupSize formSize, string expected)
    {
        // Arrange + Act
        var cut = GetCut(parameters => parameters.Add(p => p.Size, formSize));

        // Assert
        cut.MarkupMatches(GetExpectedHtml(expected, ""));
    }
}
