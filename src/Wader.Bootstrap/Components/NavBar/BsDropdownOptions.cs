namespace Wader.Bootstrap.Components.NavBar;

public enum BsDropdownOptions
{
    NoDropdown = 0,
    WithDropdown = 1,
}

internal static class DropdownOptionsExtensions
{
    internal static string? ToNavItemBootstrapClass(this BsDropdownOptions options)
    {
        return options switch
        {
            BsDropdownOptions.NoDropdown => null,
            BsDropdownOptions.WithDropdown => "dropdown",
            _ => throw new ArgumentOutOfRangeException(nameof(options), options, null),
        };
    }

    internal static string? ToNavLinkBootstrapClass(this BsDropdownOptions options)
    {
        return options switch
        {
            BsDropdownOptions.NoDropdown => null,
            BsDropdownOptions.WithDropdown => "dropdown-toggle",
            _ => throw new ArgumentOutOfRangeException(nameof(options), options, null),
        };
    }
}
