using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Infrastructure.BaseComponents;

namespace Wader.Bootstrap.Components.NavBar;

public partial class BsNavItem : BsChildContentComponent
{
    protected override string? BsComponentClasses => $"nav-item {OptionsClass}";

    [Parameter]
    public BsNavItemOptions Options { get; set; }

    private string? OptionsClass => Options.ToNavItemBootstrapClass();
}
