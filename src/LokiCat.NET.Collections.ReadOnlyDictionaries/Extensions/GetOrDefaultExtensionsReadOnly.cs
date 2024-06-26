﻿using System.Collections.Generic;
using JetBrains.Annotations;

namespace LokiCat.NET.Collections.ReadOnlyDictionaries.Extensions
{
    /// <summary>
    /// Extensions for getting values from readonly dictionaries.
    /// </summary>
    public static class GetOrDefaultExtensionsReadOnly
    {
        /// <summary>
        /// Get value from readonly dictionary if it exists, otherwise return a default
        /// </summary>
        /// <param name="dict">The dictionary to search</param>
        /// <param name="key">The key to lookup</param>
        /// <param name="defaultValue">The value to return if the key does not exist</param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        [PublicAPI]
        public static TValue GetOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dict, TKey key,
            TValue defaultValue) => dict.ContainsKey(key) ? dict[key] : defaultValue;
    }
}