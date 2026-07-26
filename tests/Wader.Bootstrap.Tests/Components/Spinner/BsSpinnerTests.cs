using Wader.Bootstrap.Components.Spinners;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Spinner;

public class BsSpinnerTests() : BsComponentTests<BsSpinner>("""<div class="{0}" {1}></div>""")
{
    protected override string ClassesForDefaultTests => "spinner-border";

    [Theory]
    [InlineData(BsSpinnerVariant.Border, "spinner-border")]
    [InlineData(BsSpinnerVariant.Grow, "spinner-grow")]
    public void ParameterVariant_AddsVariantClass(BsSpinnerVariant variant, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.Variant, variant));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData(BsSpinnerSize.Regular, BsSpinnerVariant.Border, "spinner-border")]
    [InlineData(BsSpinnerSize.Small, BsSpinnerVariant.Border, "spinner-border spinner-border-sm")]
    [InlineData(BsSpinnerSize.Regular, BsSpinnerVariant.Grow, "spinner-grow")]
    [InlineData(BsSpinnerSize.Small, BsSpinnerVariant.Grow, "spinner-grow spinner-grow-sm")]
    public void ParameterSize_AddsSizeClass(BsSpinnerSize size, BsSpinnerVariant variant, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.Size, size).Add(x => x.Variant, variant));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }
}
