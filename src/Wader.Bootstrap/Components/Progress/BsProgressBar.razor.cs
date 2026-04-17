using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Primitives;

namespace Wader.Bootstrap.Components.Progress;

public partial class BsProgressBar : BsChildContentComponent
{
    protected override string BsComponentClasses =>
        $"progress-bar {StripedClass} {AnimatedClass} {Background.ToBootstrapClass()}";

    [CascadingParameter(Name = nameof(BsProgressStacked))]
    private bool IsStacked { get; set; }

    [CascadingParameter(Name = nameof(BsProgress))]
    private double Width { get; set; }

    private string? WidthStyle => IsStacked ? null : $"width: {Width}%";

    [Parameter]
    public bool Striped { get; set; }
    private string? StripedClass => Striped ? "progress-bar-striped" : null;

    [Parameter]
    public bool Animated { get; set; }
    private string? AnimatedClass => Animated ? "progress-bar-animated" : null;

    [Parameter]
    public BsTextBackground Background { get; set; }
}
