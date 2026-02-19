using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.Internals;

public interface IBsJsDisposable
{
    Task DisposeAsync(ElementReference elementRef);
}
