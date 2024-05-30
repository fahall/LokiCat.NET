using System.Collections.Generic;
using JetBrains.Annotations;

namespace LokiCat.NET.Collections.Enumerables.Extensions
{
    /// <summary>
    /// Extensions for converting between IEnumerable and IEnumerator
    /// </summary>
    public static class ToEnumerableExtensions
    {
        /// <summary>
        /// Get an IEnumerable representation of an IEnumerator
        /// </summary>
        /// <param name="enumerator">The enumerator to coerce into an IEnumerable</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>

        // TODO: Write Tests to cover this function. 
        [PublicAPI]
        public static IEnumerable<T> AsEnumerable<T>(this IEnumerator<T> enumerator)
        {
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }
    }
}