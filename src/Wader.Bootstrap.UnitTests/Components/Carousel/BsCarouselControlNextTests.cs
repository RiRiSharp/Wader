using NSubstitute;
using Wader.Bootstrap.Components.Carousel;
using Wader.Bootstrap.Components.Carousel.Internals;

namespace Wader.Bootstrap.UnitTests.Components.Carousel;

public class BsCarouselControlNextTests()
    : BsComponentTests<BsCarouselControlNext>("""<button class="carousel-control-next {0}" {1}></button>""")
{
    protected override Dictionary<string, string> AttributesForDefaultTests => new() { ["type"] = "button" };
    private readonly IBsCarouselContext _carouselContextMock = Substitute.For<IBsCarouselContext>();

    protected override void BindParameters(ComponentParameterCollectionBuilder<BsCarouselControlNext> parameterBuilder)
    {
        base.BindParameters(parameterBuilder);
        _ = parameterBuilder.AddCascadingValue(_carouselContextMock);
    }

    [Fact]
    public void TypeCanBeOverriden()
    {
        TestForAllowingOverride("type");
    }
}
