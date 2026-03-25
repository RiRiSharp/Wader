using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Components.Collapse.Internals;

namespace Wader.Bootstrap.Components.NavBar;

public partial class BsNavbarCollapse : BsChildContentComponent, IAsyncDisposable
{
    internal ElementReference HtmlRef;
    protected override string BsComponentClasses => "collapse navbar-collapse";

    [Inject]
    private IBsCollapseJsFunctions CollapseJsFunctions { get; set; } = null!;

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

        await CollapseJsFunctions.DisposeReferenceAsync(HtmlRef);
    }
}
