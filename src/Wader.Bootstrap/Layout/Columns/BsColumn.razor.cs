using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.Layout.Columns;

public partial class BsColumn : BsChildContentComponent, IContainerComponent
{
    protected override string BsComponentClasses =>
        $"{ColumnOptionsBootstrapClasses()} {ColumnOffsetBootstrapClasses()} {ColumnOrder.ToBootstrapClass()}";

    public ElementReference ElementRef { get; private set; }

    [Parameter]
    public BsColumnOptions ColOption { get; set; }

    [Parameter]
    public IEnumerable<BsColumnOptions> ColOptions { get; set; } = [];

    [Parameter]
    public BsColumnOptions OffsetOption { get; set; }

    [Parameter]
    public IEnumerable<BsColumnOptions> OffsetOptionsList { get; set; } = [];

    [Parameter]
    public BsColumnOrder ColumnOrder { get; set; }

    private string ColumnOptionsBootstrapClasses()
    {
        var colOptionsList = ColOptions.ToList();
        if (colOptionsList.Count == 0)
        {
            return ColOption.ToBootstrapColClass();
        }

        var classes = colOptionsList.Select(b => b.ToBootstrapColClass());
        return string.Join(' ', classes);
    }

    private string ColumnOffsetBootstrapClasses()
    {
        var offsetOptionsList = OffsetOptionsList.ToList();
        if (offsetOptionsList.Count == 0)
        {
            return OffsetOption.ToBootstrapOffsetClass();
        }

        var classes = offsetOptionsList.Select(b => b.ToBootstrapOffsetClass());
        return string.Join(' ', classes);
    }
}
