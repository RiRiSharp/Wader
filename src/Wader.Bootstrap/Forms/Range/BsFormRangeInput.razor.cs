using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Wader.Bootstrap.Forms.Range;

public partial class BsFormRangeInput<TValue> : BsInputBase<TValue>
    where TValue : INumber<TValue>
{
    protected override string BsComponentClasses => "form-range";

    protected override bool TryParseValueFromString(
        string? value,
        [MaybeNullWhen(false)] out TValue result,
        [NotNullWhen(false)] out string? validationErrorMessage
    )
    {
        if (TValue.TryParse(value, null, out result))
        {
            validationErrorMessage = null;
            return true;
        }

        validationErrorMessage = $"The value '{value}' is not valid for type {typeof(TValue).Name}.";
        return false;
    }
}
