using Microsoft.AspNetCore.Components.Forms;

namespace Wader.Bootstrap.Forms.Validation;

public static class BsEditContextBuilder
{
    public static EditContext Build(object model, bool showValidInput = true)
    {
        var editContext = new EditContext(model);
        editContext.SetFieldCssClassProvider(new BsFieldCssClassProvider(showValidInput));
        return editContext;
    }
}
