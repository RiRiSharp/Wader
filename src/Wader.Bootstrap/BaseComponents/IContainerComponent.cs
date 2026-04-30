using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.BaseComponents;

public interface IContainerComponent
{
    ElementReference ElementRef { get; }
}
