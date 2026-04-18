namespace Wader.Bootstrap.Components.NavBar;

public enum BsNavItemOptions
{
    NoDropdown = 0,
    WithDropdown = 1,
}

internal static class DropdownOptionsExtensions
{
    internal static string? ToNavItemBootstrapClass(this BsNavItemOptions options)
    {
        return options switch
        {
            BsNavItemOptions.NoDropdown => null,
            BsNavItemOptions.WithDropdown => "dropdown",
            _ => throw new ArgumentOutOfRangeException(nameof(options), options, null),
        };
    }

    internal static string? ToNavLinkBootstrapClass(this BsNavItemOptions options)
    {
        return options switch
        {
            BsNavItemOptions.NoDropdown => null,
            BsNavItemOptions.WithDropdown => "dropdown-toggle",
            _ => throw new ArgumentOutOfRangeException(nameof(options), options, null),
        };
    }
}
