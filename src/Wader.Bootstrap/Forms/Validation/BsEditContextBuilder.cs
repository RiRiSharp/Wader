using Microsoft.AspNetCore.Components.Forms;

namespace Wader.Bootstrap.Forms.Validation;

public static class BsEditContextBuilder
{
    public static EditContext Build(
        object model,
        ValidationMessageShowMode invalidInputShowMode = ValidationMessageShowMode.WhenTouchedOrModified,
        ValidationMessageShowMode validInputShowMode = ValidationMessageShowMode.WhenModified
    )
    {
        var editContext = new EditContext(model);
        editContext.SetFieldCssClassProvider(new BsFieldCssClassProvider(invalidInputShowMode, validInputShowMode));
        return editContext;
    }
}
