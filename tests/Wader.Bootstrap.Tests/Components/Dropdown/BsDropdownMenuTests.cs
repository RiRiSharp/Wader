using Wader.Bootstrap.Components.Dropdown;
using Wader.Bootstrap.Primitives;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Dropdown;

public class BsDropdownMenuTests() : BsComponentTests<BsDropdownMenu>("""<ul class="dropdown-menu {0}" {1}></ul>""")
{
    [Theory]
    [InlineData(BsDirection.Start, "")]
    [InlineData(BsDirection.End, "dropdown-menu-end")]
    public void MenuDirectionAddsCorrectClass(BsDirection direction, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Direction, direction));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData(BsDirection.Up)]
    [InlineData(BsDirection.Down)]
    public void WrongDirectionsThrowOutOfRangeException(BsDirection direction)
    {
        // Arrange
        ConfigureTestContext();

        // Act + Assert
        _ = Assert.Throws<ArgumentOutOfRangeException>(() =>
            GetCut(parameters => parameters.Add(p => p.Direction, direction))
        );
    }
}
