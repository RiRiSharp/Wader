using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Infrastructure.BaseComponents;

namespace Wader.Bootstrap.Layout.Rows;

public partial class BsRow : BsChildContentComponent
{
    protected override string? BsComponentClasses => $"row {ColumnsInRow.ToBootstrapClass()}";

    [Parameter]
    public BsColumnsInRow ColumnsInRow { get; set; }
}
