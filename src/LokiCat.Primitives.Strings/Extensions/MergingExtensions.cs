namespace AH.Primitives.Strings.Extensions
{
    public static class MergingExtensions
    {
        /// <summary>
        /// Merge two paths together, trying to combine any overlap between them. (will use largest possible overlap if multiple overlaps exist)
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
            Console.WriteLine(right.ToArray());
            Console.WriteLine(left.ToArray());

            var nonOverlapRight = right.ToArray();

            for (var i = right.Length - 1; i >= 0; i--)
            {
                if (!left.TakeLast(i).SequenceEqual(right.Take(i)))
                {
                    // Not a match - Try shorter matches
                    continue;
                }
                nonOverlapRight = right.Skip(i).ToArray();

                break;
            }

            return string.Join(Path.DirectorySeparatorChar, left.Concat(nonOverlapRight).Where(p => p.HasGlyphs()));
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