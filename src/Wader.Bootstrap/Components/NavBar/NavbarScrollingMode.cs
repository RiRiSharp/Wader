namespace Wader.Bootstrap.Components.NavBar;

public enum NavbarScrollingMode
{
    Regular = 0,
    EnableVerticalScrolling = 1,
}

internal static class NavbarScrollingModeExtensions
{
    internal static string? ToBootstrapClass(this NavbarScrollingMode mode)
    {
        return mode switch
        {
            NavbarScrollingMode.Regular => null,
            NavbarScrollingMode.EnableVerticalScrolling => "navbar-nav-scroll",
            _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, null),
        };
    }
}
