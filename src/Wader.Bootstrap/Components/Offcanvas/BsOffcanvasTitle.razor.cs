using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.Components.Offcanvas;

public partial class BsOffcanvasTitle : BsChildContentComponent
{
    protected override string BsComponentClasses => "offcanvas-title";

    [Parameter]
    public int Heading { get; set; } = 5;
}
