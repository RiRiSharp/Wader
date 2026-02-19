using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Components.Carousel.Internals;
using Wader.Bootstrap.Internals.Exceptions;

namespace Wader.Bootstrap.Components.Carousel;

public partial class BsCarouselControlNext : BsChildContentComponent
{
    protected override string BsComponentClasses => "carousel-control-next";

    [CascadingParameter]
    private IBsCarouselContext? CarouselContext { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        if (CarouselContext is null)
        {
            throw new BsCascadingParameterNotProvidedException(typeof(IBsCarouselContext));
        }
    }

    public async Task NextAsync()
    {
        await CarouselContext!.MoveNextAsync();
    }
}
