using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Infrastructure.BaseComponents;

namespace Wader.Bootstrap.Forms.InputGroup;

public partial class BsInputGroup : BsChildContentComponent
{
    [Parameter]
    public BsInputGroupSize Size { get; set; }

    protected override string? BsComponentClasses => $"input-group has-validation {Size.ToBootstrapClass()}";
}
