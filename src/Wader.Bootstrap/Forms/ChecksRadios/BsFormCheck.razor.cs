using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.Forms.ChecksRadios;

public partial class BsFormCheck : BsChildContentComponent
{
    private readonly string _additionalFormCheckClasses;

    protected override string BsComponentClasses =>
        $"form-check {_additionalFormCheckClasses} {FormCheckOptions.ToBootstrapClass()}";

    public BsFormCheck(string additionalFormCheckClasses = "")
    {
        _additionalFormCheckClasses = additionalFormCheckClasses;
    }

    [Parameter]
    public BsFormCheckOptions FormCheckOptions { get; set; }
}
