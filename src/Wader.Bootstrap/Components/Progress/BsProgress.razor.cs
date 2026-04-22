using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Internals;
using Wader.Bootstrap.Internals.Constants;
using Wader.Bootstrap.Internals.Exceptions;

namespace Wader.Bootstrap.Components.Progress;

public partial class BsProgress : BsChildContentComponent
{
    protected override string BsComponentClasses => "progress";
    protected override string? BsInlineStyles => WidthStyle;

    [CascadingParameter(Name = CascadingValueNames.PROGRESS_IS_STACKED)]
    private bool IsStacked { get; set; }

    /// <summary>
    /// The current value represented by the progress bar.
    /// </summary>
    /// <remarks>
    /// Required when <see cref="Width"/> is not specified.
    /// Used together with <see cref="ValueMin"/> and <see cref="ValueMax"/>
    /// to calculate the progress width as a percentage.
    /// </remarks>
    [Parameter]
    public double? ValueNow { get; set; }

    /// <summary>
    /// Explicit width of the progress bar, expressed as a percentage.
    /// </summary>
    /// <remarks>
    /// When specified, this value takes precedence; no value-based
    /// calculation is performed and <see cref="ValueNow"/>,
    /// <see cref="ValueMin"/>, and <see cref="ValueMax"/> are ignored.
    /// The width is cascaded to child <see cref="BsProgressBar"/> components,
    /// unlike Bootstrap's default approach where widths are typically
    /// applied per progress bar.
    /// </remarks>
    [Parameter]
    public double? Width { get; set; }
    private string? WidthStyle => IsStacked ? $"width: {Width}%" : null;

    private double ActualWidth => Width ?? ((ValueNow - ValueMin) / (ValueMax - ValueMin)) ?? 0;

    /// <summary>
    /// The minimum value of the progress range.
    /// </summary>
    /// <remarks>
    /// Required when <see cref="Width"/> is not specified.
    /// Must be less than <see cref="ValueMax"/>.
    /// </remarks>
    [Parameter]
    public double? ValueMin { get; set; }

    /// <summary>
    /// The maximum value of the progress range.
    /// </summary>
    /// <remarks>
    /// Required when <see cref="Width"/> is not specified.
    /// Must be greater than <see cref="ValueMin"/>.
    /// </remarks>
    [Parameter]
    public double? ValueMax { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        if (Width is not null)
        {
            return;
        }

        _ = ValueNow ?? throw new ArgumentException("Value must be provided.", nameof(ValueNow));
        var min = ValueMin ?? throw new ArgumentException("Value must be provided.", nameof(ValueMin));
        var max = ValueMax ?? throw new ArgumentException("Value must be provided.", nameof(ValueMax));

        if (max <= min)
        {
            throw new ArgumentOutOfRangeException($"{nameof(ValueMin)} must be less than {nameof(ValueMax)}");
        }
    }
}
