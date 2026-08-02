using System.Collections.Frozen;
using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;
using Wader.Bootstrap.Internal.Exceptions;

namespace Wader.Bootstrap.Helpers.Stacks;

public partial class StackBase : BsChildContentComponent
{
#if NET10_0_OR_GREATER
    private readonly FrozenSet<int> _allowedGaps = [1, 2, 3, 4, 5];
#else
    private readonly FrozenSet<int> _allowedGaps = FrozenSet.ToFrozenSet([1, 2, 3, 4, 5]);
#endif
    protected override string BsComponentClasses => GapClass;

    [Parameter]
    public int? Gap { get; set; }

    private string GapClass => Gap is not null ? $"gap-{Gap}" : "";

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        if (Gap.HasValue && !_allowedGaps.Contains(Gap.Value))
        {
            throw new BsParameterException($"{nameof(Gap)} must be one of [{string.Join(", ", _allowedGaps)}]");
        }
    }
}
