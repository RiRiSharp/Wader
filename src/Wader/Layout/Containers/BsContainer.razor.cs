using Microsoft.AspNetCore.Components;
using Wader.BaseComponents;
using Wader.Primitives;

namespace Wader.Layout.Containers;

public partial class BsContainer : BsChildContentComponent
{
    protected override string? BsComponentClasses => Breakpoint.ToBootstrapContainerClass();

    [Parameter]
    public BsBreakpoint Breakpoint { get; set; }
}
