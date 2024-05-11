using JetBrains.Annotations;

namespace LokiCat.NET.URIs;

/// <summary>
/// Extensions for working with URIs.
/// </summary>
public static class UriExtensions
{
    /// <summary>
    /// Append paths to the URI.
    /// </summary>
    /// <param name="uri">The base URI.</param>
    /// <param name="paths">The paths to append.</param>
    /// <returns>The new URI with the appended paths.</returns>
    [PublicAPI]
    public static Uri Append(this Uri uri, params string[] paths)
    {
        return new Uri(paths.Aggregate(uri.AbsoluteUri, (current, path) => $"{current.TrimEnd('/')}/{path.TrimStart('/')}"));
    }
}