using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.Internal.BaseComponents;

public abstract class BsChildContentComponent : BsComponent, IBsChildContentComponent
{
    [Parameter, EditorRequired]
    public RenderFragment? ChildContent { get; set; }
}
