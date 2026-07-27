using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.Infrastructure.BaseComponents;

public interface IBsChildContentComponent : IBsComponent
{
    RenderFragment? ChildContent { get; set; }
}
