namespace Wader.Bootstrap.Components.Offcanvas.Internals;

public class BsOffcanvasContext(BsOffcanvas offcanvas) : IBsOffcanvasContext
{
    public async Task ToggleAsync()
    {
        await offcanvas.ToggleAsync();
    }

    public async Task ShowAsync()
    {
        await offcanvas.ShowAsync();
    }

    public async Task CloseAsync()
    {
        await offcanvas.CloseAsync();
    }
}
