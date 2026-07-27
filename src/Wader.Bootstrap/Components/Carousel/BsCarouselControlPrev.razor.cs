using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Components.Carousel.Internals;
using Wader.Bootstrap.Infrastructure.BaseComponents;
using Wader.Bootstrap.Infrastructure.Constants;
using Wader.Bootstrap.Infrastructure.Exceptions;

namespace Wader.Bootstrap.Components.Carousel;

public partial class BsCarouselControlPrev : BsChildContentComponent
{
    protected override string? BsComponentClasses => "carousel-control-prev";

    [CascadingParameter(Name = CascadingValueNames.CAROUSEL_CONTEXT)]
    private IBsCarouselContext? CarouselContext { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        if (CarouselContext is null)
        {
            throw BsComponentUsageException.MustBeChildOf<BsCarouselControlPrev, BsCarousel>();
        }
    }

    public async Task PrevAsync()
    {
        await CarouselContext!.MovePrevAsync();
    }
}
