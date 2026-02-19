using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Forms.ChecksRadios.Internals;

namespace Wader.Bootstrap.Forms.ChecksRadios;

public partial class BsIndeterminateInputCheckbox : BsInputBase<bool?>
{
    private readonly IBsCheckboxJsFunctions _bsCheckboxJsFunctions;
    internal ElementReference HtmlRef;

    public BsIndeterminateInputCheckbox(IBsCheckboxJsFunctions bsCheckboxJsFunctions)
    {
        _bsCheckboxJsFunctions = bsCheckboxJsFunctions;
    }

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();
        if (CurrentValue is null)
        {
            await _bsCheckboxJsFunctions.InitializeIndeterminateAsync(HtmlRef);
        }
    }

    protected override bool TryParseValueFromString(string? value, out bool? result, out string validationErrorMessage)
    {
        throw new NotImplementedException("This method is not necessary for parsing input checkboxes.");
    }

    protected override string BsComponentClasses => "form-check-input";
}
