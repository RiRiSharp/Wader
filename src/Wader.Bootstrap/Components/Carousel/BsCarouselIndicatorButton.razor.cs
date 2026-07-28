using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Components.Carousel.Internals;
using Wader.Bootstrap.Internal.BaseComponents;
using Wader.Bootstrap.Internal.Constants;
using Wader.Bootstrap.Internal.Exceptions;

namespace Wader.Bootstrap.Components.Carousel;

public partial class BsCarouselIndicatorButton : BsComponent, IBsChildContentComponent
{
    protected override string? BsComponentClasses => ActiveClass;

    [CascadingParameter(Name = CascadingValueNames.CAROUSEL_CONTEXT)]
    private IBsCarouselContext? CarouselContext { get; set; }

    [Parameter]
    public bool Active { get; set; }

    private string? ActiveClass => Active ? "active" : null;

    [Parameter]
    // Zero based index
    public int? SlideNo { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        if (CarouselContext is null)
        {
            throw BsComponentUsageException.MustBeChildOf<BsCarouselIndicatorButton, BsCarousel>();
        }

        if (SlideNo is null or < 0)
        {
            throw new InvalidOperationException($"Slide number {SlideNo} is invalid");
        }
    }

    public async Task MoveToCorrespondingSlideAsync()
    {
        await CarouselContext!.MoveToSlideAsync(SlideNo!.Value);
    }
}
