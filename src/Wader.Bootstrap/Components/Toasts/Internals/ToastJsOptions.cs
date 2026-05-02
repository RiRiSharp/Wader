namespace Wader.Bootstrap.Components.Toasts.Internals;

public record ToastJsOptions
{
    public bool Animation { get; set; }
    public bool AutoHide { get; set; }
    public int Delay { get; set; }
}
