using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;

namespace Wader.Bootstrap.Components.Pagination;

public partial class BsPagination : BsChildContentComponent
{
    protected override string? BsComponentClasses => $"pagination {SizeClass}";

    [Parameter]
    public BsPaginationSize Size { get; set; }

    private string? SizeClass => Size.ToBootstrapClass();
}
