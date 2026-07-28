using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;

namespace Wader.Bootstrap.Components.Placeholders;

public partial class BsPlaceholder : BsChildContentComponent
{
    protected override string? BsComponentClasses => $"placeholder {SizeClass}";

    [Parameter]
    public BsPlaceholderSize Size { get; set; } = BsPlaceholderSize.Regular;

    private string? SizeClass => Size.ToBootstrapClass();
}
