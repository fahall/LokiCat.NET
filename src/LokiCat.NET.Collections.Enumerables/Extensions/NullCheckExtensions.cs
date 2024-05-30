using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace LokiCat.NET.Collections.Enumerables.Extensions
{
    /// <summary>
    /// Extensions for checking for nulls in collections
    /// </summary>
    public static class NullCheckExtensions
    {
        /// <summary>
        /// Get an enumerable containing all non-nulls from the collection
        /// </summary>
        /// <param name="items">Items to filter</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>An IEnumerable</returns>

        // TODO: Write Tests to cover this function. 
        [PublicAPI]
        public static IEnumerable<T> NonNulls<T>(this IEnumerable<T> items) where T : class =>
            items.Where(t => !(t is null));
    }
}