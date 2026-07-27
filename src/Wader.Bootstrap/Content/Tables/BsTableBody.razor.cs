using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Infrastructure.BaseComponents;

namespace Wader.Bootstrap.Content.Tables;

public partial class BsTableBody : BsChildContentComponent
{
    protected override string? BsComponentClasses => TableGroupDivider ? "table-group-divider" : "";

    [Parameter]
    public bool TableGroupDivider { get; set; }
}
