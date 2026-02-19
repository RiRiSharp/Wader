using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Components.Carousel.Internals;

namespace Wader.Bootstrap.Components.Carousel;

public partial class BsCarouselIndicatorButton : BsComponent, IBsChildContentComponent
{
    protected override string? BsComponentClasses => ActiveClass;

    [CascadingParameter]
    private IBsCarouselContext? CarouselContext { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public bool Active { get; set; }

    private string? ActiveClass => Active ? "active" : null;

    [Parameter]
    // Zero based index
    public int? SlideNo { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
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
