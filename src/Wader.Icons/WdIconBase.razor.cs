using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Icons;

public partial class WdIconBase : BsComponent
{
    protected override string? BsComponentClasses => "bi";

    [Parameter, EditorRequired]
    public string IconPath { get; set; }
}
