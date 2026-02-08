using Wader.Components.Dropdown;

namespace Wader.UnitTests.Components.Dropdown;

public class BsDropdownItemTests()
    : BsComponentTests<BsDropdownItem>("""<li><a class="dropdown-item {0}" {1}></a></li>""")
{
    [Theory]
    [InlineData(BsDropdownItemType.Link, "a")]
    [InlineData(BsDropdownItemType.Button, "button")]
    public void ItemTypeCreatesCorrectTag(BsDropdownItemType type, string expectedTag)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.ItemType, type));

        // Assert
        cut.MarkupMatches($"<li><{expectedTag} diff:ignoreAttributes></{expectedTag}></li>");
    }

    [Theory]
    [InlineData(false, "")]
    [InlineData(true, "active")]
    public void ActiveAddsCorrectClass(bool isActive, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Active, isActive));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData(false, "")]
    [InlineData(true, "disabled")]
    public void DisabledAddsCorrectClass(bool isDisabled, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Disabled, isDisabled));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }
}
