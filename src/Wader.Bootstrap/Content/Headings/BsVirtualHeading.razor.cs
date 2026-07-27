using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Infrastructure.BaseComponents;

namespace Wader.Bootstrap.Content.Headings;

public partial class BsVirtualHeading : BsChildContentComponent
{
    protected override string? BsComponentClasses => Type.ToBootstrapClass();

    [Parameter]
    public BsHeadingType Type { get; set; }
}
