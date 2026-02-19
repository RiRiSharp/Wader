using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Primitives;

namespace Wader.Bootstrap.Components.Dropdown;

public partial class BsDropdown : BsChildContentComponent
{
    protected override string BsComponentClasses => $"{DropdownDirectionClass} {DropdownClass}";

    [Parameter]
    public BsDirection Drop { get; set; }

    private string DropdownDirectionClass => Drop.ToDropDirectionBootstrapClass();

    [Parameter]
    public BsDropdownMode Mode { get; set; }

    private string? DropdownClass => Mode.ToBootstrapDropdownClass();
}
