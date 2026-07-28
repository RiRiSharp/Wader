using System.Runtime.CompilerServices;

namespace Wader.Bootstrap.Internal;

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
