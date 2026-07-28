using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;
using Wader.Icons.Internals;

namespace Wader.Icons.Phosphor;

public partial class PhosphorIcon : BsComponent
{
    protected override string? BsComponentClasses => null;

    [Parameter, EditorRequired]
    public string Name { get; set; }

    [Parameter]
    public PhosphorIconWeight Weight { get; set; } = PhosphorIconWeight.Regular;

    private string WeightFileName => Weight.ToSpriteFileName();

    private string IconPath => $"{LibraryInfo.RootPath}/sprites/phosphor/{WeightFileName}.svg#{Name}";
}
