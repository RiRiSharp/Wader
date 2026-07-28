using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;

namespace Wader.Bootstrap.Content.Tables;

public partial class BsTableResponsive : BsChildContentComponent
{
    protected override string? BsComponentClasses => Breakpoint.ToBootstrapClass();

    [Parameter]
    public BsTableBreakpoint Breakpoint { get; set; }
}
