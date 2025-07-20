using System.Globalization;

namespace ModuleTech.Core.Base.Extentions;

public static class StringExtensions
{

    /// <summary>
    ///     Converts PascalCase string to camelCase string.
    /// </summary>
    /// <param name="str">String to convert.</param>
    /// <param name="invariantCulture">Invariant culture.</param>
    /// <returns>camelCase of the string.</returns>
    public static string ToCamelCase(this string str, bool invariantCulture = true)
    {
        if (string.IsNullOrWhiteSpace(str)) return str;

        if (str.Length == 1) return invariantCulture ? str.ToLowerInvariant() : str.ToLower();

        return (invariantCulture ? char.ToLowerInvariant(str[0]) : char.ToLower(str[0])) + str.Substring(1);
    }

    /// <summary>
    ///     Converts PascalCase string to camelCase string in specified culture.
    /// </summary>
    /// <param name="str">String to convert.</param>
    /// <param name="culture">An object that supplies culture-specific casing rules.</param>
    /// <returns>camelCase of the string.</returns>
    public static string ToCamelCase(this string str, CultureInfo culture)
    {
        if (string.IsNullOrWhiteSpace(str)) return str;

        if (str.Length == 1) return str.ToLower(culture);

        return char.ToLower(str[0], culture) + str.Substring(1);
    }

}