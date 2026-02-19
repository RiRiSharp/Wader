using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.Forms.FormControl;

public abstract class BsFormControlTextBase<TValue> : BsInputBase<TValue>
{
    private readonly string? _additionalClasses;

    protected BsFormControlTextBase(string additionalClasses = "")
    {
        if (string.IsNullOrWhiteSpace(additionalClasses))
        {
            _additionalClasses = null;
        }

        _additionalClasses = additionalClasses;
    }

    [Parameter]
    public BsFormSize Size { get; set; }

    [Parameter]
    public bool ReadonlyPlaintext { get; set; }

    protected override string BsComponentClasses => $"{FormControlClass} {SizeClass} {_additionalClasses}";

    private string? SizeClass => Size.ToBootstrapClass();

    private string FormControlClass => ReadonlyPlaintext ? "form-control-plaintext" : "form-control";
}
