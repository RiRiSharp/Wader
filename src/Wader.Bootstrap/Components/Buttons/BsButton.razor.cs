using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;

namespace Wader.Bootstrap.Components.Buttons;

public partial class BsButton : BsChildContentComponent, IAsyncDisposable
{
    private BsButtonBase? _buttonBase;
    protected override string? BsComponentClasses => Variant.ToBootstrapClass();

    [Parameter]
    public BsButtonType ButtonType { get; set; }

    [Parameter]
    public BsButtonVariant Variant { get; set; }

    [Parameter]
    public BsButtonSize Size { get; set; }

    [Parameter]
    public bool Active { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true);
        GC.SuppressFinalize(this);
    }

    public async Task ToggleAsync()
    {
        if (_buttonBase is null)
        {
            return;
        }

        await _buttonBase.ToggleAsync();
    }

    private async ValueTask DisposeAsync(bool disposing)
    {
        if (!disposing || _buttonBase is null)
        {
            return;
        }

        await _buttonBase.DisposeAsync();
    }
}
