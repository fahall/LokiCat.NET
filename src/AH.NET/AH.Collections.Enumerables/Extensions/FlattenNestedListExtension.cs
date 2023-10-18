﻿using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace AH.Collections.Enumerables
{
    public static class FlattenNestedListExtension
    {
        /// <summary>
        /// Converts a nested enumerable into a single, flat enumerable
        /// </summary>
        /// <param name="enumerable">Nested collection</param>
        /// <typeparam name="T">The types of items stored in the collection</typeparam>
        /// <returns></returns>
        // TODO: Write Tests to cover this function. 
        [PublicAPI]
        public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> enumerable) => enumerable.SelectMany(x => x);
    }
}