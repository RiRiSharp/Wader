using System.Collections;
using System.Runtime.CompilerServices;

namespace Wader.Bootstrap.Internal.JsInterop.Unions;

[CollectionBuilder(typeof(OneOrMoreBuilder), nameof(OneOrMoreBuilder.Create))]
public class OneOrMore<T> : Union<T, T[]>, IEnumerable<T>
{
    internal OneOrMore(T value)
        : base(value) { }

    internal OneOrMore(T[] value)
        : base(value) { }

    public IEnumerator<T> GetEnumerator()
    {
        return TryGetAs<T[]>(out var array)
            ? ((IEnumerable<T>)array).GetEnumerator()
            : Enumerable.Repeat(As<T>(), count: 1).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public static implicit operator OneOrMore<T>(T value)
    {
        return new OneOrMore<T>(value);
    }

    public static implicit operator OneOrMore<T>(T[] value)
    {
        return new OneOrMore<T>(value);
    }
}

public static class OneOrMoreBuilder
{
    public static OneOrMore<T> Create<T>(ReadOnlySpan<T> items)
    {
        return new OneOrMore<T>(items.ToArray());
    }
}
