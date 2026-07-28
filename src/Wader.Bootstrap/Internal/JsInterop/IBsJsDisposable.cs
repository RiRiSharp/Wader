using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.Internal.JsInterop;

/// <summary>
///     An interface exposing methods for disposing Bootstrap objects in the JavaScript world.
/// </summary>
public interface IBsJsDisposable
{
    /// <summary>
    ///     Disposes the reference the Bootstrap JS framework has.
    /// </summary>
    /// <param name="elementRef">The element Bootstrap JS needs to dispose</param>
    Task DisposeReferenceAsync(ElementReference elementRef);
}
