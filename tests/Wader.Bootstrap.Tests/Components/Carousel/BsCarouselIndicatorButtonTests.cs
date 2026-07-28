using System.Globalization;
using NSubstitute;
using Wader.Bootstrap.Components.Carousel;
using Wader.Bootstrap.Components.Carousel.Internals;
using Wader.Bootstrap.Internal.Constants;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Carousel;

public class BsCarouselIndicatorButtonTests()
    : BsComponentTests<BsCarouselIndicatorButton>("""<button class="{0}" {1}></button>""")
{
    private const int SLIDE_NO = 1;

    private readonly IBsCarouselContext _carouselContextMock = Substitute.For<IBsCarouselContext>();

    protected override Dictionary<string, string> AttributesForDefaultTests =>
        new()
        {
            ["data-bs-target"] = "",
            ["data-bs-slide-to"] = SLIDE_NO.ToString(CultureInfo.InvariantCulture),
            ["type"] = "button",
        };

    protected override void BindParameters(
        ComponentParameterCollectionBuilder<BsCarouselIndicatorButton> parameterBuilder
    )
    {
        base.BindParameters(parameterBuilder);
        _ = parameterBuilder
            .Add(a => a.SlideNo, SLIDE_NO)
            .AddCascadingValue(CascadingValueNames.CAROUSEL_CONTEXT, _carouselContextMock);
    }

    [Fact]
    public void TypeCanBeOverriden()
    {
        TestForAllowingOverride("type");
    }

    [Fact]
    public void DataBsTargetCannotBeOverriden()
    {
        TestForDisallowingOverride("data-bs-target");
    }

    [Fact]
    public void DataBsSlideToCannotBeOverriden()
    {
        TestForDisallowingOverride("data-bs-slide-to");
    }
}
