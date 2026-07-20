namespace Wader.Bootstrap.Infrastructure.Exceptions;

public class BsComponentUsageException : InvalidOperationException
{
    public BsComponentUsageException() { }

    public BsComponentUsageException(string message)
        : base(message) { }

    public BsComponentUsageException(string message, Exception innerException)
        : base(message, innerException) { }

    public static BsComponentUsageException MustBeChildOf<TChild, TParent>()
        where TChild : notnull
        where TParent : notnull
    {
        return new BsComponentUsageException(
            $"{typeof(TChild).Name} must be placed inside a {typeof(TParent).Name} component."
        );
    }
}
