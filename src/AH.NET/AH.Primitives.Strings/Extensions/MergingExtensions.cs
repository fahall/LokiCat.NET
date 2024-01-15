using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AH.Primitives.Strings
{
    public static class MergingExtensions
    {
        /// <summary>
        /// Merge two paths together, trying to combine any overlap between them.
        /// </summary>
        /// <example>
        /// left:  path/to/root/stuff/
        /// right: /stuff/that/is/relative
        /// result: path/to/root/stuff/that/is/relative
        /// "path/to/root/stuff/".MergePath("/stuff/that/is/relative") == "path/to/root/stuff/that/is/relative"
        /// </example>
        /// <param name="root"></param>
        /// <param name="child"></param>
        /// <remarks>
        /// Deals with leading and trailing directory separators.
        /// </remarks>
        /// <returns></returns>
        public static string MergePath(this string root, string child) => AddTrailingAndLeadingDelimiters(root, child, GetPathCore(root, child));

        private static string AddTrailingAndLeadingDelimiters(string root, string child, string core)
        {
            foreach (var delimiter in Separators)
            {
                if (root.StartsWith(delimiter))
                {
                    core = $"{delimiter}{core}";
                }

                if (child.EndsWith(delimiter))
                {
                    core = $"{core}{delimiter}";
                }
            }

            return core;
        }

        private static string GetPathCore(string root, string child)
        {
            var right = child.Trim(Separators).Split(Separators);
            var left = root.Trim(Separators).Split(Separators);
            var pathParts = left.Reverse() // Checking the end of left matches the beginning of right
                                .Where((item, index) => right.Length > index && item != right[index])
                                .Reverse() // Reverse back to original order
                                .Concat(right)
                                .ToArray();

            var core = Path.Combine(pathParts);

            return core;
        }

        private static char[] Separators = { '/', '\\' };

        private static string TrimSuffixThatMatchesPrefixOf(this string left, string right)
        {
            var commonLength = FindCommonSuffixPrefixLength(left, right);

            return commonLength > 0 && commonLength <= left.Length ? left[..^commonLength] : left;
        }

        private static int FindCommonSuffixPrefixLength(string a, string b)
        {
            var length = Math.Min(a.Length, b.Length);

            for (var i = 1; i <= length; i++)
            {
                if (a[^i] != b[i - 1])
                {
                    return i - 1;
                }
            }

            return length;
        }
    }
}