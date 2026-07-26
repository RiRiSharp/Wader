using System.Diagnostics.CodeAnalysis;

namespace Wader.Bootstrap.Infrastructure.JsInterop.Unions;

public class Union : IEquatable<Union>
{
    public Union(object? value)
    {
        Value = value;
    }

    public Type? ValueType => Value?.GetType();
    public object? Value { get; }

    public bool Equals(Union? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Equals(Value, other.Value);
    }

    public bool Is<T>()
    {
        return Value is T;
    }

    public bool TryGetAs<T>([NotNullWhen(true)] out T? value)
    {
        if (Value is T casted)
        {
            value = casted;
            return true;
        }

        value = default;
        return false;
    }

    public T As<T>()
    {
        if (Value is T casted)
        {
            return casted;
        }

        throw new InvalidOperationException($"Union contains {ValueType?.Name ?? "null"}, not {typeof(T).Name}.");
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        return Equals((Union)obj);
    }

    public override int GetHashCode()
    {
        return Value?.GetHashCode() ?? 0;
    }
}

/// <summary>
///     A 2-typed union type.
/// </summary>
/// <typeparam name="T1">The first possible type of the union</typeparam>
/// <typeparam name="T2">The second possible type of the union</typeparam>
public class Union<T1, T2> : Union
{
    internal Union(T1 value)
        : base(value) { }

    internal Union(T2 value)
        : base(value) { }

    public static implicit operator Union<T1, T2>(T1 value)
    {
        return new Union<T1, T2>(value);
    }

    public static implicit operator Union<T1, T2>(T2 value)
    {
        return new Union<T1, T2>(value);
    }
}

public class Union<T1, T2, T3> : Union
{
    internal Union(T1 value)
        : base(value) { }

    internal Union(T2 value)
        : base(value) { }

    internal Union(T3 value)
        : base(value) { }

    public static implicit operator Union<T1, T2, T3>(T1 value)
    {
        return new Union<T1, T2, T3>(value);
    }

    public static implicit operator Union<T1, T2, T3>(T2 value)
    {
        return new Union<T1, T2, T3>(value);
    }

    public static implicit operator Union<T1, T2, T3>(T3 value)
    {
        return new Union<T1, T2, T3>(value);
    }
}
