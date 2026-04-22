using NSubstitute;
using Wader.Bootstrap.Components.Carousel;
using Wader.Bootstrap.Components.Carousel.Internals;
using Wader.Bootstrap.Internals.Constants;

namespace Wader.Bootstrap.Tests.Components.Carousel;

public class BsCarouselControlPrevTests()
    : BsComponentTests<BsCarouselControlPrev>("""<button class="carousel-control-prev {0}" {1}></button>""")
{
    protected override Dictionary<string, string> AttributesForDefaultTests => new() { ["type"] = "button" };
    private readonly IBsCarouselContext _carouselContextMock = Substitute.For<IBsCarouselContext>();

    protected override void BindParameters(ComponentParameterCollectionBuilder<BsCarouselControlPrev> parameterBuilder)
    {
        base.BindParameters(parameterBuilder);
        _ = parameterBuilder.AddCascadingValue(CascadingValueNames.CAROUSEL_CONTEXT, _carouselContextMock);
    }

    [Fact]
    public void TypeCanBeOverriden()
    {
        TestForAllowingOverride("type");
    }
}
