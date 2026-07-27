using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Infrastructure.BaseComponents;

namespace Wader.Bootstrap.Components.Spinners;

public partial class BsSpinner : BsChildContentComponent
{
    protected override string? BsComponentClasses => VariantClass;

    [Parameter]
    public BsSpinnerVariant Variant { get; set; }

    private string VariantClass => Variant.ToBootstrapClass(Size);

    [Parameter]
    public BsSpinnerSize Size { get; set; }
}
