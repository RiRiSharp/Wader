using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.Infrastructure.JsInterop.Unions;

public sealed record StringOrElementRef
{
    private StringOrElementRef() { }

    public string? StringValue { get; init; }
    public ElementReference? ElementReferenceValue { get; init; }
}
