using Wader.Bootstrap.Forms.ChecksRadios;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Forms.ChecksRadios;

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
