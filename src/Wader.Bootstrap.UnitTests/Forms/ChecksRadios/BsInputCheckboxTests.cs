using Wader.Bootstrap.Forms.ChecksRadios;

namespace Wader.Bootstrap.UnitTests.Forms.ChecksRadios;

public class BsInputCheckboxTests()
    : BsInputBaseComponentTests<BsInputCheckbox, bool>("""<input class="form-check-input {0}" {1}></label>""")
{
    protected override Dictionary<string, string> AttributesForDefaultTests => new() { ["type"] = "checkbox" };

    [Fact]
    public void InputTypeCannotBeOverriden()
    {
        TestForDisallowingOverride("type");
    }
}
