using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.JsInterop;

namespace Wader.Bootstrap.Components.Buttons.Internals;

public interface IBsButtonJsInterop : IBsJsDisposable
{
    Task ToggleAsync(ElementReference buttonRef);
}
