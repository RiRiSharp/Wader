namespace Wader.Bootstrap.Components.Placeholders;

public enum BsPlaceholderAnimationType
{
    Glow = 0,
    Wave = 1,
}

public static class BsPlaceholderAnimationTypeExtensions
{
    public static string ToBootstrapClass(this BsPlaceholderAnimationType type)
    {
        return type switch
        {
            BsPlaceholderAnimationType.Glow => "placeholder-glow",
            BsPlaceholderAnimationType.Wave => "placeholder-wave",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null),
        };
    }
}
