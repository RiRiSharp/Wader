using Microsoft.AspNetCore.Components.Forms;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap.Forms;

public abstract class BsInputBase<TValue> : InputBase<TValue>, IBsComponent
{
    protected abstract string BsComponentClasses { get; }

    private Dictionary<string, object>? _renderAttributes;

    protected IReadOnlyDictionary<string, object>? RenderAttributes => _renderAttributes;

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        _renderAttributes = BsAttributeUtilities.AssignClassNames(AdditionalAttributes, BsComponentClasses);

        var errorSuccessClass = EditContext?.FieldCssClass(FieldIdentifier);
        _renderAttributes = BsAttributeUtilities.AssignClassNames(RenderAttributes, errorSuccessClass);
    }
}
