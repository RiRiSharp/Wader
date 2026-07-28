using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Components.Accordion.Internals;
using Wader.Bootstrap.Internal.BaseComponents;
using Wader.Bootstrap.Internal.Constants;
using Wader.Bootstrap.Internal.Exceptions;

namespace Wader.Bootstrap.Components.Accordion;

public partial class BsAccordionCollapse : BsChildContentComponent, IHasCollapseState
{
    internal ElementReference HtmlRef;
    private DotNetObjectReference<BsAccordionCollapse> _dotNetRef = null!;
    private bool _initialCollapse;

    protected override string? BsComponentClasses => $"accordion-collapse collapse {GetInitialCollapsedClass()}";
    public bool Collapsed { get; set; } = true;

    [CascadingParameter(Name = CascadingValueNames.ACCORDION_ITEM_CONTEXT)]
    public IBsAccordionItemContext? AccordionItemContext { get; set; }

    [Inject]
    private IBsAccordionJsInterop AccordionJsInterop { get; set; } = null!;

    [JSInvokable]
    public void UpdateCollapseState(bool isCollapsed)
    {
        Collapsed = isCollapsed;
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
            throw BsComponentUsageException.MustBeChildOf<BsAccordionCollapse, BsAccordionItem>();
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

    private string GetInitialCollapsedClass()
    {
        return _initialCollapse ? "" : "show";
    }
}
