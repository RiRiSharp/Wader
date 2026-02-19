using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Components.Collapse.Internals;

namespace Wader.Bootstrap.Components.Collapse;

public partial class BsCollapse : BsChildContentComponent, IAsyncDisposable
{
    internal ElementReference HtmlRef;
    protected override string BsComponentClasses => $"collapse {ShowClass} {DirectionClass}";

    [Parameter]
    public BsCollapseDirection Direction { get; set; }

    [Parameter]
    public bool Show { get; set; }

    private string? ShowClass => Show ? "show" : null;

    [Inject]
    private IBsCollapseJsFunctions CollapseJsFunctions { get; set; } = null!;

    private string? DirectionClass => Direction.ToBootstrapClass();

    public async ValueTask DisposeAsync()
    {
        await Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async Task ToggleAsync()
    {
        await CollapseJsFunctions.ToggleAsync(HtmlRef);
    }

    public async Task ShowAsync()
    {
        await CollapseJsFunctions.ShowAsync(HtmlRef);
    }

    public async Task CollapseAsync()
    {
        await CollapseJsFunctions.CollapseAsync(HtmlRef);
    }

    private async Task Dispose(bool disposing)
    {
        if (!disposing)
        {
            return;
        }

        await CollapseJsFunctions.DisposeAsync(HtmlRef);
    }
}
