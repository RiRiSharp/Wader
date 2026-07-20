using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Components.Modal.Internals;
using Wader.Bootstrap.Primitives;

namespace Wader.Bootstrap.Components.Modal;

public partial class BsModal : BsChildContentComponent, IAsyncDisposable
{
    internal ElementReference HtmlRef;
    protected override string? BsComponentClasses => $"modal {FadeClass}";

    public IBsModalContext? ModalContext { get; private set; }

    [Parameter]
    public BsBackdrop Backdrop { get; set; }

    private string? DataBsBackdrop => Backdrop.ToDataBsBackdropValue();
    private string? DataBsKeyboard => Backdrop.ToDataBsKeyboardValue();

    [Parameter]
    public bool Fade { get; set; } = true;

    private string? FadeClass => Fade ? "fade" : null;

    [Inject]
    private IBsModalJsInterop BsModalJsInterop { get; set; } = null!;

    public async ValueTask DisposeAsync()
    {
        await Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        ModalContext = new BsModalContext(this);
    }

    public async Task ToggleAsync()
    {
        await BsModalJsInterop.ToggleAsync(HtmlRef);
    }

    public async Task ShowAsync()
    {
        await BsModalJsInterop.ShowAsync(HtmlRef);
    }

    public async Task CloseAsync()
    {
        await BsModalJsInterop.CloseAsync(HtmlRef);
    }

    public async Task HandleUpdateAsync()
    {
        await BsModalJsInterop.HandleUpdateAsync(HtmlRef);
    }

    private async Task Dispose(bool disposing)
    {
        if (!disposing)
        {
            return;
        }

        await BsModalJsInterop.DisposeReferenceAsync(HtmlRef);
    }
}
