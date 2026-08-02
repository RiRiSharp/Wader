using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;

namespace Wader.Bootstrap.Helpers.Stacks;

public partial class BsHstack : BsChildContentComponent
{
    protected override string BsComponentClasses => "hstack";

    [Parameter]
    public int? Gap { get; set; }
}
