using JetBrains.Annotations;

namespace LokiCat.NET.URIs;

public static class UriExtensions
{
    [PublicAPI]
    public static Uri Append(this Uri uri, params string[] paths)
    {
        return new Uri(paths.Aggregate(uri.AbsoluteUri, (current, path) => $"{current.TrimEnd('/')}/{path.TrimStart('/')}"));
    }
}