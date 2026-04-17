using Wader.Bootstrap.Components.ButtonGroup;

namespace Wader.Bootstrap.Tests.Components.ButtonGroup;

public class BsButtonGroupVerticalTests()
    : BsComponentTests<BsButtonGroupVertical>("""<div class="btn-group-vertical {0}" {1}></div>""")
{
    protected override Dictionary<string, string> AttributesForDefaultTests => new() { ["role"] = "group" };

    [Theory]
    [InlineData(BsButtonGroupSize.Regular, "")]
    [InlineData(BsButtonGroupSize.Small, "btn-group-sm")]
    [InlineData(BsButtonGroupSize.Large, "btn-group-lg")]
    public void SizeAddsCorrectClass(BsButtonGroupSize size, string? expectedClass)
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

    [Fact]
    public void GroupRoleCanBeOverriden()
    {
        TestForAllowingOverride("role");
    }
}
