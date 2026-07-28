using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.Internal.JsInterop.Unions;

public sealed class HtmlStringOrElementRef : Union<string, ElementReference>
{
    public HtmlStringOrElementRef([StringSyntax("Html")] string html)
        : base(html) { }

    public HtmlStringOrElementRef(ElementReference htmlRef)
        : base(htmlRef) { }

    public static implicit operator HtmlStringOrElementRef(string value)
    {
        return new HtmlStringOrElementRef(value);
    }

    public static implicit operator HtmlStringOrElementRef(ElementReference value)
    {
        return new HtmlStringOrElementRef(value);
    }
}
