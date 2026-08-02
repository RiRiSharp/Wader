using Wader.Bootstrap.Forms.ChecksRadios;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Forms.ChecksRadios;

public class BsFormCheckTests() : BsComponentTests<BsFormCheck>("""<div class="form-check {0}" {1}></div>""")
{
    [Theory]
    [InlineData(BsFormCheckOptions.Stacked, "")]
    [InlineData(BsFormCheckOptions.Inline, "form-check-inline")]
    [InlineData(BsFormCheckOptions.Reverse, "form-check-reverse")]
    public void PassingParametersRendersIntoCorrectBsClass(BsFormCheckOptions formCheckOptions, string expected)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.FormCheckOptions, formCheckOptions));
        // Assert
        cut.MarkupMatches(GetExpectedHtml(expected));
    }
}
