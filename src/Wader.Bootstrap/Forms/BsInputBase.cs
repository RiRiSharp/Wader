using Microsoft.AspNetCore.Components.Forms;
using Wader.Bootstrap.Infrastructure;
using Wader.Bootstrap.Infrastructure.BaseComponents;

namespace Wader.Bootstrap.Forms;

public abstract class BsInputBase<TValue> : InputBase<TValue>, IBsComponent
{
    private Dictionary<string, object>? _renderAttributes;
    protected abstract string? BsComponentClasses { get; }

    protected IReadOnlyDictionary<string, object>? RenderAttributes => _renderAttributes;

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        _renderAttributes = BsClassAttributeUtilities.AssignClassNames(AdditionalAttributes, BsComponentClasses);

        var errorSuccessClass = EditContext?.FieldCssClass(FieldIdentifier);
        _renderAttributes = BsClassAttributeUtilities.AssignClassNames(RenderAttributes, errorSuccessClass);
    }
}
