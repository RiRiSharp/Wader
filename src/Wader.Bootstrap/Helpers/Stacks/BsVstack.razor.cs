using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;

namespace Wader.Bootstrap.Helpers.Stacks;

public partial class BsVstack : BsChildContentComponent
{
    protected override string BsComponentClasses => "vstack";

    [Parameter]
    public int? Gap { get; set; }
}
