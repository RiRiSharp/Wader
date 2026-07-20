using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Components.Buttons;
using Wader.Bootstrap.Infrastructure.Constants;
using Wader.Bootstrap.Infrastructure.Exceptions;
using BsLog = Wader.Bootstrap.Infrastructure.BsLog;

namespace Wader.Bootstrap.Components.Dropdown;

public partial class BsDropdownToggle : BsChildContentComponent
{
    protected override string? BsComponentClasses => $"dropdown-toggle {ModeClass}";

    [Inject]
    private ILogger<BsDropdownToggle> Logger { get; set; } = null!;

    [CascadingParameter(Name = CascadingValueNames.DROPDOWN_MODE)]
    public BsDropdownMode Mode { get; set; } = BsDropdownMode.Regular;

    private string ModeClass => Mode.ToBootstrapButtonClass() ?? "";

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
