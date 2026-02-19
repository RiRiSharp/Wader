using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.Content.Abbreviations;

public partial class BsAbbreviation : BsChildContentComponent
{
    protected override string? BsComponentClasses => Type.ToBootstrapClass();

    [Parameter, EditorRequired]
    public string FullName { get; set; }

    [Parameter]
    public BsAbbreviationType Type { get; set; }
}
