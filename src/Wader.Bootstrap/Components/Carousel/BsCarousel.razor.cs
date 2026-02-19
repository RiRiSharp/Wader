using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Components.Carousel.Internals;

namespace Wader.Bootstrap.Components.Carousel;

public partial class BsCarousel : BsChildContentComponent, IAsyncDisposable
{
    private bool _autoPlayChanged;

    private BsCarouselAutoPlayMode? _lastAutoPlay;
    internal ElementReference HtmlRef;
    protected override string BsComponentClasses => $"carousel slide {TransitionTypeClass}";

    public IBsCarouselContext? CarouselContext { get; private set; }

    [Parameter]
    public BsCarouselAutoPlayMode AutoPlay { get; set; }

    [Parameter]
    public BsCarouselTransitionType TransitionType { get; set; }

    [Parameter]
    public bool EnableTouch { get; set; } = true;

    /// <summary>
    ///     Makes sure we actually get create data-bs-touch="true" instead of data-bs-touch="", which would happen if we
    ///     directly use the boolean,
    ///     because of how the razor engine handles boolean attribute values
    /// </summary>
    private string EnableTouchAttributeValue => EnableTouch.ToString().ToLowerInvariant();

    [Inject]
    private IBsCarouselJsFunctions CarouselJsFunctions { get; set; } = null!;

    private string? TransitionTypeClass => TransitionType.ToBootstrapClass();

    public async ValueTask DisposeAsync()
    {
        await Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        CarouselContext = new BsCarouselContext(this);
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        if (_lastAutoPlay == AutoPlay)
        {
            return;
        }

        _autoPlayChanged = true;
        _lastAutoPlay = AutoPlay;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (!_autoPlayChanged)
        {
            return;
        }

        // Reset the situation just to be sure
        await RemoveCycleCallback();
        if (AutoPlay is BsCarouselAutoPlayMode.AutoPlayAfterUserInteraction)
        {
            await AddCycleCallback();
        }

        if (AutoPlay is BsCarouselAutoPlayMode.AutoPlay)
        {
            await CycleAsync();
        }

        _autoPlayChanged = false;
    }

    public async Task MoveToSlideAsync(int i)
    {
        await CarouselJsFunctions.MoveToSlideAsync(HtmlRef, i);
        if (AutoPlay is BsCarouselAutoPlayMode.AutoPlayAfterUserInteraction)
        {
            await AddCycleCallback();
        }
    }

    public async Task MovePrevAsync()
    {
        await CarouselJsFunctions.MovePrevAsync(HtmlRef);
        if (AutoPlay is BsCarouselAutoPlayMode.AutoPlayAfterUserInteraction)
        {
            await AddCycleCallback();
        }
    }

    public async Task MoveNextAsync()
    {
        await CarouselJsFunctions.MoveNextAsync(HtmlRef);
        if (AutoPlay is BsCarouselAutoPlayMode.AutoPlayAfterUserInteraction)
        {
            await AddCycleCallback();
        }
    }

    public async Task CycleAsync()
    {
        await CarouselJsFunctions.CycleAsync(HtmlRef);
    }

    public async Task PauseAsync()
    {
        await CarouselJsFunctions.PauseAsync(HtmlRef);
        if (AutoPlay is BsCarouselAutoPlayMode.AutoPlayAfterUserInteraction)
        {
            await RemoveCycleCallback();
        }
    }

    private async Task AddCycleCallback()
    {
        await CarouselJsFunctions.AddCycleCallbackAsync(HtmlRef);
    }

    private async Task RemoveCycleCallback()
    {
        await CarouselJsFunctions.RemoveCycleCallbackAsync(HtmlRef);
    }

    private async Task Dispose(bool disposing)
    {
        if (!disposing)
        {
            return;
        }

        await CarouselJsFunctions.DisposeAsync(HtmlRef);
    }
}
