using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.Components.Scrollspy.Internals;

public class ScrollspyJsOptions
{
    public required ElementReference TargetRef { get; set; }
    public string? RootMargin { get; set; }
    public double[]? Threshold { get; set; }
    public bool SmoothScroll { get; set; }
}
