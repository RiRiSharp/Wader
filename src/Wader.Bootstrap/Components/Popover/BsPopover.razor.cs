using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Components.Popover.Internals;

namespace Wader.Bootstrap.Components.Popover;

public partial class BsPopover : BsChildContentComponent
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
    ///     <see cref="Title" />, including event handlers, bindings, forms, and nested interactive
    ///     components, is not supported.
    /// </remarks>
    [Parameter]
    public RenderFragment? Title { get; set; }

    /// <summary>
    ///     Gets or sets the popover title content.
    /// </summary>
    /// <remarks>
    ///     This parameter accepts Razor markup for authoring convenience, but the rendered output is
    ///     converted to HTML and passed to the underlying Bootstrap popover.
    ///     Treat this content as presentational markup only. Interactive Blazor behavior inside
    ///     <see cref="Content" />, including event handlers, bindings, forms, and nested interactive
    ///     components, is not supported.
    /// </remarks>
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

    private ElementReference HostElementRef
    {
        get => Attachment ?? field;
        set;
    }

    [Inject]
    public IBsPopoverJsInterop BsPopoverJsInterop { get; set; } = null!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        var jsOptions = Options.ToPopoverJsOptions(_titleRef, _contentRef);
        await BsPopoverJsInterop.CreateOrUpdateAsync(HostElementRef, jsOptions);
    }
}
