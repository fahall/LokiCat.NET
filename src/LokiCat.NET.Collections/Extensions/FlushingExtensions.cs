using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace LokiCat.NET.Collections.Extensions
{
    /// <summary>
    /// Extensions for flushing collections
    /// </summary>
    public static class FlushingExtensions
    {
        /// <summary>
        /// Empties the collections and returns all contents as an IEnumerable.
        /// </summary>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [PublicAPI]
        public static IEnumerable<T> Flush<T>(this ICollection<T> items)
        {
            var data = items.ToArray();
            items.Clear();

            return data;
        }
    }
}