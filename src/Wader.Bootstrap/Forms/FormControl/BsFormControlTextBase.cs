using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.Forms.FormControl;

public abstract class BsFormControlTextBase<TValue> : BsInputBase<TValue>
{
    protected BsFormControlTextBase(string additionalClasses = "")
    {
        if (string.IsNullOrWhiteSpace(additionalClasses))
        {
            BsComponentClasses = null;
        }

        BsComponentClasses = additionalClasses;
    }

    [Parameter]
    public BsFormSize Size { get; set; }

    [Parameter]
    public bool ReadonlyPlaintext { get; set; }

    protected override string BsComponentClasses => $"{FormControlClass} {SizeClass} {field}";

    private string? SizeClass => Size.ToBootstrapClass();

    private string FormControlClass => ReadonlyPlaintext ? "form-control-plaintext" : "form-control";
}
