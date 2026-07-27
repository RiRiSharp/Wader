using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Infrastructure.BaseComponents;

namespace Wader.Bootstrap.Components.NavBar;

public partial class BsNavbarNav : BsChildContentComponent
{
    protected override string? BsComponentClasses => $"navbar-nav {ModeClass}";

    [Parameter]
    public NavbarScrollingMode ScrollingMode { get; set; }

    private string? ModeClass => ScrollingMode.ToBootstrapClass();
}
