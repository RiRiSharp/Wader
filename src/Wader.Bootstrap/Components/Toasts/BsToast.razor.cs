using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Components.Toasts.Internals;
using Wader.Bootstrap.Internal.BaseComponents;

namespace Wader.Bootstrap.Components.Toasts;

public partial class BsToast : BsChildContentComponent, IAsyncDisposable
{
    internal ElementReference HtmlRef;
    private ToastJsOptions? _oldOptions;
    private bool _reinitialize;
    protected override string? BsComponentClasses => "toast";

    [Inject]
    public IBsToastJsInterop BsToastJsInterop { get; set; } = null!;

    [Parameter]
    public bool Animation { get; set; } = true;

    [Parameter]
    public bool AutoHide { get; set; } = true;

    [Parameter]
    public int Delay { get; set; } = 5_000;

    private ToastJsOptions ToastJsOptions =>
        new()
        {
            Animation = Animation,
            AutoHide = AutoHide,
            Delay = Delay,
        };

    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        if (_oldOptions == ToastJsOptions)
        {
            return;
        }

        _oldOptions = ToastJsOptions;
        _reinitialize = true;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (_reinitialize)
        {
            await BsToastJsInterop.CreateAsync(HtmlRef, ToastJsOptions);
            _reinitialize = false;
        }
    }

    public async Task ShowAsync()
    {
        await BsToastJsInterop.ShowAsync(HtmlRef);
    }

    public async Task HideAsync()
    {
        await BsToastJsInterop.HideAsync(HtmlRef);
    }

    private async ValueTask DisposeAsync(bool disposing)
    {
        if (!disposing)
        {
            return;
        }

        await BsToastJsInterop.DisposeReferenceAsync(HtmlRef);
    }
}
