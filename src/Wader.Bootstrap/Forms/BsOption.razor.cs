using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Infrastructure.BaseComponents;

namespace Wader.Bootstrap.Forms;

public partial class BsOption<TValue> : BsChildContentComponent
{
    protected override string? BsComponentClasses => null;

    [Parameter]
    public TValue? Value { get; set; }
    protected string ValueAsString => FormatValueAsString(Value);

    protected virtual string FormatValueAsString(TValue? value)
    {
        return value?.ToString() ?? "";
    }
}
