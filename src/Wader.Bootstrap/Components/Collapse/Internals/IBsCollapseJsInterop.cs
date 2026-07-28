using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.JsInterop;

namespace Wader.Bootstrap.Components.Collapse.Internals;

public interface IBsCollapseJsInterop : IBsJsDisposable
{
    Task CollapseAsync(ElementReference collapseRef);
    Task ShowAsync(ElementReference collapseRef);
    Task ToggleAsync(ElementReference collapseRef);
}
