using Microsoft.AspNetCore.Components;
using Wader.BaseComponents;

namespace Wader.Components.Dropdown;

public partial class BsDropdownItem : BsChildContentComponent
{
    protected override string BsComponentClasses => $"dropdown-item {ActiveClass} {DisabledClass}";

    [Parameter]
    public BsDropdownItemType ElType { get; set; }

    [Parameter]
    public bool Active { get; set; }

    private string? ActiveClass => Active ? "active" : null;

    [Parameter]
    public bool Disabled { get; set; }

    private string? DisabledClass => Disabled ? "disabled" : null;
}
