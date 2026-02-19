using System.Diagnostics.CodeAnalysis;

namespace Wader.Bootstrap.Forms.FormControl;

public partial class BsInputText : BsFormControlTextBase<string?>
{
    protected override bool TryParseValueFromString(
        string? value,
        out string? result,
        [NotNullWhen(false)] out string? validationErrorMessage
    )
    {
        result = value;
        validationErrorMessage = null;
        return true;
    }
}
