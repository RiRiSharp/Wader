namespace Wader.Bootstrap.Forms.ChecksRadios;

public partial class BsInputCheckbox : BsInputBase<bool>
{
    protected override bool TryParseValueFromString(string? value, out bool result, out string validationErrorMessage)
    {
        throw new NotImplementedException("This method is not necessary for parsing input checkboxes.");
    }

    protected override string BsComponentClasses => "form-check-input";
}
