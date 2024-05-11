using System.Collections.Generic;
using System.Linq;

namespace AH.Collections.Extensions
{
    public static class FlushingExtensions
    {
        /// <summary>
        /// Empties the collections and returns all contents as an IEnumerable.
        /// </summary>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> Flush<T>(this ICollection<T> items)
        {
            var data = items.ToArray();
            items.Clear();
            return data;
        }
    }
}