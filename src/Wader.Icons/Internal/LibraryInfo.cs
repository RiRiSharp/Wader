namespace Wader.Icons.Internal;

internal static class LibraryInfo
{
    internal static readonly string Name =
        typeof(LibraryInfo).Assembly.GetName().Name ?? throw new ArgumentNullException();

    internal static readonly string RootPath = $"./_content/{Name}";
}
