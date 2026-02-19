namespace Wader.Bootstrap.Components.Modal.Internals;

public interface IBsModalContext
{
    Task ToggleAsync();
    Task ShowAsync();
    Task CloseAsync();
    Task HandleUpdateAsync();
}
