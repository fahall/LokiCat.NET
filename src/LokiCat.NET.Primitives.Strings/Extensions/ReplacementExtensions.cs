using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace LokiCat.NET.Primitives.Strings.Extensions;

/// <summary>
/// Extensions for replacing the contents within strings.
/// </summary>
public static class ReplacementExtensions
{
    /// <summary>
    ///     A convenience extension version of Regex.Replace.
    /// </summary>
    /// <param name="text">The string to search for a match.</param>
    /// <param name="pattern">The regular expression pattern to match.</param>
    /// <param name="replacement">The replacement string.</param>
    /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
    /// <returns>
    ///     A new string that is identical to the input string, except that the replacement string takes the place of each
    ///     matched string.
    /// </returns>
    // TODO: Write Tests to cover this function. 
    [PublicAPI]
    [Pure]
    public static string ReplaceRegex(this string text, string pattern, string replacement,
        RegexOptions options = RegexOptions.None) =>
        Regex.Replace(text, pattern, replacement,
                      options);

    /// <summary>
    /// Perform regular expression replacement on the input text
    /// </summary>
    /// <param name="text">Text to modify</param>
    /// <param name="regex">Regular Expression to match</param>
    /// <param name="replacement">Replacement (full Regex replacement support)</param>
    /// <returns></returns>
    // TODO: Write Tests to cover this function. 
    [PublicAPI]
    [Pure]
    public static string ReplaceRegex(this string text, Regex regex, string replacement)
        => regex.Replace(text, replacement);

    /// <summary>
    /// Perform regular expression replacement on the input text
    /// </summary>
    /// <param name="text">Text to modify</param>
    /// <param name="pattern">Regular expression to match.</param>
    /// <param name="replacement">Replacement (full Regex replacement support)</param>
    /// <param name="options">Regex Options</param>
    /// <returns></returns>

    // TODO: Write Tests to cover this function. 
    [PublicAPI]
    [Pure]
    public static string ReplaceRegex(this string text, string pattern, MatchEvaluator replacement,
        RegexOptions options = RegexOptions.None) =>
        Regex.Replace(text, pattern, replacement,
                      options);

    /// <summary>
    ///     Replaces a string's old value with a new value using the string comparison type.
    /// </summary>
    /// <param name="originalString">The string to run the search/replace on.</param>
    /// <param name="oldValue">The old value to find.</param>
    /// <param name="newValue">The new value to replace.</param>
    /// <param name="comparisonType">The type of comparison to use.</param>
    /// <returns></returns>
    // TODO: Write Tests to cover this function. 
    [PublicAPI]
    [Pure]
    public static string Replace(this string originalString, string oldValue, string newValue,
        StringComparison comparisonType)
    {
        var startIndex = 0;

        while (true)
        {
            startIndex = originalString.IndexOf(oldValue, startIndex, comparisonType);

            if (startIndex == -1)
            {
                break;
            }

            originalString = $"{originalString[..startIndex]}{newValue}{originalString[(startIndex + oldValue.Length)..]}";

            startIndex += newValue.Length;
        }

        return originalString;
    }
}