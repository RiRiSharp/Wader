namespace Wader.Bootstrap.Components.Modal;

public enum BsModalScrollOptions
{
    WholePage = 0,
    DialogOnly = 1,
}

internal static class BsModalScrollOptionsExtensions
{
    internal static string? ToBootstrapClass(this BsModalScrollOptions options)
    {
        return options switch
        {
            BsModalScrollOptions.WholePage => null,
            BsModalScrollOptions.DialogOnly => "modal-dialog-scrollable",
            _ => throw new ArgumentOutOfRangeException(nameof(options), options, null),
        };
    }
}
