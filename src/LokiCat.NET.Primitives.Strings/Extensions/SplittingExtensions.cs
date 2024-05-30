using System;
using LokiCat.NET.Primitives.Numbers.Extensions;
using JetBrains.Annotations;

namespace LokiCat.NET.Primitives.Strings.Extensions
{
    /// <summary>
    /// Extensions for splitting strings.
    /// </summary>
    public static class SplittingExtensions
    {
        /// <summary>
        /// Get the contents of the string before the first occurence of the delimiter.
        /// </summary>
        /// <param name="text">The string to split.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="comparison">The comparison to use.</param>
        /// <returns>The parts of the string split by the delimiter.</returns>

        // TODO: Write Tests to cover this function. 
        [PublicAPI]
        [Pure]
        public static string UntilFirst(this string text, string delimiter,
            StringComparison comparison = StringComparison.Ordinal)
        {
            var index = text.IndexOf(delimiter, comparison);

            return index == -1 ? text : text.Substring(0, index);
        }

        /// <summary>
        /// Get the contents of the string before the first occurence of the delimiter.
        /// </summary>
        /// <param name="text">The string to split.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="comparison">The comparison to use.</param>
        /// <returns>The parts of the string split by the delimiter.</returns>

        // TODO: Write Tests to cover this function. 
        [PublicAPI]
        [Pure]
        public static string UntilFirst(this string text, char delimiter,
            StringComparison comparison = StringComparison.Ordinal) => text.UntilFirst($"{delimiter}", comparison);

        /// <summary>
        /// Get the contents of the string before the last occurence of the delimiter.
        /// </summary>
        /// <param name="text">The string to split.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="comparison">The comparison to use.</param>
        /// <returns>The parts of the string split by the delimiter.</returns>

        // TODO: Write Tests to cover this function. 
        [PublicAPI]
        [Pure]
        public static string UntilLast(this string text, string delimiter,
            StringComparison comparison = StringComparison.Ordinal)
        {
            var index = text.LastIndexOf(delimiter, comparison);

            return text.SubstringUntilOrAll(index);
        }

        /// <summary>
        /// Get the contents of the string before the last occurence of the delimiter.
        /// </summary>
        /// <param name="text">The string to split.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="comparison">The comparison to use.</param>
        /// <returns>The parts of the string split by the delimiter.</returns>

        // TODO: Write Tests to cover this function. 
        [PublicAPI]
        [Pure]
        public static string UntilLast(this string text, char delimiter,
            StringComparison comparison = StringComparison.Ordinal) => text.UntilLast($"{delimiter}", comparison);

        /// <summary>
        /// Get the contents of the string after the first occurence of the delimiter.
        /// </summary>
        /// <param name="text">The string to split.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="comparison">The comparison to use.</param>
        /// <returns>The parts of the string split by the delimiter.</returns>    // TODO: Write Tests to cover this function. 
        [PublicAPI]
        public static string AfterFirst(this string text, string delimiter,
            StringComparison comparison = StringComparison.Ordinal)
        {
            var index = text.IndexOf(delimiter, comparison);

            var delimiterEnd = index + delimiter.Length;

            return text.SubstringAfterOrAll(delimiterEnd);
        }

        /// <summary>
        /// Get the contents of the string after the first occurence of the delimiter.
        /// </summary>
        /// <param name="text">The string to split.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="comparison">The comparison to use.</param>
        /// <returns>The parts of the string split by the delimiter.</returns>

        // TODO: Write Tests to cover this function. 
        [PublicAPI]
        [Pure]
        public static string AfterFirst(this string text, char delimiter,
            StringComparison comparison = StringComparison.Ordinal) => text.AfterFirst($"{delimiter}", comparison);

        /// <summary>
        /// Get the contents of the string after the last occurence of the delimiter.
        /// </summary>
        /// <param name="text">The string to split.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="comparison">The comparison to use.</param>
        /// <returns>The parts of the string split by the delimiter.</returns>   

        // TODO: Write Tests to cover this function. 
        [PublicAPI]
        [Pure]
        public static string AfterLast(this string text, string delimiter,
            StringComparison comparison = StringComparison.Ordinal)
        {
            var index = text.LastIndexOf(delimiter, comparison);

            var delimiterEnd = index + delimiter.Length;

            return text.SubstringAfterOrAll(delimiterEnd);
        }

        /// <summary>
        /// Get the contents of the string after the last occurence of the delimiter.
        /// </summary>
        /// <param name="text">The char to split.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="comparison">The comparison to use.</param>
        /// <returns>The parts of the string split by the delimiter.</returns>

        // TODO: Write Tests to cover this function. 
        [PublicAPI]
        [Pure]
        public static string AfterLast(this string text, char delimiter,
            StringComparison comparison = StringComparison.Ordinal) => text.AfterLast($"{delimiter}", comparison);

        private static string SubstringUntilOrAll(this string text, int index) =>
            index.IsBetween(0, text.Length - 1) ? text.Substring(0, index) : text;

        private static string SubstringAfterOrAll(this string text, int index) =>
            index.IsBetween(0, text.Length - 1) ? text.Substring(index) : text;
    }
}