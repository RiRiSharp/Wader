using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.Forms.ChecksRadios.Internals;

public interface IBsCheckboxJsInterop
{
    ValueTask InitializeIndeterminateAsync(ElementReference checkboxReference);
}
