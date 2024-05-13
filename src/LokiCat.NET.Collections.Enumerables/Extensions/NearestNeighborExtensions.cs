using JetBrains.Annotations;
using MoreLinq.Extensions;

namespace LokiCat.NET.Collections.Enumerables.Extensions;

/// <summary>
/// Extensions for Nearest Neighbor calculations
/// </summary>
public static class NearestNeighborExtensions
{
    /// <summary>
    /// Get Count Nearest Neighbors
    /// </summary>
    /// <param name="neighbors">Neighbors to consider</param>
    /// <param name="item">Query Item</param>
    /// <param name="distanceBetween">DistanceBetween(item, neighbor)</param>
    /// <param name="count">Max elements to return</param>
    /// <typeparam name="TNeighbors"></typeparam>
    /// <typeparam name="TQuery"></typeparam>
    /// <returns></returns>

    // TODO: Write Tests to cover this function. 
    [PublicAPI]
    public static IEnumerable<TNeighbors> NearestNeighbors<TNeighbors, TQuery>(
        this IEnumerable<TNeighbors> neighbors,
        TQuery item,
        Func<TQuery, TNeighbors, float> distanceBetween,
        int count = int.MaxValue) => neighbors.Minima(n => distanceBetween(item, n)).Take(count);

    /// <summary>
    /// Get the nearest neighbor (KNN where K = 1)
    /// </summary>
    /// <see cref="NearestNeighbors{TNeighbors,TQuery}"/>

    // TODO: Write Tests to cover this function. 
    [PublicAPI]
    public static TNeighbors NearestNeighbor<TNeighbors, TQuery>(
        this IEnumerable<TNeighbors> neighbors,
        TQuery item,
        Func<TQuery, TNeighbors, float> distanceBetween,
        TNeighbors defaultValue) => neighbors.NearestNeighbors(item, distanceBetween, 1).FirstOrDefault(defaultValue);
}