﻿using JetBrains.Annotations;

namespace LokiCat.NET.Collections.Enumerables.Extensions;

public static class ForEachExtensions
{
    /// <summary>
    /// A fluent ForEach syntax for use at the end of a Linq query.
    /// </summary>
    /// <remarks>
    /// Caller is responsible for preventing infinite loops.
    /// </remarks>
    /// <param name="source">The enumerable over which to iterate</param>
    /// <param name="action">The action to perform with each item as the input</param>
    /// <typeparam name="T">The type of items in the collection</typeparam>
    /// <exception cref="ArgumentNullException">The </exception>
    // TODO: Write Tests to cover this function. 
    [PublicAPI]
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (var item in source)
        {
            action(item);
        }
    }

    /// <inheritdoc cref="ForEach{T}(IEnumerable{T},Action{T})"/>
    // TODO: Write Tests to cover this function. 
    [PublicAPI]
    public static void ForEach<T>(this IEnumerable<T> source, Action action) where T : notnull
    {
        source.ForEach(_ => action());
    }
}