namespace Wader.Bootstrap.Components.Alert.Internals;

public class BsAlertContext(BsAlert alert) : IBsAlertContext
{
    public async Task DismissAsync()
    {
        await alert.DismissAsync();
    }
}
