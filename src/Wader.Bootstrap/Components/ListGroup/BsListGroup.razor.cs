using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.Components.ListGroup;

public partial class BsListGroup : BsChildContentComponent
{
    protected override string BsComponentClasses => $"list-group {TypeClass} {DirectionClass} {ModeClass}";

    [Parameter]
    public BsListType Type { get; set; }

    private string? TypeClass => Type.ToBootstrapClass();

    [Parameter]
    public BsListGroupDirection Direction { get; set; }

    private string? DirectionClass => Direction.ToBootstrapClass();

    [Parameter]
    public BsListGroupMode Mode { get; set; }

    private string? ModeClass => Mode.ToBootstrapClass();
}
