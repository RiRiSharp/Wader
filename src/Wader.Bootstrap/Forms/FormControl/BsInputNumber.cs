using Microsoft.AspNetCore.Components.Forms;
using Wader.Bootstrap.Internal;
using Wader.Bootstrap.Internal.BaseComponents;

namespace Wader.Bootstrap.Forms.FormControl;

public class BsInputNumber<TValue> : InputNumber<TValue>, IBsComponent
{
    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        SetClasses();
    }

    private void SetClasses()
    {
        var componentSpecificClasses = GetBsComponentSpecificClasses();
        AdditionalAttributes = BsClassAttributeUtilities.AssignClassNames(
            AdditionalAttributes,
            componentSpecificClasses
        );
    }

    private static string GetBsComponentSpecificClasses()
    {
        return "form-control";
    }
}
