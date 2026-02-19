namespace Wader.Bootstrap.Forms.ChecksRadios;

public partial class BsButtonCheckInputCheckbox : BsInputBase<bool>
{
    protected override string BsComponentClasses => "btn-check";

    protected override bool TryParseValueFromString(string? value, out bool result, out string validationErrorMessage)
    {
        throw new NotImplementedException("This method is not necessary for parsing input checkboxes.");
    }
}
