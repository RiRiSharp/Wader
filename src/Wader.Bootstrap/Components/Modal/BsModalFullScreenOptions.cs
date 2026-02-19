namespace Wader.Bootstrap.Components.Modal;

public enum BsModalFullScreenOptions
{
    Disable = 0,
    Enable = 1,
}

internal static class BsModalFullScreenOptionsExtensions
{
    internal static string? ToBootstrapClass(this BsModalFullScreenOptions options)
    {
        return options switch
        {
            BsModalFullScreenOptions.Disable => null,
            BsModalFullScreenOptions.Enable => "modal-fullscreen",
            _ => throw new ArgumentOutOfRangeException(nameof(options), options, null),
        };
    }
}
