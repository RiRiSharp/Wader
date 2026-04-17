using Wader.Bootstrap.Forms.Range;

namespace Wader.Bootstrap.Tests.Forms.Range;

public class BsFormRangeInputTests()
    : BsInputBaseComponentTests<BsFormRangeInput<int>, int>("""<input class="form-range {0}" {1}>""")
{
    protected override Dictionary<string, string> AttributesForDefaultTests =>
        new() { ["type"] = "range", ["value"] = "0" };

    [Fact]
    public void InputTypeCannotBeOverriden()
    {
        TestForDisallowingOverride("type");
    }
}
