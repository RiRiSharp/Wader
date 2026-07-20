using Wader.Bootstrap.Components.NavBar;
using Wader.Bootstrap.Infrastructure.Constants;

namespace Wader.Bootstrap.Tests.Components.Navbar;

public class BsNavItemTests() : BsComponentTests<BsNavItem>("""<li class="nav-item {0}" {1}></li>""")
{
    [Theory]
    [InlineData(BsNavItemOptions.NoDropdown, "")]
    [InlineData(BsNavItemOptions.WithDropdown, "dropdown")]
    public void OptionsAddsCorrectClass(BsNavItemOptions options, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Options, options));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Fact]
    public void DropdownOptionsIsCascading()
    {
        TestForCascadingValue<BsNavItemOptions>(CascadingValueNames.NAV_ITEM_OPTIONS);
    }
}
