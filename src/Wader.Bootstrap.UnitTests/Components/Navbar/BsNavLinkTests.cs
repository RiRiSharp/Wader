using Wader.Bootstrap.Components.NavBar;

namespace Wader.Bootstrap.UnitTests.Components.Navbar;

public class BsNavLinkTests() : BsComponentTests<BsNavLink>("""<a class="nav-link {0}" {1}></a>""")
{
    [Theory]
    [InlineData(BsDropdownOptions.NoDropdown, "")]
    [InlineData(BsDropdownOptions.WithDropdown, "dropdown-toggle")]
    public void CascadingDropdownOptionsAddsCorrectClass(BsDropdownOptions options, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.AddCascadingValue(options));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }
}
