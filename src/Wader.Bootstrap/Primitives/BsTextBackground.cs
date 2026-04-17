namespace Wader.Bootstrap.Primitives;

public enum BsTextBackground
{
    Default = 0,
    Success = 1,
    Info = 2,
    Warning = 3,
    Danger = 4,
}

internal static class BsProgressBarBackgroundExtensions
{
    internal static string? ToBootstrapClass(this BsTextBackground background)
    {
        return background switch
        {
            BsTextBackground.Default => null,
            BsTextBackground.Success => "bg-success",
            BsTextBackground.Info => "bg-info",
            BsTextBackground.Warning => "bg-warning",
            BsTextBackground.Danger => "bg-danger",
            _ => throw new ArgumentOutOfRangeException(nameof(background), background, null),
        };
    }
}
