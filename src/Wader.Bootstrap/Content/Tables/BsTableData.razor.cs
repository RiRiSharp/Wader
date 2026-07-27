using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Infrastructure.BaseComponents;

namespace Wader.Bootstrap.Content.Tables;

public partial class BsTableData : BsChildContentComponent
{
    protected override string? BsComponentClasses => Options.ToBootstrapRowOrDataClass();

    [Parameter]
    public BsTableOptions Options { get; set; }
}
