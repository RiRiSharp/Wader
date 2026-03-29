using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Components.Popover.Internals;

namespace Wader.Bootstrap.Components.Popover;

public partial class BsPopover : BsChildContentComponent
{
    private ElementReference? _contentRef;

    private string? _lastSignature;
    private ElementReference? _titleRef;
    private ElementReference _wrapperHostElementRef;
    protected override string BsComponentClasses => "d-inline-block";

    [Parameter]
    public RenderFragment? Title { get; set; }

    [Parameter]
    public RenderFragment? Content { get; set; }

    [Parameter]
    public BsPopoverOptions Options { get; set; } = new();

    /// <summary>
    ///     Overrides the host element used to initialize the Bootstrap popover.
    ///     If not supplied, the component's wrapper element is used.
    /// </summary>
    [Parameter]
    public ElementReference? Attachment { get; set; }

    private ElementReference HostElementRef => Attachment ?? _wrapperHostElementRef;

    [Inject]
    public IBsPopoverJsInterop BsPopoverJsInterop { get; set; } = null!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        var signature = BuildSignature();
        if (_lastSignature == signature)
        {
            return;
        }

        var jsOptions = Options.ToPopoverJsOptions(_titleRef, _contentRef);
        await BsPopoverJsInterop.CreateOrUpdateAsync(HostElementRef, jsOptions);
    }

    private string? BuildSignature()
    {
        return Title?.GetHashCode() + Options.ToString();
    }
}
