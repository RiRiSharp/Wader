using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Wader.BaseComponents;
using Wader.Components.Buttons;
using Wader.Internals;
using Wader.Internals.Exceptions;

namespace Wader.Components.Dropdown;

public partial class BsDropdownToggle : BsChildContentComponent
{
    protected override string BsComponentClasses => $"dropdown-toggle {ModeClass}";

    [Inject]
    private ILogger<BsDropdownToggle> Logger { get; set; } = null!;

    [CascadingParameter]
    public BsDropdownMode? Mode { get; set; }

    private string ModeClass => Mode?.ToBootstrapButtonClass() ?? "";

    [Parameter]
    public BsButtonSize Size { get; set; }

    [Parameter]
    public BsButtonVariant? Variant { get; set; }

    [Parameter]
    public BsButtonOutlineVariant? OutlineVariant { get; set; }

    protected override void OnParametersSet()
    {
        if (Variant is null && OutlineVariant is null)
        {
            throw new BsMissingParameterException(
                $"Parameters {nameof(Variant)} and  {nameof(OutlineVariant)} cannot both be null"
            );
        }

        if (Variant is not null && OutlineVariant is not null)
        {
            BsLog.BothVariantsHaveBeenSet(Logger, nameof(Variant), nameof(OutlineVariant));
        }

        base.OnParametersSet();
    }
}
