using Wader.Bootstrap.Components.CloseButton;

namespace Wader.Bootstrap.UnitTests.Components.CloseButton;

public class BsCloseButtonTests() : BsComponentTests<BsCloseButton>("""<button class="btn-close {0}" {1}></button>""")
{
    protected override Dictionary<string, string> AttributesForDefaultTests =>
        new() { ["type"] = "button", ["aria-label"] = "Close" };

    [Fact]
    public void ButtonTypeCanBeOverriden()
    {
        TestForAllowingOverride("type");
    }

    [Fact]
    public void AriaLabelCanBeOverriden()
    {
        TestForAllowingOverride("aria-label");
    }
}
