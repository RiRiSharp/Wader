using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;

namespace Wader.Bootstrap.Components.Pagination;

public partial class BsPageLink : BsChildContentComponent
{
    protected override string? BsComponentClasses => "page-link";

    [Parameter]
    public BsPageLinkType LinkType { get; set; }
}
