using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.JsInterop;

namespace Wader.Bootstrap.Components.Toasts.Internals;

public interface IBsToastJsInterop : IBsJsDisposable
{
    Task CreateAsync(ElementReference toastRef, ToastJsOptions? options = null);
    Task ShowAsync(ElementReference toastRef);
    Task HideAsync(ElementReference toastRef);
}
