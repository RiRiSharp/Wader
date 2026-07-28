using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;
using Wader.Bootstrap.Internal.Primitives;

namespace Wader.Bootstrap.Components.Dropdown;

public partial class BsDropdown : BsChildContentComponent
{
    protected override string? BsComponentClasses => $"{DropdownDirectionClass} {DropdownClass}";

    [Parameter]
    public BsDirection Drop { get; set; }

    private string DropdownDirectionClass => Drop.ToDropDirectionBootstrapClass();

    [Parameter]
    public BsDropdownMode Mode { get; set; }

    private string? DropdownClass => Mode.ToBootstrapDropdownClass();
}
