namespace Wader.Bootstrap.Components.Modal.Internals;

public class BsModalContext(BsModal modal) : IBsModalContext
{
    public async Task ToggleAsync()
    {
        await modal.ToggleAsync();
    }

    public async Task ShowAsync()
    {
        await modal.ShowAsync();
    }

    public async Task CloseAsync()
    {
        await modal.CloseAsync();
    }

    public async Task HandleUpdateAsync()
    {
        await modal.HandleUpdateAsync();
    }
}
