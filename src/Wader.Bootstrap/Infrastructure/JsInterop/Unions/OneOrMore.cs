namespace Wader.Bootstrap.Infrastructure.JsInterop.Unions;

public class OneOrMore<T> : Union<T, T[]>
{
    internal OneOrMore(T value)
        : base(value) { }

    internal OneOrMore(T[] value)
        : base(value) { }

    public static implicit operator OneOrMore<T>(T value)
    {
        return new OneOrMore<T>(value);
    }

    public static implicit operator OneOrMore<T>(T[] value)
    {
        return new OneOrMore<T>(value);
    }
}
