using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.Components.Alert;

public partial class BsAlertHeading : BsChildContentComponent
{
    protected override string BsComponentClasses => "alert-heading";

    [Parameter]
    public int Heading { get; set; } = 4;
}
