namespace Wader.Bootstrap.UnitTests;

internal static class DictionaryExtensions
{
    internal static string ToAttributeKeyValueString(this Dictionary<string, string> dictionary)
    {
        return string.Join(' ', dictionary.Select(kvp => $"{kvp.Key}=\"{kvp.Value}\""));
    }
}
