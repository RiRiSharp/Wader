using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.Internal.BaseComponents;

public interface IBsChildContentComponent : IBsComponent
{
    RenderFragment? ChildContent { get; set; }
}
