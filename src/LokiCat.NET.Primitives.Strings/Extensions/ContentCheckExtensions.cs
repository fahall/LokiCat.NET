using JetBrains.Annotations;

namespace LokiCat.NET.Primitives.Strings.Extensions;

/// <summary>
/// Extensions for checking the contents of strings.
/// </summary>
public static class ContentCheckExtensions
{
    /// <summary>
    /// Returns true if the <paramref name="text" /> string contains the <paramref name="search" /> string using the
    /// supplied <paramref name="comparisonType" />.
    /// </summary>
    /// <param name="text">The string to test for the check string.</param>
    /// <param name="search">The check string.</param>
    /// <param name="comparisonType">The comparison method to use which allows for IgnoreCase methods.</param>
    /// <returns>True if the search string is found in the given text.</returns>
    [PublicAPI]
    [Pure]
    public static bool Contains(this string text, string search, StringComparison comparisonType)
    {
        if (search.IsNullOrEmpty())
            return true;

        // ReSharper disable once ConvertIfStatementToReturnStatement - This is more readable
        if (text.IsNullOrEmpty())
            return false;

        return text.Contains(search, comparisonType);
    }

    /// <summary>
    /// Returns true if the strings is null or an empty string.
    /// </summary>
    /// <param name="text">The string to test.</param>
    /// <returns>True if the string is null or empty, otherwise false.</returns>
    [PublicAPI]
    [Pure]
    public static bool IsNullOrEmpty(this string text) => string.IsNullOrEmpty(text);

    /// <summary>
    /// Check if the string is null, empty, or whitespace
    /// </summary>
    /// <param name="text"></param>
    /// <returns>
    /// true: the string is null, empty, or only whitespace.
    /// false: the string has at least one visible glyph
    /// </returns>
    [PublicAPI]
    [Pure]
    public static bool IsNullOrWhitespace(this string text) => string.IsNullOrWhiteSpace(text);
        
    /// <summary>
    /// Check if the string has any visible glyphs (e.g. printed non-whitespace characters)
    /// </summary>
    /// <remarks>
    /// Inverse of <see cref="IsNullOrWhitespace"/>
    /// </remarks>
    /// <param name="text"></param>
    /// <returns>
    /// true: the string has at least one visible glyph
    /// false: the string is null, empty, or only whitespace
    /// </returns>
    [PublicAPI]
    [Pure]
    public static bool HasGlyphs(this string text) => !string.IsNullOrWhiteSpace(text);
}