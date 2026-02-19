namespace Wader.Bootstrap.Components.Dropdown;

public enum BsDropdownMode
{
    Regular = 0,
    Split = 1,
}

internal static class BsDropdownModeExtensions
{
    internal static string? ToBootstrapDropdownClass(this BsDropdownMode mode)
    {
        return mode switch
        {
            BsDropdownMode.Regular => null,
            BsDropdownMode.Split => "btn-group",
            _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, null),
        };
    }

    internal static string? ToBootstrapButtonClass(this BsDropdownMode mode)
    {
        return mode switch
        {
            BsDropdownMode.Regular => null,
            BsDropdownMode.Split => "dropdown-toggle-split",
            _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, null),
        };
    }
}
