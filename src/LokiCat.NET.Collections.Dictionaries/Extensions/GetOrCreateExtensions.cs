using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace LokiCat.NET.Collections.Dictionaries.Extensions
{
    /// <summary>
    /// Extensions for getting or creating values in dictionaries.
    /// </summary>
    public static class GetOrCreateExtensions
    {
        /// <summary>
        /// Get value from dictionary, creating it if it does not exist.
        /// </summary>
        /// <param name="dict">The dictionary to search</param>
        /// <param name="key">The key to lookup</param>
        /// <param name="defaultValue">The value to place with this key if the key is not found in the dictionary</param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>

        // TODO: Write Tests to cover this function. 
        [PublicAPI]
        public static TValue GetOrCreate<TKey, TValue>(IDictionary<TKey, TValue> dict, TKey key, TValue defaultValue)
        {
            dict.TryAdd(key, defaultValue);

            return dict[key];
        }

        /// <summary>
        /// Try to add a key value pair to a dictionary, returning false if the key already exists.
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static bool TryAdd<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            if (dict.ContainsKey(key))
            {
                return false;
            }

            dict[key] = value;

            return true;
        }

        /// <summary>
        /// Get value from dictionary, creating it if it does not exist.
        /// </summary>
        /// <param name="dict">The dictionary to search</param>
        /// <param name="key">The key to lookup</param>
        /// <param name="create">Function to create value if the key is not already in the dictionary</param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>

        // TODO: Write Tests to cover this function. 
        [PublicAPI]
        public static TValue GetOrCreate<TKey, TValue>(IDictionary<TKey, TValue> dict, TKey key, Func<TValue> create)
        {
            dict.TryAdd(key, create());

            return dict[key];
        }
    }
}