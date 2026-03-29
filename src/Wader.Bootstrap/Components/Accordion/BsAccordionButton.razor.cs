using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Components.Accordion.Internals;
using Wader.Bootstrap.Internals.Exceptions;

namespace Wader.Bootstrap.Components.Accordion;

public partial class BsAccordionButton : BsChildContentComponent, IHasCollapseState
{
    /// <summary>
    ///     Holds a reference to this component for JS interop. Initialized after first render.
    /// </summary>
    private DotNetObjectReference<BsAccordionButton> _dotNetRef = null!;

    private bool _initialCollapse;
    internal ElementReference HtmlRef;
    protected override string BsComponentClasses => $"accordion-button {GetInitialCollapsedClass()}";

    [CascadingParameter]
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
            throw new BsCascadingParameterNotProvidedException(typeof(IBsAccordionItemContext));
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
