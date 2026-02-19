using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.Components.Breadcrumb;

public partial class BsBreadcrumbItem : BsChildContentComponent
{
    protected override string BsComponentClasses => $"breadcrumb-item {ActiveClass}";

    [Parameter]
    public bool Active { get; set; }

    private string? ActiveClass => Active ? "active" : null;
}
