using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap.BaseComponents;

public abstract class BsComponent : ComponentBase, IBsComponent
{
    private Dictionary<string, object>? _renderAttributes;
    protected abstract string? BsComponentClasses { get; }

    protected IReadOnlyDictionary<string, object>? RenderAttributes => _renderAttributes;

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    protected override void OnParametersSet()
    {
        _renderAttributes = BsClassAttributeUtilities.AssignClassNames(AdditionalAttributes, BsComponentClasses);
        base.OnParametersSet();
    }
}
