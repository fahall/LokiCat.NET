using JetBrains.Annotations;

namespace LokiCat.NET.Collections.Dictionaries.Extensions;

public static class GetOrDefaultExtensions
{
    /// <summary>
    /// Get value from dictionary if it exists, otherwise return a default
    /// </summary>
    /// <param name="dict">The dictionary to search</param>
    /// <param name="key">The key to lookup</param>
    /// <param name="defaultValue">The value to return if the key does not exist</param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    // TODO: Write Tests to cover this function. 
    [PublicAPI]
    public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue defaultValue) 
        => dict.TryGetValue(key, out var value) ? value : defaultValue;
}