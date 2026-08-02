namespace Wader.Bootstrap.Internal.Exceptions;

public class BsParameterException : Exception
{
    public BsParameterException() { }

    public BsParameterException(string? message)
        : base(message) { }

    public BsParameterException(string? message, Exception? innerException)
        : base(message, innerException) { }
}
