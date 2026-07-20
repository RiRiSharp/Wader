using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.Components.Modal;

public partial class BsModalTitle : BsChildContentComponent
{
    protected override string? BsComponentClasses => "modal-title";

    [Parameter]
    public int Heading { get; set; } = 5;
}
