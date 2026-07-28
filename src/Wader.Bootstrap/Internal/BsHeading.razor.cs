using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;

namespace Wader.Bootstrap.Internal;

public partial class BsHeading : BsChildContentComponent
{
    protected override string? BsComponentClasses => null;

    [Parameter, EditorRequired]
    public int Value { get; set; } = 1;

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        ThrowIfInvalid(Value);
    }

    private static void ThrowIfInvalid(int value)
    {
        if (value is <= 0 or > 6)
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }
    }
}
