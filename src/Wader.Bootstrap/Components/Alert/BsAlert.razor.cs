using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wader.Bootstrap.Components.Alert.Internals;
using Wader.Bootstrap.Internal.BaseComponents;
using Wader.Bootstrap.Internal.Primitives;

namespace Wader.Bootstrap.Components.Alert;

public partial class BsAlert : BsChildContentComponent, IAsyncDisposable
{
    internal ElementReference HtmlRef;
    private BsAlertContext _alertContext = null!;
    private bool _dismissed;
    private DotNetObjectReference<BsAlert>? _dotNetRef;

    protected override string? BsComponentClasses =>
        $"alert {Variant.ToAlertClass()} {DismissableClass} {AnimationClass}";

    private string? DismissableClass => Dismissable ? "alert-dismissible" : null;
    private string? AnimationClass => Animate ? "fade show" : null;

    public IBsAlertContext AlertContext => _alertContext;

    [Inject]
    private IBsAlertJsInterop AlertJsInterop { get; set; } = null!;

    [Parameter]
    public BsColor Variant { get; set; }

    [Parameter]
    public bool Dismissable { get; set; }

    [Parameter]
    public bool Animate { get; set; } = true;

    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true);
        GC.SuppressFinalize(this);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _alertContext = new BsAlertContext(this);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender)
        {
            return;
        }

        _dotNetRef = DotNetObjectReference.Create(this);
        await AlertJsInterop.RegisterDismissCallbackAsync(HtmlRef, _dotNetRef);
    }

    public async Task DismissAsync()
    {
        if (!Dismissable)
        {
            throw new InvalidOperationException(
                $"{nameof(BsAlert)} requires {nameof(Dismissable)} to be true in order to dismiss."
            );
        }

        await AlertJsInterop.DismissAsync(HtmlRef);
    }

    [JSInvokable]
    public void UpdateDismissedState()
    {
        _dismissed = true;
    }

    private async ValueTask DisposeAsync(bool disposing)
    {
        if (!disposing)
        {
            return;
        }

        await AlertJsInterop.DisposeReferenceAsync(HtmlRef);
        _dotNetRef?.Dispose();
    }
}
