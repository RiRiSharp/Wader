using System.Globalization;

namespace Wader.Bootstrap.Infrastructure;

internal static class BsClassAttributeUtilities
{
    /// <summary>
    ///     Combines the class attribute given in the attribute dictionary with the classnames provided.
    /// </summary>
    /// <typeparam name="TValue">Type of attributes</typeparam>
    /// <param name="additionalAttributes">The attribute dictionary</param>
    /// <param name="classNames">CSS classes to add</param>
    /// <returns>
    ///     A CSS class string containing the combination of the provided classnames and the classes present in the
    ///     dictionary.
    /// </returns>
    internal static string CombineClassNames<TValue>(TValue? additionalAttributes, string classNames)
        where TValue : IEnumerable<KeyValuePair<string, object>>
    {
        var dictionary = additionalAttributes?.ToDictionary() ?? [];
        return CombineClassNames(dictionary, classNames);
    }

    /// <summary>
    ///     Combines the classnames with the class attribute in the dictionary, if present
    /// </summary>
    /// <remark>
    ///     Taken from Microsoft.AspNetCore.Components.Forms.AttributeUtilities, licensed under MIT license
    /// </remark>
    /// <param name="additionalAttributes">Attributes, usually on a component</param>
    /// <param name="classNames">Space separated "list" of classes</param>
    /// <returns>A combination of the provided classNames and the class names present in the attributes dictionary</returns>
    private static string CombineClassNames(Dictionary<string, object>? additionalAttributes, string? classNames)
    {
        if (additionalAttributes is null || !additionalAttributes.TryGetValue(key: "class", out var @class))
        {
            return classNames ?? "";
        }

        var classAttributeValue = Convert.ToString(@class, CultureInfo.InvariantCulture);

        if (string.IsNullOrEmpty(classAttributeValue))
        {
            return "";
        }

        return string.IsNullOrEmpty(classNames) ? classAttributeValue : $"{classNames} {classAttributeValue}";
    }

    /// <summary>
    ///     Creates a copy of the attribute dictionary where the classes attribute is overwritten by the provided string class
    ///     names.
    /// </summary>
    /// <param name="additionalAttributes">The attribute dictionary to create a copy of.</param>
    /// <param name="classNames">The classes which will overwrite to the class attribute of the attribute dictionary</param>
    /// <returns>A copy of the attribute dictionary where the classes attribute is overwritten.</returns>
    internal static IDictionary<string, object> AssignClassNames(
        IDictionary<string, object>? additionalAttributes,
        string classNames
    )
    {
        var attributes = new Dictionary<string, object>();
        if (additionalAttributes is not null)
        {
            attributes = additionalAttributes.ToDictionary();
        }

        AssignClassNames(attributes, classNames);
        return attributes;
    }

    /// <summary>
    ///     Creates a copy of the attribute dictionary where the classes attribute is overwritten by the provided string class
    ///     names.
    /// </summary>
    /// <param name="additionalAttributes">The attribute dictionary to create a copy of.</param>
    /// <param name="classNames">The classes which will overwrite to the class attribute of the attribute dictionary</param>
    /// <returns>A copy of the attribute dictionary where the classes attribute is overwritten.</returns>
    internal static Dictionary<string, object> AssignClassNames(
        IReadOnlyDictionary<string, object>? additionalAttributes,
        string? classNames
    )
    {
        var attributes = additionalAttributes?.ToDictionary() ?? [];
        AssignClassNames(attributes, classNames);
        return attributes;
    }

    private static void AssignClassNames(Dictionary<string, object>? additionalAttributes, string? classNames)
    {
        additionalAttributes ??= [];
        var allClasses = CombineClassNames(additionalAttributes, classNames);
        // Make sure every class is only mentioned once, otherwise every parameterSet call will re-add some classes
        var classSet = allClasses.Split(separator: ' ', StringSplitOptions.RemoveEmptyEntries).ToHashSet();
        additionalAttributes["class"] = string.Join(separator: " ", classSet);
    }
}
