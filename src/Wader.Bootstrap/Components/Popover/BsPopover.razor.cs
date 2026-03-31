using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Components.Popover.Internals;

namespace Wader.Bootstrap.Components.Popover;

public partial class BsPopover : BsChildContentComponent, IAsyncDisposable
{
    private ElementReference? _contentRef;

    private ElementReference? _titleRef;

    protected override string BsComponentClasses => "d-inline-block";

    /// <summary>
    ///     Gets or sets the popover title content.
    /// </summary>
    /// <remarks>
    ///     This parameter accepts Razor markup for authoring convenience, but the rendered output is
    ///     converted to HTML and passed to the underlying Bootstrap popover.
    ///     Treat this content as presentational markup only. Interactive Blazor behavior inside
    ///     <see cref="BsPopoverTitle" />, including event handlers, bindings, forms, and nested interactive
    ///     components, is not supported.
    /// </remarks>
    [Parameter]
    public RenderFragment? BsPopoverTitle { get; set; }

    /// <summary>
    ///     Gets or sets the popover title content.
    /// </summary>
    /// <remarks>
    ///     This parameter accepts Razor markup for authoring convenience, but the rendered output is
    ///     converted to HTML and passed to the underlying Bootstrap popover.
    ///     Treat this content as presentational markup only. Interactive Blazor behavior inside
    ///     <see cref="BsPopoverContent" />, including event handlers, bindings, forms, and nested interactive
    ///     components, is not supported.
    /// </remarks>
    [Parameter, EditorRequired]
    public RenderFragment? BsPopoverContent { get; set; }

    [Parameter]
    public BsPopoverOptions Options { get; set; } = new();

    /// <summary>
    ///     Overrides the host element used to initialize the Bootstrap popover.
    ///     If not supplied, the component's wrapper element is used.
    /// </summary>
    [Parameter]
    public ElementReference? Attachment { get; set; }

    private ElementReference HostElementRef
    {
        get => Attachment ?? field;
        set;
    }

    [Inject]
    public IBsPopoverJsInterop BsPopoverJsInterop { get; set; } = null!;

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

        var jsOptions = Options.ToPopoverJsOptions(_titleRef, _contentRef);
        await BsPopoverJsInterop.CreateOrUpdateAsync(HostElementRef, jsOptions);
    }

    public async Task ToggleAsync()
    {
        await BsPopoverJsInterop.ToggleAsync(HostElementRef);
    }

    public async Task ShowAsync()
    {
        await BsPopoverJsInterop.ShowAsync(HostElementRef);
    }

    public async Task HideAsync()
    {
        await BsPopoverJsInterop.HideAsync(HostElementRef);
    }

    public async Task UpdatePositionAsync()
    {
        await BsPopoverJsInterop.UpdatePositionAsync(HostElementRef);
    }

    private async Task Dispose(bool disposing)
    {
        if (!disposing)
        {
            return;
        }

        await BsPopoverJsInterop.DisposeReferenceAsync(HostElementRef);
    }
}
