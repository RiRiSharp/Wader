using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.Components.Card;

public partial class BsCardHeaderTitle : BsChildContentComponent
{
    protected override string? BsComponentClasses => "card-header";

    [Parameter]
    public int Heading { get; set; } = 5;
}
