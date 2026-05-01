namespace Wader.Bootstrap.Components.Scrollspy;

public class ScrollspyJsOptions
{
    public string RootMargin { get; set; } = "0px 0px -25%";
    public double[] Threshold { get; set; } = [0.1, 0.5, 1];
    public bool SmoothScroll { get; set; }
}
