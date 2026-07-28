using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;
using Wader.Bootstrap.Internal.Primitives;

namespace Wader.Bootstrap.Layout.Containers;

public partial class BsContainer : BsChildContentComponent
{
    protected override string? BsComponentClasses => Breakpoint.ToBootstrapContainerClass();

    [Parameter]
    public BsBreakpoint Breakpoint { get; set; }
}
