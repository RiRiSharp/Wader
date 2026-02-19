using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap.Components.Buttons.Internals;

public interface IBsButtonJsFunctions : IBsJsDisposable
{
    Task ToggleAsync(ElementReference buttonRef);
}
