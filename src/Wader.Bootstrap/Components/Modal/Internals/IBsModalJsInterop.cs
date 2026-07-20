using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Infrastructure.JsInterop;

namespace Wader.Bootstrap.Components.Modal.Internals;

public interface IBsModalJsInterop : IBsJsDisposable
{
    Task ToggleAsync(ElementReference modalRef);
    Task ShowAsync(ElementReference modalRef);
    Task CloseAsync(ElementReference modalRef);
    Task HandleUpdateAsync(ElementReference modalRef);
}
