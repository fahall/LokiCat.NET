using System.Collections.Generic;

namespace AH.Collections.Enumerables
{
    public static class ToEnumerableExtensions
    {
        /// <summary>
        /// Get an IEnumerable representation of an IEnumerator
        /// </summary>
        /// <param name="enumerator">The enumerator to coerce into an IEnumerable</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> AsEnumerable<T>(this IEnumerator<T> enumerator)
        {
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }
    }
}