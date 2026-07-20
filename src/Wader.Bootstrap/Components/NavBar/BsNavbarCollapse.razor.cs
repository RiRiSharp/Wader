using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Components.Collapse.Internals;

namespace Wader.Bootstrap.Components.NavBar;

public partial class BsNavbarCollapse : BsChildContentComponent, IAsyncDisposable
{
    internal ElementReference HtmlRef;
    protected override string? BsComponentClasses => "collapse navbar-collapse";

    [Inject]
    private IBsCollapseJsInterop CollapseJsInterop { get; set; } = null!;

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
