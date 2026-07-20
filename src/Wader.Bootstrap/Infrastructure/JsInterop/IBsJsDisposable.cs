using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.Infrastructure.JsInterop;

public interface IBsJsDisposable
{
    Task DisposeReferenceAsync(ElementReference elementRef);
}
