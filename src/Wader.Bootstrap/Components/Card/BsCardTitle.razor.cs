using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Infrastructure.BaseComponents;

namespace Wader.Bootstrap.Components.Card;

public partial class BsCardTitle : BsChildContentComponent
{
    protected override string? BsComponentClasses => "card-title";

    [Parameter]
    public int Heading { get; set; } = 5;
}
