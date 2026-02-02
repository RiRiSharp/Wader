using Microsoft.AspNetCore.Components;
using Wader.BaseComponents;

namespace Wader.Components.Pagination;

public partial class BsPageLink : BsChildContentComponent
{
    [Parameter]
    public BsPageLinkType LinkType { get; set; }
    protected override string BsComponentClasses => "page-link";
}
