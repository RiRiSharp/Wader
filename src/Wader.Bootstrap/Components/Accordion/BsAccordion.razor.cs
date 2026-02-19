using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Components.Accordion.Internals;

namespace Wader.Bootstrap.Components.Accordion;

public partial class BsAccordion : BsChildContentComponent
{
    internal ElementReference HtmlRef;
    protected override string BsComponentClasses => $"accordion {DisplayStyle.ToBootstrapClass()}";
    public IBsAccordionContext AccordionContext { get; private set; } = null!;

    [Parameter]
    public bool AlwaysOpen { get; set; }

    [Parameter]
    public BsAccordionDisplayStyle DisplayStyle { get; set; }

    [Inject]
    private IBsAccordionJsFunctions AccordionJsFunctions { get; set; } = null!;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        AccordionContext = new BsAccordionContext { AlwaysOpen = AlwaysOpen };
    }

    public async Task CollapseAllAsync()
    {
        await AccordionJsFunctions.CollapseAllAsync(HtmlRef);
    }

    public async Task ShowAllAsync()
    {
        await AccordionJsFunctions.ShowAllAsync(HtmlRef);
    }

    public async Task CollapseAllButOneAsync(BsAccordionItem accordionItem)
    {
        await AccordionJsFunctions.CollapseAllButOneAsync(HtmlRef, accordionItem.HtmlRef);
    }
}
