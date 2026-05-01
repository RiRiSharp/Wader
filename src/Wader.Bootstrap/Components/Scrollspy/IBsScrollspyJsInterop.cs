using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.Components.Scrollspy;

public interface IBsScrollspyJsInterop
{
    ValueTask CreateAsync(
        ElementReference hostElementRef,
        ElementReference targetElementRef,
        ScrollspyJsOptions? options = null
    );

    Task DisposeReferenceAsync(ElementReference elementRef);
}
