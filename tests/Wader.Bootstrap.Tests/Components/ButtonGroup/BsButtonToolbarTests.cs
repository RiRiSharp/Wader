using Wader.Bootstrap.Components.ButtonGroup;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.ButtonGroup;

public class BsButtonToolbarTests() : BsComponentTests<BsButtonToolbar>("""<div class="btn-toolbar {0}" {1}></div>""")
{
    protected override Dictionary<string, string> AttributesForDefaultTests => new() { ["role"] = "toolbar" };

    [Fact]
    public void ToolbarRoleCanBeOverriden()
    {
        TestForAllowingOverride("role");
    }
}
