namespace Wader.Bootstrap.Internal.Exceptions;

public class BsJsInteropOptionsException : Exception
{
    public BsJsInteropOptionsException() { }

    public BsJsInteropOptionsException(string? message)
        : base(message) { }

    public BsJsInteropOptionsException(string? message, Exception? innerException)
        : base(message, innerException) { }
}
