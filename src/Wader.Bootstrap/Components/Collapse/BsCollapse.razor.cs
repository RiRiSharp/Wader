using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Components.Collapse.Internals;
using Wader.Bootstrap.Internal.BaseComponents;

namespace Wader.Bootstrap.Components.Collapse;

public partial class BsCollapse : BsChildContentComponent, IAsyncDisposable
{
    internal ElementReference HtmlRef;
    protected override string? BsComponentClasses => $"collapse {ShowClass} {DirectionClass}";

    [Parameter]
    public BsCollapseDirection Direction { get; set; }

    [Parameter]
    public bool Show { get; set; }

    private string? ShowClass => Show ? "show" : null;

    [Inject]
    private IBsCollapseJsInterop CollapseJsInterop { get; set; } = null!;

    private string? DirectionClass => Direction.ToBootstrapClass();

    public async ValueTask DisposeAsync()
    {
        await Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async Task ToggleAsync()
    {
        await CollapseJsInterop.ToggleAsync(HtmlRef);
    }

    public async Task ShowAsync()
    {
        await CollapseJsInterop.ShowAsync(HtmlRef);
    }

    public async Task CollapseAsync()
    {
        await CollapseJsInterop.CollapseAsync(HtmlRef);
    }

    private async Task Dispose(bool disposing)
    {
        if (!disposing)
        {
            return;
        }

        await CollapseJsInterop.DisposeReferenceAsync(HtmlRef);
    }
}
