using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;

namespace Wader.Bootstrap.Content.Typography.Headings;

public partial class BsDisplayHeading : BsChildContentComponent
{
    protected override string? BsComponentClasses => Type.ToBootstrapClass();

    [Parameter]
    public BsDisplayHeadingType Type { get; set; }
}
