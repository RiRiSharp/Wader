using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Infrastructure.Constants;

namespace Wader.Bootstrap.Components.NavBar;

public partial class BsNavLink : BsChildContentComponent
{
    protected override string? BsComponentClasses => $"nav-link {DropdownOptionsClass}";

    [CascadingParameter(Name = CascadingValueNames.NAV_ITEM_OPTIONS)]
    private BsNavItemOptions Mode { get; set; } = BsNavItemOptions.NoDropdown;

    private string DropdownOptionsClass => Mode.ToNavLinkBootstrapClass() ?? "";

    [Parameter]
    public NavLinkMatch Match { get; set; }
}
