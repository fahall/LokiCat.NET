using System.Collections.Generic;
using JetBrains.Annotations;
using MoreLinq.Extensions;

namespace LokiCat.NET.Collections.Enumerables.Extensions
{
    /// <summary>
    /// Extensions for aggregating collections into strings
    /// </summary>
    [PublicAPI]
    public static class ToDelimitedStringExtension
    {
        /// <inheritdoc cref="MoreLinq.Extensions.ToDelimitedStringExtension.ToDelimitedString{T}(IEnumerable{T}, string)"/>
        [PublicAPI]
        public static string ToDelimitedString<T>(this IEnumerable<T> items, char delimiter) =>
            items.ToDelimitedString($"{delimiter}");
    }
}