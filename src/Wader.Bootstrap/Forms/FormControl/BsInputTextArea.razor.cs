using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.Forms.FormControl;

public partial class BsInputTextArea : BsFormControlTextBase<string?>
{
    [Parameter]
    public string? TextInArea { get; set; }

    protected override bool TryParseValueFromString(
        string? value,
        [MaybeNullWhen(false)] out string? result,
        [NotNullWhen(false)] out string? validationErrorMessage
    )
    {
        result = value;
        validationErrorMessage = null;
        return true;
    }
}
