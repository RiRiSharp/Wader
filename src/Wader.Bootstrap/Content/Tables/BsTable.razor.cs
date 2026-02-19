using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.Content.Tables;

public partial class BsTable : BsChildContentComponent
{
    protected override string BsComponentClasses => $"table {Options.ToBootstrapTableClass()}";

    [Parameter]
    public BsTableOptions Options { get; set; }
}
