using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.Infrastructure.BaseComponents;

public abstract class BsComponent : ComponentBase, IBsComponent
{
    private Dictionary<string, object>? _renderAttributes;
    protected abstract string? BsComponentClasses { get; }
    protected virtual string? BsInlineStyles => null;

    protected IReadOnlyDictionary<string, object>? RenderAttributes => _renderAttributes;

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    protected override void OnParametersSet()
    {
        _renderAttributes = BsClassAttributeUtilities.AssignClassNames(AdditionalAttributes, BsComponentClasses);
        _renderAttributes = BsStyleAttributeUtilities.AssignStyles(RenderAttributes, BsInlineStyles);
        base.OnParametersSet();
    }
}
