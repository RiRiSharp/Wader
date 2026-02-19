using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.Components.Dropdown;

public partial class BsDropdownHeader : BsChildContentComponent
{
    protected override string BsComponentClasses => "dropdown-header";

    [Parameter]
    public int Heading { get; set; } = 6;
}
