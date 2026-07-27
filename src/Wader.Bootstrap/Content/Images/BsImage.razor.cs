using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Infrastructure.BaseComponents;

namespace Wader.Bootstrap.Content.Images;

public partial class BsImage : BsComponent
{
    protected override string? BsComponentClasses => Options.ToBootstrapClass();

    [Parameter]
    public BsImageOptions Options { get; set; }

    [Parameter, EditorRequired]
    public string Src { get; set; }

    [Parameter]
    public string? Alt { get; set; }
}
