using System.Globalization;

namespace Wader.Bootstrap.Infrastructure;

internal static class BsStyleAttributeUtilities
{
    /// <summary>
    ///     Combines the style attribute given in the attribute dictionary with the provided style declarations.
    /// </summary>
    /// <typeparam name="TValue">Type of attributes</typeparam>
    /// <param name="additionalAttributes">The attribute dictionary</param>
    /// <param name="styles">CSS declarations to add</param>
    /// <returns>
    ///     A CSS style string containing the combination of the provided styles and the styles present in the dictionary.
    /// </returns>
    internal static string CombineStyles<TValue>(TValue? additionalAttributes, string styles)
        where TValue : IEnumerable<KeyValuePair<string, object>>
    {
        var dictionary = additionalAttributes?.ToDictionary() ?? [];
        return CombineStyles(dictionary, styles);
    }

    /// <summary>
    ///     Combines the style declarations with the style attribute in the dictionary, if present.
    /// </summary>
    /// <param name="additionalAttributes">Attributes, usually on a component</param>
    /// <param name="styles">CSS declaration list</param>
    /// <returns>
    ///     A combined CSS declaration list where later values override earlier ones.
    /// </returns>
    private static string CombineStyles(Dictionary<string, object>? additionalAttributes, string? styles)
    {
        if (additionalAttributes is null || !additionalAttributes.TryGetValue(key: "style", out var styleObj))
        {
            return styles ?? "";
        }

        var styleAttributeValue = Convert.ToString(styleObj, CultureInfo.InvariantCulture);

        if (string.IsNullOrWhiteSpace(styleAttributeValue))
        {
            return styles ?? "";
        }

        if (string.IsNullOrWhiteSpace(styles))
        {
            return styleAttributeValue;
        }

        // Existing styles first, new styles override
        return $"{styleAttributeValue}; {styles}";
    }

    /// <summary>
    ///     Creates a copy of the attribute dictionary where the style attribute is overwritten
    ///     by the combined and normalized style declarations.
    /// </summary>
    /// <param name="additionalAttributes">Attributes, usually on a component</param>
    /// <param name="styles">CSS declaration list</param>
    internal static IDictionary<string, object> AssignStyles(
        IDictionary<string, object>? additionalAttributes,
        string styles
    )
    {
        var attributes = additionalAttributes?.ToDictionary() ?? [];
        AssignStyles(attributes, styles);
        return attributes;
    }

    /// <summary>
    ///     Creates a copy of the attribute dictionary where the style attribute is overwritten
    ///     by the combined and normalized style declarations.
    /// </summary>
    /// <param name="additionalAttributes">Attributes, usually on a component</param>
    /// <param name="styles">CSS declaration list</param>
    internal static Dictionary<string, object> AssignStyles(
        IReadOnlyDictionary<string, object>? additionalAttributes,
        string? styles
    )
    {
        var attributes = additionalAttributes?.ToDictionary() ?? [];
        AssignStyles(attributes, styles);
        return attributes;
    }

    private static void AssignStyles(Dictionary<string, object>? additionalAttributes, string? styles)
    {
        additionalAttributes ??= [];

        var allStyles = CombineStyles(additionalAttributes, styles);
        if (string.IsNullOrWhiteSpace(allStyles))
        {
            _ = additionalAttributes.Remove("style");
            return;
        }

        // Normalize styles:
        // - Split into declarations
        // - Deduplicate by property (case-insensitive)
        // - Last declaration wins
        // - Make sure it is sorted for determinism reasons
        var styleMap = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var declaration in allStyles.Split(separator: ';', StringSplitOptions.RemoveEmptyEntries))
        {
            var parts = declaration.Split(separator: ':', count: 2, StringSplitOptions.TrimEntries);
            if (parts.Length != 2 || string.IsNullOrWhiteSpace(parts[0]))
            {
                continue;
            }

            var property = parts[0];
            styleMap[property] = parts[1];
        }

        additionalAttributes["style"] = string.Join(separator: "; ", styleMap.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
    }
}
