using JetBrains.Annotations;

namespace LokiCat.NET.Collections.HashSets;

public static class HashSetExtensions
{
    /// <summary>
    /// AddRange for HashSet
    /// </summary>
    /// <param name="set">The set we're adding to</param>
    /// <param name="items">The items to add to the set</param>
    /// <typeparam name="T"></typeparam>
    // TODO: Write Tests to cover this function. 
    [PublicAPI]
    public static void AddRange<T>(this HashSet<T> set, IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            set.Add(item);
        }
    }
}