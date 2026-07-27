using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.Infrastructure.BaseComponents;

public interface IContainerComponent
{
    ElementReference ElementRef { get; }
}
