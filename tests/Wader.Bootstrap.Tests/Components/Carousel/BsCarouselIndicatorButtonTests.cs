using System.Globalization;
using Wader.Bootstrap.Components.Carousel;

namespace Wader.Bootstrap.Tests.Components.Carousel;

public class BsCarouselIndicatorButtonTests()
    : BsComponentTests<BsCarouselIndicatorButton>("""<button class="{0}" {1}></button>""")
{
    private const int SLIDE_NO = 1;

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
        _ = parameterBuilder.Add(a => a.SlideNo, SLIDE_NO);
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
