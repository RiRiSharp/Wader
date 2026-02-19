namespace Wader.Bootstrap.Components.Offcanvas.Internals;

public interface IBsOffcanvasContext
{
    Task ToggleAsync();
    Task ShowAsync();
    Task CloseAsync();
}
