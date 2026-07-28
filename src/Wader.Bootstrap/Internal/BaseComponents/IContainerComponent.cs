using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.Internal.BaseComponents;

public interface IContainerComponent
{
    ElementReference ElementRef { get; }
}
