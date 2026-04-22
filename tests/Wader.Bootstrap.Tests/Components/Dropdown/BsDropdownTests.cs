using Wader.Bootstrap.Components.Dropdown;
using Wader.Bootstrap.Internals.Constants;
using Wader.Bootstrap.Primitives;

namespace Wader.Bootstrap.Tests.Components.Dropdown;

public class BsDropdownTests() : BsComponentTests<BsDropdown>("""<div class="{0}" {1}></div>""")
{
    protected override string ClassesForDefaultTests => "dropdown";

    [Theory]
    [InlineData(BsDirection.Down, "dropdown")]
    [InlineData(BsDirection.Up, "dropup")]
    [InlineData(BsDirection.Start, "dropstart")]
    [InlineData(BsDirection.End, "dropend")]
    public void DirectionAddsCorrectClass(BsDirection direction, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Drop, direction));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData(BsDropdownMode.Regular, "")]
    [InlineData(BsDropdownMode.Split, "btn-group")]
    public void ModeAddsCorrectClass(BsDropdownMode dropdownMode, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Mode, dropdownMode));

        // Assert
        var expectedMarkupString = GetExpectedHtml(
            $"{ClassesForDefaultTests} {expectedClass}",
            AttributesForDefaultTests
        );
        cut.MarkupMatches(expectedMarkupString);
    }

    [Fact]
    public void DropdownModeIsCascading()
    {
        TestForCascadingValue<BsDropdownMode>(CascadingValueNames.DROPDOWN_MODE);
    }
}
