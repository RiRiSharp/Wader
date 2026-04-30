using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Components.Scrollspy.Internals;

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
