using Wader.Bootstrap.Components.Carousel;

namespace Wader.Bootstrap.UnitTests.Components.Carousel;

public class BsCarouselControlPrevIconTests()
    : BsComponentTests<BsCarouselControlPrevIcon>("""<span class="carousel-control-prev-icon {0}" {1}></span>""")
{
    protected override Dictionary<string, string> AttributesForDefaultTests => new() { ["aria-hidden"] = "true" };

    [Fact]
    public void AriaHiddenCanBeOverriden()
    {
        TestForAllowingOverride("aria-hidden");
    }
}
