using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Components.Accordion.Internals;
using Wader.Bootstrap.Internal.BaseComponents;
using Wader.Bootstrap.Internal.Constants;
using Wader.Bootstrap.Internal.Exceptions;

namespace Wader.Bootstrap.Components.Accordion;

public partial class BsAccordionButton : BsChildContentComponent, IHasCollapseState
{
    internal ElementReference HtmlRef;

    /// <summary>
    ///     Holds a reference to this component for JS interop. Initialized after first render.
    /// </summary>
    private DotNetObjectReference<BsAccordionButton> _dotNetRef = null!;

    private bool _initialCollapse;
    protected override string? BsComponentClasses => $"accordion-button {GetInitialCollapsedClass()}";

    [CascadingParameter(Name = CascadingValueNames.ACCORDION_ITEM_CONTEXT)]
    internal IBsAccordionItemContext? AccordionItemContext { get; set; }

    [Inject]
    private IBsAccordionJsInterop AccordionJsInterop { get; set; } = null!;

    [JSInvokable]
    public void UpdateCollapseState(bool isCollapsed)
    {
        StateHasChanged();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _initialCollapse = AccordionItemContext!.Collapsed;
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        if (AccordionItemContext is null)
        {
            throw BsComponentUsageException.MustBeChildOf<BsAccordionButton, BsAccordionItem>();
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender)
        {
            return;
        }

        _dotNetRef = DotNetObjectReference.Create(this);
        await AccordionJsInterop.RegisterCollapseCallbackAsync(HtmlRef, _dotNetRef);
    }

    private async Task ToggleAsync()
    {
        await AccordionItemContext!.ToggleAsync(); // Called after initialization
    }

    private string GetInitialCollapsedClass()
    {
        return _initialCollapse ? "collapsed" : "";
    }
}
