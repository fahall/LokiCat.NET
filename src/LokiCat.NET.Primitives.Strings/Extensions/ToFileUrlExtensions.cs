using JetBrains.Annotations;

namespace LokiCat.NET.Primitives.Strings.Extensions;

public static class ToFileUrlExtensions
{
    /// <summary>
    /// Converts a raw filepath to a file url.
    /// </summary>
    /// <param name="path"></param>
    /// <returns>The path converted to a file url, with delimiters normalized to /</returns>
    [PublicAPI]
    public static string ToFileUrl(this string path) => $"file:///{path.Replace("\\", "/")}";
        
    private const char UNIX_SEPARATOR = '/';
    private const char WINDOWS_SEPARATOR = '\\';
    private static char CurrentPlatformSeparator => Path.DirectorySeparatorChar;

    private static char OtherPlatformSeparator => CurrentPlatformSeparator == UNIX_SEPARATOR ? WINDOWS_SEPARATOR : UNIX_SEPARATOR;
        
    [PublicAPI]
    public static string ToUnixPath(this string path) => path.Replace(WINDOWS_SEPARATOR, UNIX_SEPARATOR);
    [PublicAPI]
    public static string ToWindowsPath(this string path) => path.Replace(UNIX_SEPARATOR, WINDOWS_SEPARATOR);
    [PublicAPI]
    public static string ToPathForCurrentPlatform(this string path) => path.Replace(OtherPlatformSeparator, CurrentPlatformSeparator);
}