namespace Wader.Bootstrap.Components.Accordion;

public enum BsAccordionDisplayStyle
{
    Regular = 0,
    Flush = 1,
}

internal static class BsAccordionDisplayStyleExtensions
{
    internal static string? ToBootstrapClass(this BsAccordionDisplayStyle style)
    {
        return style switch
        {
            BsAccordionDisplayStyle.Regular => null,
            BsAccordionDisplayStyle.Flush => "accordion-flush",
            _ => throw new ArgumentOutOfRangeException(nameof(style), style, null),
        };
    }
}
