using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.Components.Pagination;

public partial class BsPageItem : BsChildContentComponent
{
    protected override string BsComponentClasses => $"page-item {DisabledClass} {ActiveClass}";

    [Parameter]
    public bool Disabled { get; set; }
    private string? DisabledClass => Disabled ? "disabled" : null;

    [Parameter]
    public bool Active { get; set; }
    private string? ActiveClass => Active ? "active" : null;
}
