using System;
using System.Collections.Generic;
using System.Linq;
using AH.Collections.Essentials.Exceptions;
using JetBrains.Annotations;

namespace AH.Collections.Enumerables
{
    public static class RandomExtensions
    {
        /// <inheritdoc>
        ///     <cref>RandomExtensions.GetRandom(IEnumerable{T},Random)</cref>
        /// </inheritdoc>
        /// <remarks>
        /// note: creating a Random instance each call may not be correct for you,
        /// consider a thread-safe static instance
        /// </remarks>
        // TODO: Write Tests to cover this function. 
        [PublicAPI]
        public static T GetRandom<T>(this IEnumerable<T> enumerable) => enumerable.GetRandom(new Random());

        /// <summary>
        /// Get a random item from the collection, using the passed randomizer
        /// </summary>
        /// <param name="enumerable">The collection from which to draw an item</param>
        /// <param name="randomizer">Responsible for providing the random value</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>A random value from the collection</returns>
        [PublicAPI]
        public static T GetRandom<T>(this IEnumerable<T> enumerable, Random randomizer)
        {
            var arr = enumerable.ToArray();

            if (arr.None())
            {
                throw new EmptyCollectionException("Cannot get a random item from an empty collection.");
            }

            return arr[randomizer.Next(0, arr.Length)];
        }
    }
}