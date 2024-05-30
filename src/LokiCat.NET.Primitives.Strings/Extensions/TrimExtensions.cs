using JetBrains.Annotations;

namespace LokiCat.NET.Primitives.Strings.Extensions
{
    /// <summary>
    /// Extensions for trimming strings.
    /// </summary>
    public static class TrimExtensions
    {
        /// <summary>
        /// Remove the character from the start and end of the string up to maxToRemove times each.
        /// </summary>
        /// <param name="text">The text to change</param>
        /// <param name="character">The text to remove</param>
        /// <param name="maxToRemove">
        /// The maximum number of times to remove the text
        /// Will remove up to this many times from the start and again from the end
        /// </param>
        /// <returns>The trimmed text</returns>
        [PublicAPI]
        public static string Trim(this string text, char character, int maxToRemove = int.MaxValue) =>
            text.Trim($"{character}", maxToRemove);

        /// <summary>
        /// Remove the character from the end of the string up to maxToRemove times.
        /// </summary>
        /// <param name="text">The text to change</param>
        /// <param name="character">The character to remove</param>
        /// <param name="maxToRemove">
        /// The maximum number of times to remove the character from the end
        /// </param>
        /// <returns>The trimmed text</returns>
        [PublicAPI]
        public static string TrimEnd(this string text, char character, int maxToRemove = int.MaxValue) =>
            text.TrimEnd($"{character}", maxToRemove);

        /// <summary>
        /// Remove the character from the start of the string up to maxToRemove times.
        /// </summary>
        /// <param name="text">The text to change</param>
        /// <param name="character">The character to remove</param>
        /// <param name="maxToRemove">
        /// The maximum number of times to remove the character from the start
        /// </param>
        /// <returns>The trimmed text</returns>
        [PublicAPI]
        public static string TrimStart(this string text, char character, int maxToRemove = int.MaxValue) =>
            text.TrimStart($"{character}", maxToRemove);

        /// <summary>
        /// Remove the characters from the start and end of the string up to maxToRemove times each.
        /// </summary>
        /// <param name="text">The text to change</param>
        /// <param name="charactersToRemove">The text to remove</param>
        /// <param name="maxToRemove">
        /// The maximum number of times to remove the text
        /// Will remove up to this many times from the start and again from the end
        /// </param>
        /// <returns>The trimmed text</returns>
        [PublicAPI]
        public static string Trim(this string text, string charactersToRemove, int maxToRemove = int.MaxValue) =>
            text.TrimStart(charactersToRemove, maxToRemove).TrimEnd(charactersToRemove, maxToRemove);

        /// <summary>
        /// Remove the characters from the end of the string up to maxToRemove times.
        /// </summary>
        /// <param name="text">The text to change</param>
        /// <param name="suffixToRemove">The text to remove</param>
        /// <param name="maxToRemove">
        /// The maximum number of times to remove the text from the end
        /// </param>
        /// <returns>The trimmed text</returns>
        [PublicAPI]
        public static string TrimEnd(this string text, string suffixToRemove, int maxToRemove = int.MaxValue)
        {
            if (suffixToRemove.IsNullOrEmpty())
                return text;
            if (text.IsNullOrEmpty())
                return text;

            var removedSoFar = 0;

            while (removedSoFar < maxToRemove && text.EndsWith(suffixToRemove))
            {
                text = text.Substring(0, text.Length - suffixToRemove.Length);
                removedSoFar++;
            }

            return text;
        }

        /// <summary>
        /// Remove the characters from the end of the string up to maxToRemove times.
        /// </summary>
        /// <param name="text">The text to change</param>
        /// <param name="prefixToRemove">The text to remove</param>
        /// <param name="maxToRemove">
        /// The maximum number of times to remove the text from the start
        /// </param>
        /// <returns>The trimmed text</returns>
        [PublicAPI]
        public static string TrimStart(this string text, string prefixToRemove, int maxToRemove = int.MaxValue)
        {
            if (prefixToRemove.IsNullOrEmpty())
                return text;
            if (text.IsNullOrEmpty())
                return text;

            var removedSoFar = 0;

            while (removedSoFar < maxToRemove && text.StartsWith(prefixToRemove))
            {
                text = text.Substring(prefixToRemove.Length, text.Length - prefixToRemove.Length);
                removedSoFar++;
            }

            return text;
        }
    }
}