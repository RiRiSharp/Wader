using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Components.Tooltip.Internals;
using Wader.Bootstrap.Infrastructure.BaseComponents;

namespace Wader.Bootstrap.Components.Tooltip;

public partial class BsTooltip : BsChildContentComponent, IAsyncDisposable
{
    private ElementReference _titleRef;
    protected override string? BsComponentClasses => null;

    [Parameter]
    public RenderFragment? BsTooltipContent { get; set; }

    [Parameter]
    public BsTooltipOptions Options { get; set; } = new();

    /// <summary>
    ///     Overrides the host element used to initialize the Bootstrap tooltip.
    ///     If not supplied, the component's wrapper element is used.
    /// </summary>
    [Parameter]
    public ElementReference? Attachment { get; set; }

    internal ElementReference HostElementRef
    {
        get => Attachment ?? field;
        private set;
    }

    [Inject]
    public IBsTooltipJsInterop BsTooltipJsInterop { get; set; } = null!;

    public async ValueTask DisposeAsync()
    {
        await Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender)
        {
            return;
        }

        var jsOptions = Options.ToTooltipJsOptions(_titleRef);
        await BsTooltipJsInterop.CreateOrUpdateAsync(HostElementRef, jsOptions);
    }

    public async Task ToggleAsync()
    {
        await BsTooltipJsInterop.ToggleAsync(HostElementRef);
    }

    public async Task ShowAsync()
    {
        await BsTooltipJsInterop.ShowAsync(HostElementRef);
    }

    public async Task HideAsync()
    {
        await BsTooltipJsInterop.HideAsync(HostElementRef);
    }

    public async Task UpdatePositionAsync()
    {
        await BsTooltipJsInterop.UpdatePositionAsync(HostElementRef);
    }

    public async Task ToggleEnabledAsync()
    {
        await BsTooltipJsInterop.ToggleEnabledAsync(HostElementRef);
    }

    public async Task EnableAsync()
    {
        await BsTooltipJsInterop.EnableAsync(HostElementRef);
    }

    public async Task DisableAsync()
    {
        await BsTooltipJsInterop.DisableAsync(HostElementRef);
    }

    private async Task Dispose(bool disposing)
    {
        if (!disposing)
        {
            return;
        }

        await BsTooltipJsInterop.DisposeReferenceAsync(HostElementRef);
    }
}
