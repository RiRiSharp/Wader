namespace Wader.Bootstrap.Infrastructure.Exceptions;

public class BsMissingParameterException : Exception
{
    public BsMissingParameterException() { }

    public BsMissingParameterException(string message)
        : base(message) { }

    public BsMissingParameterException(string message, Exception innerException)
        : base(message, innerException) { }
}
