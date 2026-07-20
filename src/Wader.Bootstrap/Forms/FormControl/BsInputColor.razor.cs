using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace Wader.Bootstrap.Forms.FormControl;

/// <summary>
///     Input element for colors
/// </summary>
/// <remark>
///     Solves https://stackoverflow.com/questions/64052566/is-there-any-blazor-timepicker-and-colorpicker
/// </remark>
public partial class BsInputColor : BsInputBase<Color>
{
    protected override string? BsComponentClasses => "form-control form-control-color";

    protected override bool TryParseValueFromString(
        string? value,
        out Color result,
        [NotNullWhen(false)] out string? validationErrorMessage
    )
    {
        if (value is null)
        {
            validationErrorMessage = "Provided value was null";
            result = default;

            return false;
        }

        result = ColorTranslator.FromHtml(value);
        validationErrorMessage = null;

        return true;
    }

    protected override string FormatValueAsString(Color value)
    {
        return ColorTranslator.ToHtml(value);
    }
}
