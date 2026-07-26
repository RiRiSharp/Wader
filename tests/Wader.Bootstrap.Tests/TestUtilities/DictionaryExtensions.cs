namespace Wader.Bootstrap.Tests.TestUtilities;

internal static class DictionaryExtensions
{
    internal static string ToAttributeKeyValueString(this Dictionary<string, string> dictionary)
    {
        return string.Join(separator: ' ', dictionary.Select(kvp => $"{kvp.Key}=\"{kvp.Value}\""));
    }
}
