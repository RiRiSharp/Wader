using Microsoft.AspNetCore.Components.Forms;

namespace Wader.Bootstrap.Forms.Validation;

public class BsFieldCssClassProvider(
    ValidationMessageShowMode invalidMessages = ValidationMessageShowMode.WhenTouchedOrModified,
    ValidationMessageShowMode validMessages = ValidationMessageShowMode.WhenModified
) : FieldCssClassProvider
{
    public enum InteractionMode
    {
        Modified = 0,
        Touched = 1,
    }

    public override string GetFieldCssClass(EditContext editContext, in FieldIdentifier fieldIdentifier)
    {
        ArgumentNullException.ThrowIfNull(editContext);
        var isInvalid = editContext.GetValidationMessages(fieldIdentifier).Any();
        var interaction = editContext.IsModified(fieldIdentifier) ? InteractionMode.Modified : InteractionMode.Touched;

        return DetermineClass(isInvalid, interaction);
    }

    internal string DetermineClass(bool isInvalid, InteractionMode interaction)
    {
        if (
            isInvalid
            && interaction == InteractionMode.Modified
            && invalidMessages.HasFlag(ValidationMessageShowMode.WhenModified)
        )
        {
            return "is-invalid";
        }

        if (
            isInvalid
            && interaction == InteractionMode.Touched
            && invalidMessages.HasFlag(ValidationMessageShowMode.WhenTouched)
        )
        {
            return "is-invalid";
        }

        var isValid = !isInvalid;
        if (
            isValid
            && interaction == InteractionMode.Modified
            && validMessages.HasFlag(ValidationMessageShowMode.WhenModified)
        )
        {
            return "is-valid";
        }

        if (
            isValid
            && interaction == InteractionMode.Touched
            && validMessages.HasFlag(ValidationMessageShowMode.WhenTouched)
        )
        {
            return "is-valid";
        }

        return "";
    }
}
