using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace AH.Collections.Dictionaries
{
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
            if (!dict.ContainsKey(key))
            {
                dict.Add(key, defaultValue);
            }

            return dict[key];
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
            if (!dict.ContainsKey(key))
            {
                dict.Add(key, create());
            }

            return dict[key];
        }
    }
}