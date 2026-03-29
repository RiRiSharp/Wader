namespace Wader.Bootstrap.Components.Popover;

[Flags]
public enum BsPopoverTrigger
{
    None = 0,
    Click = 1,
    Hover = 1 << 1,
    Focus = 1 << 2,
    Manual = 1 << 3,
}

public static class BsPopoverTriggerExtensions
{
    public static string ToPopperTriggerString(this BsPopoverTrigger trigger)
    {
        if (trigger == BsPopoverTrigger.None)
        {
            throw new InvalidOperationException("'None' cannot be converted to a Bootstrap trigger.");
        }

        if (trigger.HasFlag(BsPopoverTrigger.Manual))
        {
            return (trigger & ~BsPopoverTrigger.Manual) != 0
                ? throw new InvalidOperationException("'Manual' cannot be combined with other triggers.")
                : "manual";
        }

        var parts = new List<string>();

        if (trigger.HasFlag(BsPopoverTrigger.Click))
        {
            parts.Add("click");
        }

        if (trigger.HasFlag(BsPopoverTrigger.Hover))
        {
            parts.Add("hover");
        }

        if (trigger.HasFlag(BsPopoverTrigger.Focus))
        {
            parts.Add("focus");
        }

        return string.Join(" ", parts);
    }
}
