using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.Forms.ChecksRadios.Internals;

public interface IBsCheckboxJsFunctions
{
    ValueTask InitializeIndeterminateAsync(ElementReference checkboxReference);
}
