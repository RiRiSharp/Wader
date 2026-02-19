namespace Wader.Bootstrap.Internals.Exceptions;

public class BsInvalidTableOptionsException : Exception
{
    public BsInvalidTableOptionsException()
        : base("Invalid combination of table options provided.") { }

    public BsInvalidTableOptionsException(string message)
        : base(message) { }

    public BsInvalidTableOptionsException(string message, Exception innerException)
        : base(message, innerException) { }
}
