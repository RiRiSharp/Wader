using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Components.Buttons.Internals;
using Wader.Bootstrap.Internal.BaseComponents;

namespace Wader.Bootstrap.Components.Buttons;

public partial class BsButtonBase : BsChildContentComponent, IAsyncDisposable
{
    internal ElementReference HtmlRef;

    protected override string? BsComponentClasses => $"btn {Size.ToBootstrapClass()} {ActiveClass} {DisabledClass}";

    [Parameter]
    public BsButtonSize Size { get; set; }

    [Parameter]
    public bool Active { get; set; }

    private string? ActiveClass => Active ? "active" : null;

    [Parameter]
    public bool Disabled { get; set; }

    private string? DisabledClass => Disabled ? "disabled" : null;

    [Parameter]
    public BsButtonType ButtonType { get; set; }

    [Inject]
    private IBsButtonJsInterop ButtonJsInterop { get; set; } = null!;

    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true);
        GC.SuppressFinalize(this);
    }

    public async Task ToggleAsync()
    {
        await ButtonJsInterop.ToggleAsync(HtmlRef);
    }

    private async ValueTask DisposeAsync(bool disposing)
    {
        if (!disposing)
        {
            return;
        }

        await ButtonJsInterop.DisposeReferenceAsync(HtmlRef);
    }
}
