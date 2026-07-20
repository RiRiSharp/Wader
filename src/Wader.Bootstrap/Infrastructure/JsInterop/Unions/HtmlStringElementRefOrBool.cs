using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;

namespace Wader.Bootstrap.Infrastructure.JsInterop.Unions;

public sealed class HtmlStringElementRefOrBool : Union<string, ElementReference, bool>
{
    public HtmlStringElementRefOrBool([StringSyntax("Html")] string html)
        : base(html) { }

    public HtmlStringElementRefOrBool(ElementReference htmlRef)
        : base(htmlRef) { }

    public HtmlStringElementRefOrBool(bool use)
        : base(use) { }

    public static implicit operator HtmlStringElementRefOrBool(string value)
    {
        return new HtmlStringElementRefOrBool(value);
    }

    public static implicit operator HtmlStringElementRefOrBool(ElementReference value)
    {
        return new HtmlStringElementRefOrBool(value);
    }

    public static implicit operator HtmlStringElementRefOrBool(bool value)
    {
        return new HtmlStringElementRefOrBool(value);
    }
}
