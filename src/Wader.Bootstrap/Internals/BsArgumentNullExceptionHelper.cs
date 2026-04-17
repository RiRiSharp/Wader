using System.Runtime.CompilerServices;

namespace Wader.Bootstrap.Internals;

public static class BsArgumentNullExceptionHelper
{
    public static void ThrowIfNull(double? value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
    {
        if (value is null)
        {
            throw new ArgumentNullException(paramName);
        }
    }
}
