using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;

namespace Wader.Bootstrap.Helpers.Position;

public partial class BsSticky : BsChildContentComponent
{
    protected override string BsComponentClasses => $"{Position.ToBootstrapClass()}";

    [Parameter]
    public BsStickyPosition Position { get; set; }
    // TODO: Add breakpoints
}
