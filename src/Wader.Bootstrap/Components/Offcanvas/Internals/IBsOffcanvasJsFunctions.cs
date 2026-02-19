using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap.Components.Offcanvas.Internals;

public interface IBsOffcanvasJsFunctions : IBsJsDisposable
{
    Task ToggleAsync(ElementReference offcanvasRef);
    Task ShowAsync(ElementReference offcanvasRef);
    Task CloseAsync(ElementReference offcanvasRef);
}
