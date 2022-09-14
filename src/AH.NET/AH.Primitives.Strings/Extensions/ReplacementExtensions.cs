using System;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace AH.Essentials.Strings
{
    public static class ReplacementExtensions
    {
        /// <summary>
        ///     A convenience extension version of Regex.Replace.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="replacement">The replacement string.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <returns>
        ///     A new string that is identical to the input string, except that the replacement string takes the place of each
        ///     matched string.
        /// </returns>
        // TODO: Write Tests to cover this function. 
        [PublicAPI]
        public static string ReplaceRegex(this string input, string pattern, string replacement,
            RegexOptions options = RegexOptions.None) =>
            Regex.Replace(input, pattern, replacement,
                          options);

        // TODO: Write Tests to cover this function. 
        [PublicAPI]
        public static string ReplaceRegex(this string input, Regex regex, string replacement)
        {
            return regex.Replace(input, replacement);
        }

        // TODO: Write Tests to cover this function. 
        [PublicAPI]
        public static string ReplaceRegex(this string input, string pattern, MatchEvaluator replacement,
            RegexOptions options = RegexOptions.None) =>
            Regex.Replace(input, pattern, replacement,
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

                originalString = $"{originalString.Substring(0, startIndex)}{newValue}{originalString.Substring(startIndex + oldValue.Length)}";

                startIndex += newValue.Length;
            }

            return originalString;
        }
    }
}