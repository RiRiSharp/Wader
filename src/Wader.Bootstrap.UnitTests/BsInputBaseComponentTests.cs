using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components.Forms;
using Wader.Bootstrap.BaseComponents;

namespace Wader.Bootstrap.UnitTests;

public abstract class BsInputBaseComponentTests<TComponent, TValue>([StringSyntax("Html")] string htmlFormat)
    : BsComponentTests<TComponent>(htmlFormat)
    where TComponent : InputBase<TValue>, IBsComponent
{
    protected TValue? Value { get; set; }

    protected override void BindParameters(ComponentParameterCollectionBuilder<TComponent> parameterBuilder)
    {
        ArgumentNullException.ThrowIfNull(parameterBuilder, nameof(parameterBuilder));
        _ = parameterBuilder.Bind(p => p.Value, Value, newValue => Value = newValue);
    }
}
