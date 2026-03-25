using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Components.Accordion.Internals;
using Wader.Bootstrap.Internals.Exceptions;

namespace Wader.Bootstrap.Components.Accordion;

public partial class BsAccordionItem : BsChildContentComponent, IAsyncDisposable
{
    internal ElementReference HtmlRef;
    protected override string BsComponentClasses => "accordion-item";
    public IBsAccordionItemContext AccordionItemContext { get; private set; } = null!;

    [Parameter]
    public bool InitialCollapsed { get; set; } = true;

    [CascadingParameter]
    private IBsAccordionContext? AccordionContext { get; set; }

    [Inject]
    private IBsAccordionJsFunctions AccordionJsFunctions { get; set; } = null!;

    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true);
        GC.SuppressFinalize(this);
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        if (AccordionContext is null)
        {
            throw new BsCascadingParameterNotProvidedException(typeof(IBsAccordionContext));
        }

        AccordionItemContext = new BsAccordionItemContext(this);
    }

    public async Task ToggleAsync()
    {
        await AccordionJsFunctions.ToggleAsync(HtmlRef, AccordionContext!.AlwaysOpen);
    }

    public async Task ShowAsync()
    {
        await AccordionJsFunctions.ShowAsync(HtmlRef, AccordionContext!.AlwaysOpen);
    }

    public async Task CollapseAsync()
    {
        await AccordionJsFunctions.CollapseAsync(HtmlRef);
    }

    private async ValueTask DisposeAsync(bool disposing)
    {
        if (!disposing)
        {
            return;
        }

        await AccordionJsFunctions.DisposeReferenceAsync(HtmlRef);
    }
}
