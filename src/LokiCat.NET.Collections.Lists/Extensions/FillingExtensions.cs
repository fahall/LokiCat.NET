using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using LokiCat.NET.GuardClauses;

namespace LokiCat.NET.Collections.Lists
{
    /// <summary>
    /// Extensions for filling lists.
    /// </summary>
    public static class FillingExtensions
    {
        /// <summary>
        /// Fill a list with a default value until it reaches a minimum length.
        /// </summary>
        /// <param name="list">List to fill</param>
        /// <param name="minLength">minimum length</param>
        /// <param name="defaultValue">default value to use when adding elements to the list</param>
        /// <typeparam name="T">Type of Elements stored in list</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [PublicAPI]
        public static List<T> EnsureMinimumLength<T>(this List<T> list, int minLength, T defaultValue)
        {
            Guard.AgainstNull(list);

            return list.Select(i => i)
                       .Concat(Enumerable.Range(0, Math.Max(0, minLength - list.Count)).Select(_ => defaultValue))
                       .ToList();
        }

        /// <summary>
        /// Fill a list with a computed default value until it reaches a minimum length.
        /// </summary>
        /// <param name="list">List to fill</param>
        /// <param name="minLength">minimum length</param>
        /// <param name="defaultValue">default value generator function to use when adding elements to the list</param>
        /// <typeparam name="T">Type of Elements stored in list</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [PublicAPI]
        public static List<T> EnsureMinimumLength<T>(this List<T> list, int minLength, Func<T> defaultValue)
        {
            Guard.AgainstNull(list);
            Guard.AgainstNull(defaultValue);

            return list.Select(i => i)
                       .Concat(Enumerable.Range(0, Math.Max(0, minLength - list.Count)).Select(_ => defaultValue()))
                       .ToList();
        }
    }
}