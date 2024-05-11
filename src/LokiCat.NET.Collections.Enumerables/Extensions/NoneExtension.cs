using JetBrains.Annotations;

namespace LokiCat.NET.Collections.Enumerables.Extensions;

public static class NoneExtension
{
    /// <summary>
    /// Is the collection empty?
    /// </summary>
    /// <param name="enumerable">The collection</param>
    /// <typeparam name="T"></typeparam>
    /// <returns>
    /// true if collection is empty.
    /// false if any items in collection
    /// </returns>
    // TODO: Write Tests to cover this function. 
    [PublicAPI]
    public static bool None<T>(this IEnumerable<T> enumerable) => !enumerable.Any();

    /// <summary>
    /// Are there NO items in the collection that match the predicate?
    /// </summary>
    /// <param name="enumerable">The collection</param>
    /// <param name="predicate">The requirement that items we are looking for match.</param>
    /// <typeparam name="T"></typeparam>
    /// <returns>
    /// true if collection has nothing matching the predicate.
    /// false if any items in collection match predicate
    /// </returns>
    // TODO: Write Tests to cover this function. 
    [PublicAPI]
    public static bool None<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate) => !enumerable.Any(predicate);
}