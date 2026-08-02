using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;

namespace Wader.Bootstrap.Helpers.Position;

public partial class BsFixed : BsChildContentComponent
{
    protected override string BsComponentClasses => Position.ToFixedClass();

    [Parameter]
    public BsGluePosition Position { get; set; }
    // TODO: Add breakpoints
}
