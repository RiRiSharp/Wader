using System.Collections.Frozen;
using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;
using Wader.Bootstrap.Internal.Exceptions;
using Wader.Bootstrap.Internal.Primitives;

namespace Wader.Bootstrap.Helpers.ColoredLinks;

public partial class BsLink : BsChildContentComponent
{
#if DOTNET_10_OR_GREATER
    private readonly FrozenSet<int> _allowedOffsets = [1, 2, 3];
    private readonly FrozenSet<int> _allowedOpacities = [10, 25, 50, 75, 100];
    private readonly FrozenSet<int> _allowedUnderlineOpacities = [0, 10, 25, 50, 75, 100];
#else
    private readonly FrozenSet<int> _allowedOffsets = FrozenSet.ToFrozenSet([1, 2, 3]);
    private readonly FrozenSet<int> _allowedOpacities = FrozenSet.ToFrozenSet([10, 25, 50, 75, 100]);
    private readonly FrozenSet<int> _allowedUnderlineOpacities = FrozenSet.ToFrozenSet([0, 10, 25, 50, 75, 100]);
#endif

    protected override string BsComponentClasses =>
        $"{Variant.ToBootstrapClass()} {OpacityClass} {HoverOpacityClass} {UnderlineVariant?.ToUnderlineClass()} {OffsetClass} {UnderlineOpacityClass}";

    [Parameter]
    public BsLinkVariant Variant { get; set; }

    [Parameter]
    public int? Opacity { get; set; }

    private string? OpacityClass => Opacity is not null ? $"link-opacity-{Opacity.Value}" : null;

    [Parameter]
    public int? HoverOpacity { get; set; }

    private string? HoverOpacityClass => HoverOpacity is not null ? $"link-opacity-{HoverOpacity.Value}-hover" : null;

    [Parameter]
    public BsColor? UnderlineVariant { get; set; }

    [Parameter]
    public int? Offset { get; set; }

    private string? OffsetClass => Offset is not null ? $"link-offset-{Offset.Value}" : null;

    [Parameter]
    public int? UnderlineOpacity { get; set; }
    private string? UnderlineOpacityClass =>
        UnderlineOpacity is not null ? $"link-underline-opacity-{UnderlineOpacity.Value}" : null;

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        if (Opacity is not null && !_allowedOpacities.Contains(Opacity.Value))
        {
            throw new BsParameterException(
                $"{nameof(Opacity)} must be one of [{string.Join(", ", _allowedOpacities)}]"
            );
        }

        if (HoverOpacity is not null && !_allowedOpacities.Contains(HoverOpacity.Value))
        {
            throw new BsParameterException(
                $"{nameof(HoverOpacity)} must be one of [{string.Join(", ", _allowedOpacities)}]"
            );
        }

        if (Offset is not null && !_allowedOffsets.Contains(Offset.Value))
        {
            throw new BsParameterException($"{nameof(Offset)} must be one of [{string.Join(", ", _allowedOffsets)}]");
        }

        if (UnderlineOpacity is not null && !_allowedUnderlineOpacities.Contains(UnderlineOpacity.Value))
        {
            throw new BsParameterException(
                $"{nameof(UnderlineOpacity)} must be one of [{string.Join(", ", _allowedUnderlineOpacities)}]"
            );
        }
    }
}
