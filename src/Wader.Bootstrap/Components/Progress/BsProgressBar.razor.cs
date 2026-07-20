using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Infrastructure.Constants;
using Wader.Bootstrap.Infrastructure.Exceptions;
using Wader.Bootstrap.Primitives;

namespace Wader.Bootstrap.Components.Progress;

public partial class BsProgressBar : BsChildContentComponent
{
    protected override string? BsComponentClasses =>
        $"progress-bar {StripedClass} {AnimatedClass} {Background.ToBootstrapClass()}";

    protected override string? BsInlineStyles => WidthStyle;

    [CascadingParameter(Name = CascadingValueNames.PROGRESS_IS_STACKED)]
    private bool IsStacked { get; set; }

    [CascadingParameter(Name = CascadingValueNames.PROGRESS_WIDTH)]
    private double? Width { get; set; }

    private string? WidthStyle => IsStacked ? null : $"width: {Width}%";

    [Parameter]
    public bool Striped { get; set; }

    private string? StripedClass => Striped ? "progress-bar-striped" : null;

    [Parameter]
    public bool Animated { get; set; }

    private string? AnimatedClass => Animated ? "progress-bar-animated" : null;

    [Parameter]
    public BsTextBackground Background { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        if (Width is null)
        {
            throw BsComponentUsageException.MustBeChildOf<BsProgressBar, BsProgress>();
        }
    }
}
