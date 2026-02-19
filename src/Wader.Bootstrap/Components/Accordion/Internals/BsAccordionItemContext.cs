namespace Wader.Bootstrap.Components.Accordion.Internals;

internal class BsAccordionItemContext(BsAccordionItem accordionItem) : IBsAccordionItemContext
{
    public bool Collapsed => accordionItem.InitialCollapsed;

    public async Task ToggleAsync()
    {
        await accordionItem.ToggleAsync();
    }
}
