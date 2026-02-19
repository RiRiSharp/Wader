using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap.Forms.ChecksRadios;

public class BsButtonCheckInputRadio<TValue> : InputRadio<TValue>, IBsComponent
{
    [Parameter]
    public BsFormCheckOptions FormCheckOptions { get; set; } = BsFormCheckOptions.Stacked;

    [Parameter]
    public string? Classes { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        SetClasses();
    }

    private void SetClasses()
    {
        var componentSpecificClasses = GetBsComponentSpecificClasses();
        var allClasses = $"{componentSpecificClasses} {Classes}";
        AdditionalAttributes = BsAttributeUtilities.AssignClassNames(AdditionalAttributes, allClasses);
    }

    private static string GetBsComponentSpecificClasses()
    {
        return "btn-check";
    }
}
