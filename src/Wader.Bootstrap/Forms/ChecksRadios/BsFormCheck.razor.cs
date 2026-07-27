using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Infrastructure.BaseComponents;

namespace Wader.Bootstrap.Forms.ChecksRadios;

public partial class BsFormCheck : BsChildContentComponent
{
    private readonly string _additionalFormCheckClasses;

    public BsFormCheck(string additionalFormCheckClasses = "")
    {
        _additionalFormCheckClasses = additionalFormCheckClasses;
    }

    protected override string? BsComponentClasses =>
        $"form-check {_additionalFormCheckClasses} {FormCheckOptions.ToBootstrapClass()}";

    [Parameter]
    public BsFormCheckOptions FormCheckOptions { get; set; }
}
