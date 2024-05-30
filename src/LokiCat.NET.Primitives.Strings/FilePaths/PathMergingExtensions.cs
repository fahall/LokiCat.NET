using System;
using System.Linq;
using JetBrains.Annotations;
using LokiCat.NET.Primitives.Strings.Extensions;
using MoreLinq;

namespace LokiCat.NET.Primitives.Strings.FilePaths
{
    /// <summary>
    /// Extensions for merging paths together.
    /// </summary>
    public static class PathMergingExtensions
    {
        private static readonly char[] Separators = { '/', '\\' };

        /// <summary>
        /// Merge two paths together, trying to combine any overlap between them. (will use largest possible overlap if multiple overlaps exist)
        /// </summary>
        /// <example>
        /// left:  path/to/root/stuff/
        /// right: /stuff/that/is/relative
        /// result: path/to/root/stuff/that/is/relative
        /// "path\to\root\stuff\".MergePath("/stuff/that/is/relative") == "path/to/root/stuff/that/is/relative"
        /// </example>
        /// <param name="root"></param>
        /// <param name="child"></param>
        /// <remarks>
        /// Deals with leading and trailing directory separators.
        /// </remarks>
        /// <returns>A unix style path</returns>
        [PublicAPI]
        public static string MergePathUnix(this string root, string child) =>
            root.MergePath(child, DirectoryDelimiters.UNIX);

        /// <summary>
        /// Merge two paths together, trying to combine any overlap between them. (will use largest possible overlap if multiple overlaps exist)
        /// </summary>
        /// <example>
        /// left:  path\to\root\stuff\
        /// right: \stuff\that\is\relative
        /// result: path\to\root\stuff\that\is\relative
        /// "path/to/root/stuff/".MergePath("/stuff/that/is/relative") == "path\to\root\stuff\that\is\relative"
        /// </example>
        /// <param name="root"></param>
        /// <param name="child"></param>
        /// <remarks>
        /// Deals with leading and trailing directory separators.
        /// </remarks>
        /// <returns>A Windows/DOS style path</returns>
        [PublicAPI]
        public static string MergePathWindows(this string root, string child) =>
            root.MergePath(child, DirectoryDelimiters.WINDOWS);

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
        /// <param name="delimiter">Delimiter to use for combining the paths</param>
        /// <remarks>
        /// Deals with leading and trailing directory separators.
        /// </remarks>
        /// <returns></returns>
        [PublicAPI]
        public static string MergePath(this string root, string child, char delimiter)
        {
            var hasRoot = root.HasGlyphs();
            var hasChild = child.HasGlyphs();

            if (!hasRoot && !hasChild)
            {
                return string.Empty;
            }

            if (hasRoot && !hasChild)
            {
                return root.ToCustomPath(delimiter);
            }

            if (!hasRoot && hasChild)
            {
                return child.ToCustomPath(delimiter);
            }

            var left = root.ToCustomPath(delimiter);
            var right = child.ToCustomPath(delimiter);
            var core = GetPathCore(left, right, delimiter);

            return AddTrailingAndLeadingDelimiters(left, right, core, delimiter);
        }

        private static string AddTrailingAndLeadingDelimiters(string root, string child, string core, char delimiter)
        {
            var sep = $"{delimiter}";
            var prefix = root.StartsWith(sep) ? sep : "";
            var suffix = child.EndsWith(sep) ? sep : "";

            return $"{prefix}{core}{suffix}";
        }

        private static string GetPathCore(string root, string child, char delimiter)
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

            return string.Join($"{delimiter}", left.Concat(nonOverlapRight).Where(p => p.HasGlyphs()));
        }
    }
}