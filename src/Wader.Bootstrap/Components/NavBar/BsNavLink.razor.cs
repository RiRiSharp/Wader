using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.Components.NavBar;

public partial class BsNavLink : BsChildContentComponent
{
    protected override string BsComponentClasses => $"nav-link {DropdownOptionsClass}";

    [CascadingParameter]
    private BsDropdownOptions? DropdownOptions { get; set; }

    private string DropdownOptionsClass => DropdownOptions?.ToNavLinkBootstrapClass() ?? "";
}
