using Microsoft.Extensions.Logging;

namespace Wader.Bootstrap.Internal;

internal static partial class BsLog
{
    [LoggerMessage(
        EventId = 0,
        Level = LogLevel.Warning,
        Message = "Parameters `{Variant}` and `{OutlineVariant}` have both been set, `{Variant}` will be used."
    )]
    public static partial void BothVariantsHaveBeenSet(ILogger logger, string variant, string outlineVariant);
}
