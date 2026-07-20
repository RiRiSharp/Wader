using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.Components.Card;

public partial class BsCardImage : BsComponent
{
    protected override string? BsComponentClasses => Position.ToBootstrapClass();

    [Parameter]
    public BsCardImagePosition Position { get; set; }

    [Parameter, EditorRequired]
    public string Src { get; set; }

    [Parameter]
    public string? Alt { get; set; }
}
