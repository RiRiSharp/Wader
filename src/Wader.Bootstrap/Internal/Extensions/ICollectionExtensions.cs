namespace Wader.Bootstrap.Internal.Extensions;

internal static class ICollectionExtensions
{
    internal static void AddRange<T>(this ICollection<T> target, IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            target.Add(item);
        }
    }
}
