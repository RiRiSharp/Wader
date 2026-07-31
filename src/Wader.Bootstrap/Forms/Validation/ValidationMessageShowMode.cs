namespace Wader.Bootstrap.Forms.Validation;

[Flags]
public enum ValidationMessageShowMode
{
    Never = 0,
    WhenTouched = 1,
    WhenModified = 1 << 1,
    WhenTouchedOrModified = WhenTouched | WhenModified,
}
