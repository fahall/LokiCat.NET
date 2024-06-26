﻿using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace LokiCat.NET.Collections.Enumerables.Extensions
{
    /// <summary>
    /// Extensions for checking if all booleans in a collection are true
    /// </summary>
    public static class AllExtensions
    {
        /// <param name="booleans"></param>
        /// <returns>
        /// True: All of the booleanss in this collection are true.
        /// False: At least 1 of the booleans in this collection is false.
        /// </returns>

        // TODO: Write Tests to cover this function. 
        [PublicAPI]
        public static bool All(this IEnumerable<bool> booleans) => booleans.All(r => r);
    }
}