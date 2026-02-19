using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap.Components.Alert.Internals;

public interface IBsAlertJsFunctions : IBsJsDisposable
{
    Task DismissAsync(ElementReference alertRef);
    Task RegisterDismissCallbackAsync(ElementReference alertRef, DotNetObjectReference<BsAlert> dotNetRef);
}
