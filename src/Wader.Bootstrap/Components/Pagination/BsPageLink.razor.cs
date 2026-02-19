using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.Components.Pagination;

public partial class BsPageLink : BsChildContentComponent
{
    [Parameter]
    public BsPageLinkType LinkType { get; set; }
    protected override string BsComponentClasses => "page-link";
}
