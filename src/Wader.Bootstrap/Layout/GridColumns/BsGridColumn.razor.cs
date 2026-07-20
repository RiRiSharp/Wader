using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.Layout.GridColumns;

public partial class BsGridColumn : BsChildContentComponent
{
    protected override string? BsComponentClasses =>
        $"{ColumnOptionsBootstrapClasses()} {StartOption.ToBootstrapClass()}";

    [Parameter]
    public BsGridColumnOptions GridOption { get; set; }

    [Parameter]
    public IEnumerable<BsGridColumnOptions> GridOptions { get; set; } = [];

    [Parameter]
    public BsGridStartOptions StartOption { get; set; }

    private string ColumnOptionsBootstrapClasses()
    {
        var gridOptionsList = GridOptions.ToList();
        if (gridOptionsList.Count == 0)
        {
            return GridOption.ToBootstrapClass();
        }

        var classes = GridOptions.Select(b => b.ToBootstrapClass());

        return string.Join(separator: ' ', classes);
    }
}
