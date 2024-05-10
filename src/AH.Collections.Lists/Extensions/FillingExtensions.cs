using System;
using System.Collections.Generic;
using System.Linq;

namespace AH.Collections.Lists
{
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
        public static List<T> EnsureMinimumLength<T>(this List<T> list, int minLength, T defaultValue)
        {
            if (list is null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            return list.Select(i => i).Concat(Enumerable.Range(0,Math.Max(0, minLength - list.Count)).Select(_ => defaultValue)).ToList();
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
        public static List<T> EnsureMinimumLength<T>(this List<T> list, int minLength, Func<T> defaultValue)
        {
            if (list is null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            if (defaultValue is null)
            {
                throw new ArgumentNullException(nameof(defaultValue));
            }

            return list.Select(i => i).Concat(Enumerable.Range(0,Math.Max(0, minLength - list.Count)).Select(_ => defaultValue())).ToList();
        }
    }
}