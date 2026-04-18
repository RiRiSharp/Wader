using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.Components.NavBar;

public partial class BsNavLink : BsChildContentComponent
{
    protected override string BsComponentClasses => $"nav-link {DropdownOptionsClass}";

    [CascadingParameter(Name = nameof(BsNavItem))]
    private BsNavItemOptions Mode { get; set; } = BsNavItemOptions.NoDropdown;
    private string DropdownOptionsClass => Mode.ToNavLinkBootstrapClass() ?? "";

    [Parameter]
    public NavLinkMatch Match { get; set; }
}
