using Wader.Bootstrap.Components.NavBar;

namespace Wader.Bootstrap.Tests.Components.Navbar;

public class BsNavLinkTests() : BsComponentTests<BsNavLink>("""<a class="nav-link {0}" {1}></a>""")
{
    [Theory]
    [InlineData(BsNavItemOptions.NoDropdown, "")]
    [InlineData(BsNavItemOptions.WithDropdown, "dropdown-toggle")]
    public void CascadingModeAddsCorrectClass(BsNavItemOptions options, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.AddCascadingValue(nameof(BsNavItem), options));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }
}
