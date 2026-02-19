namespace Wader.Bootstrap.Components.Modal;

public enum BsModalPosition
{
    Top = 0,
    VerticallyCentered = 1,
}

internal static class BsModalVerticalPositionExtensions
{
    internal static string? ToBootstrapClass(this BsModalPosition position)
    {
        return position switch
        {
            BsModalPosition.Top => null,
            BsModalPosition.VerticallyCentered => "modal-dialog-centered",
            _ => throw new ArgumentOutOfRangeException(nameof(position), position, null),
        };
    }
}
