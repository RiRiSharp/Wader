namespace Wader.Bootstrap.Utilities.Flex;

public enum BsJustify
{
    Start = 0,
    End = 1,
    Center = 2,
    Between = 3,
    Around = 4,
    Evenly = 5,
}

internal static class JustificationExtensions
{
    internal static string ToBootstrapClass(this BsJustify justify)
    {
        return justify switch
        {
            BsJustify.Start => "justify-content-start",
            BsJustify.End => "justify-content-end",
            BsJustify.Center => "justify-content-center",
            BsJustify.Between => "justify-content-between",
            BsJustify.Around => "justify-content-around",
            BsJustify.Evenly => "justify-content-evenly",
            _ => throw new ArgumentOutOfRangeException(nameof(justify), justify, null),
        };
    }
}
