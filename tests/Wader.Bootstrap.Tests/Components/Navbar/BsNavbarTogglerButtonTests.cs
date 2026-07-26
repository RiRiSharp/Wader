using Wader.Bootstrap.Components.NavBar;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Navbar;

public class BsNavbarTogglerButtonTests()
    : BsComponentTests<BsNavbarTogglerButton>("""<button class="navbar-toggler {0}" {1}></div>""")
{
    protected override Dictionary<string, string> AttributesForDefaultTests =>
        new() { ["type"] = "button", ["aria-expanded"] = "false" };

    [Fact]
    public void ButtonTypeCanBeOverriden()
    {
        TestForAllowingOverride("type");
    }

    [Fact]
    public void AriaExpandedCanBeOverriden()
    {
        TestForAllowingOverride("aria-expanded");
    }
}
