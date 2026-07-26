using Wader.Bootstrap.Components.Carousel;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Carousel;

public class BsCarouselControlNextIconTests()
    : BsComponentTests<BsCarouselControlNextIcon>("""<span class="carousel-control-next-icon {0}" {1}></span>""")
{
    protected override Dictionary<string, string> AttributesForDefaultTests => new() { ["aria-hidden"] = "true" };

    [Fact]
    public void AriaHiddenCanBeOverriden()
    {
        TestForAllowingOverride("aria-hidden");
    }
}
