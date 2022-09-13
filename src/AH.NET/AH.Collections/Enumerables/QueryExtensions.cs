using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace AH.Collections.Enumerables
{
    public static class QueryExtensions
    {
        /// <summary>
        /// Get the first item matching a predicate; if no match exists, return a default value.
        /// </summary>
        /// <param name="enumerable">The collection to query</param>
        /// <param name="predicate">The requirement for which we're trying to find a matching item</param>
        /// <param name="defaultValue">The value to return if no match is found</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The first match found if any, otherwise the default value</returns>
        [PublicAPI]
        public static T FirstOrDefault<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate, T defaultValue) => enumerable.FirstOrDefault(predicate, () => defaultValue);

        /// <summary>
        /// Get the first item matching a predicate; if no match exists, return a default value.
        /// </summary>
        /// <param name="enumerable">The collection to query</param>
        /// <param name="predicate">The requirement for which we're trying to find a matching item</param>
        /// <param name="getDefaultValue">Compute the default value.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The first match found if any, otherwise the default value</returns>
        [PublicAPI]
        public static T FirstOrDefault<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate, Func<T> getDefaultValue)
        {
            foreach (var item in enumerable)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            return getDefaultValue();
        }

        /// <summary>
        /// Get the first item, if any. Otherwise return the default value.
        /// </summary>
        /// <param name="enumerable">The collection to query</param>
        /// <param name="getDefaultValue">Compute the default value.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The first item, if any, otherwise the default value</returns>
        [PublicAPI]
        public static T FirstOrDefault<T>(this IEnumerable<T> enumerable, Func<T> getDefaultValue) => enumerable.FirstOrDefault(_ => true, getDefaultValue);

        /// <summary>
        /// Get the first item, if any. Otherwise return the default value.
        /// </summary>
        /// <param name="enumerable">The collection to query</param>
        /// <param name="defaultValue">The default value.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The first item, if any, otherwise the computed default value</returns>
        [PublicAPI]
        public static T FirstOrDefault<T>(this IEnumerable<T> enumerable, T defaultValue) => enumerable.FirstOrDefault(() => defaultValue);
    }
}