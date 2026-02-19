using Wader.Bootstrap.Components.NavBar;

namespace Wader.Bootstrap.UnitTests.Components.Navbar;

public class BsNavItemTests() : BsComponentTests<BsNavItem>("""<li class="nav-item {0}" {1}></li>""")
{
    [Theory]
    [InlineData(BsDropdownOptions.NoDropdown, "")]
    [InlineData(BsDropdownOptions.WithDropdown, "dropdown")]
    public void OptionsAddsCorrectClass(BsDropdownOptions options, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.DropdownOptions, options));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Fact]
    public void DropdownOptionsIsCascading()
    {
        TestForCascadingValue<BsDropdownOptions>();
    }
}
