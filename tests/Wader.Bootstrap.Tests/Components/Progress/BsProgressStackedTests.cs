using Wader.Bootstrap.Components.Progress;
using Wader.Bootstrap.Internals.Constants;

namespace Wader.Bootstrap.Tests.Components.Progress;

public class BsProgressStackedTests()
    : BsComponentTests<BsProgressStacked>("""<div class="progress-stacked {0}" {1}></div>""")
{
    [Fact]
    public void ExposesCascadingValue()
    {
        TestForCascadingValue<bool>(CascadingValueNames.PROGRESS_IS_STACKED);
    }
}
