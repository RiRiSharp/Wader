using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Infrastructure.JsInterop;

namespace Wader.Bootstrap.Components.Offcanvas.Internals;

public interface IBsOffcanvasJsInterop : IBsJsDisposable
{
    Task ToggleAsync(ElementReference offcanvasRef);
    Task ShowAsync(ElementReference offcanvasRef);
    Task CloseAsync(ElementReference offcanvasRef);
}
