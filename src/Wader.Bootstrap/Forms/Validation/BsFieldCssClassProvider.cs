using Microsoft.AspNetCore.Components.Forms;

namespace Wader.Bootstrap.Forms.Validation;

public class BsFieldCssClassProvider(bool showValidInput = true) : FieldCssClassProvider
{
    public override string GetFieldCssClass(EditContext editContext, in FieldIdentifier fieldIdentifier)
    {
        ArgumentNullException.ThrowIfNull(editContext);
        var isInvalid = editContext.GetValidationMessages(fieldIdentifier).Any();
        return DetermineClass(editContext.IsModified(fieldIdentifier), isInvalid);
    }

    internal string DetermineClass(bool isModified, bool isInvalid)
    {
        if (!isModified)
        {
            return "";
        }

        if (isInvalid)
        {
            return "is-invalid";
        }

        return showValidInput ? "is-valid" : "";
    }
}
