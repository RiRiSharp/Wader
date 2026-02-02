using Microsoft.AspNetCore.Components;
using Wader.BaseComponents;
using Wader.Primitives;

namespace Wader.Layout.Containers;

public partial class BsContainerFluid : BsChildContentComponent
{
    protected override string? BsComponentClasses => "container-fluid";
}
