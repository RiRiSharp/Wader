using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.BaseComponents;

public interface IBsChildContentComponent : IBsComponent
{
    RenderFragment? ChildContent { get; set; }
}
