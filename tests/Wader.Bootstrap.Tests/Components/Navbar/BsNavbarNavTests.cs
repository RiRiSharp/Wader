using Wader.Bootstrap.Components.NavBar;

namespace Wader.Bootstrap.Tests.Components.Navbar;

public class BsNavbarNavTests() : BsComponentTests<BsNavbarNav>("""<ul class="navbar-nav {0}" {1}></ul>""")
{
    [Theory]
    [InlineData(NavbarScrollingMode.Regular, "")]
    [InlineData(NavbarScrollingMode.EnableVerticalScrolling, "navbar-nav-scroll")]
    public void ScrollingModeAddsCorrectClass(NavbarScrollingMode mode, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.ScrollingMode, mode));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }
}
