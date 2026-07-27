using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Wader.Bootstrap.Infrastructure;
using Wader.Bootstrap.Infrastructure.BaseComponents;

namespace Wader.Bootstrap.Forms;

public class BsEditForm : EditForm, IBsComponent
{
    [Parameter]
    public string? Classes { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        SetClasses();
    }

    private void SetClasses()
    {
        AdditionalAttributes = BsClassAttributeUtilities.AssignClassNames(AdditionalAttributes, Classes);
    }
}
