using System;
using AH.Collections.Numbers;
using JetBrains.Annotations;

namespace AH.Collections.Strings
{
    public static class SplittingExtensions
    {
        [PublicAPI]
        public static string UntilFirst(this string haystack, string needle, StringComparison comparison = StringComparison.Ordinal)
        {
            var index = haystack.IndexOf(needle, comparison);

            return index == -1 ? haystack : haystack[..index];
        }

        [PublicAPI]
        public static string UntilFirst(this string haystack, char needle, StringComparison comparison = StringComparison.Ordinal) => haystack.UntilFirst($"{needle}", comparison);

        [PublicAPI]
        public static string UntilLast(this string haystack, string needle, StringComparison comparison = StringComparison.Ordinal)
        {
            var index = haystack.LastIndexOf(needle, comparison);

            return haystack.SubstringUntilOrAll(index);
        }
        
        [PublicAPI]
        public static string UntilLast(this string haystack, char needle, StringComparison comparison = StringComparison.Ordinal) => haystack.UntilLast($"{needle}", comparison);
        
        [PublicAPI]
        public static string AfterFirst(this string haystack, string needle, StringComparison comparison = StringComparison.Ordinal)
        {
            var index = haystack.IndexOf(needle, comparison);

            var needleEnd = index + needle.Length;

            return haystack.SubstringAfterOrAll(needleEnd);
        }
        [PublicAPI]
        public static string AfterFirst(this string haystack, char needle, StringComparison comparison = StringComparison.Ordinal) => haystack.AfterFirst($"{needle}", comparison);

        
        [PublicAPI]
        public static string AfterLast(this string haystack, string needle, StringComparison comparison = StringComparison.Ordinal)
        {
            var index = haystack.LastIndexOf(needle, comparison);

            var needleEnd = index + needle.Length;

            return haystack.SubstringAfterOrAll(needleEnd);
        }

        [PublicAPI]
        public static string AfterLast(this string haystack, char needle, StringComparison comparison = StringComparison.Ordinal) => haystack.AfterLast($"{needle}", comparison);
        
        private static string SubstringUntilOrAll(this string haystack, int index) => index.IsBetween(0, haystack.Length - 1) ? haystack[..index] : haystack;
        private static string SubstringAfterOrAll(this string haystack, int index) => index.IsBetween(0, haystack.Length - 1) ? haystack[index..] : haystack;
    }
}