namespace Wader.Bootstrap.Components.Card;

public enum BsCardImagePosition
{
    Top = 0,
    Bottom = 1,
    Overlay = 2,
}

internal static class BsCardImagePositionExtensions
{
    internal static string ToBootstrapClass(this BsCardImagePosition imagePosition)
    {
        return imagePosition switch
        {
            BsCardImagePosition.Top => "card-img-top",
            BsCardImagePosition.Bottom => "card-img-bottom",
            BsCardImagePosition.Overlay => "card-img",
            _ => throw new ArgumentOutOfRangeException(nameof(imagePosition), imagePosition, null),
        };
    }
}
