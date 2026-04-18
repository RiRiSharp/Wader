using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Components.Carousel.Internals;
using Wader.Bootstrap.Internals.Exceptions;

namespace Wader.Bootstrap.Components.Carousel;

public partial class BsCarouselControlPrev : BsChildContentComponent
{
    protected override string BsComponentClasses => "carousel-control-prev";

    [CascadingParameter(Name = nameof(BsCarousel))]
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
