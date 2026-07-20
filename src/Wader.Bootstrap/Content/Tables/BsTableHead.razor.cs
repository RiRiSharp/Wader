using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.Content.Tables;

public partial class BsTableHead : BsChildContentComponent
{
    protected override string? BsComponentClasses => Options.ToBootstrapTableHeadClass();

    [Parameter]
    public BsTableOptions Options { get; set; }
}
