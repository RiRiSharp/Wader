namespace Wader.Bootstrap.Infrastructure.JsInterop.Unions;

public class StringOrBool : Union<string, bool>
{
    internal StringOrBool(string value)
        : base(value) { }

    internal StringOrBool(bool value)
        : base(value) { }

    public static implicit operator StringOrBool(string value)
    {
        return new StringOrBool(value);
    }

    public static implicit operator StringOrBool(bool value)
    {
        return new StringOrBool(value);
    }
}
