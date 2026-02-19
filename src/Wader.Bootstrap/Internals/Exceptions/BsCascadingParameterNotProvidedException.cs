namespace Wader.Bootstrap.Internals.Exceptions;

public class BsCascadingParameterNotProvidedException : Exception
{
    public BsCascadingParameterNotProvidedException()
        : base("Cascading parameter was not provided.") { }

    public BsCascadingParameterNotProvidedException(string message)
        : base(message) { }

    public BsCascadingParameterNotProvidedException(string message, Exception innerException)
        : base(message, innerException) { }

    public BsCascadingParameterNotProvidedException(Type parameterType)
        : base($"Cascading parameter of type {parameterType.AssemblyQualifiedName} was not provided.")
    {
        ArgumentNullException.ThrowIfNull(parameterType);
    }
}
