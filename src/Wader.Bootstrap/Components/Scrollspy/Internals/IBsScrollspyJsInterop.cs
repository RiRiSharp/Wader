using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.Components.Scrollspy.Internals;

public interface IBsScrollspyJsInterop
{
    ValueTask CreateAsync(ElementReference hostElementRef, ScrollspyJsOptions? options = null);

    Task DisposeReferenceAsync(ElementReference elementRef);
}
