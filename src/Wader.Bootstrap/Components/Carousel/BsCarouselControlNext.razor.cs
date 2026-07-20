using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Components.Carousel.Internals;
using Wader.Bootstrap.Infrastructure.Constants;
using Wader.Bootstrap.Infrastructure.Exceptions;

namespace Wader.Bootstrap.Components.Carousel;

public partial class BsCarouselControlNext : BsChildContentComponent
{
    protected override string? BsComponentClasses => "carousel-control-next";

    [CascadingParameter(Name = CascadingValueNames.CAROUSEL_CONTEXT)]
    private IBsCarouselContext? CarouselContext { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        if (CarouselContext is null)
        {
            throw BsComponentUsageException.MustBeChildOf<BsCarouselControlNext, BsCarousel>();
        }
    }

    public async Task NextAsync()
    {
        await CarouselContext!.MoveNextAsync();
    }
}
