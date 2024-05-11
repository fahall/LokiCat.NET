using JetBrains.Annotations;

namespace LokiCat.NET.Primitives.Strings.FilePaths;

public static class ToFileUrlExtensions
{
    /// <summary>
    /// Converts a raw filepath to a file url.
    /// </summary>
    /// <param name="path"></param>
    /// <returns>The path converted to a file url, with delimiters normalized to /</returns>
    [PublicAPI]
    public static string ToFileUrl(this string path) => $"file:///{path.Replace("\\", "/")}";

    private static char CurrentPlatformSeparator => Path.DirectorySeparatorChar;

    private static char OtherPlatformSeparator => CurrentPlatformSeparator == DirectoryDelimiters.UNIX ? DirectoryDelimiters.WINDOWS : DirectoryDelimiters.UNIX;
        
    [PublicAPI]
    public static string ToUnixPath(this string path) => path.Replace(DirectoryDelimiters.WINDOWS, DirectoryDelimiters.UNIX);
    
    [PublicAPI]
    public static string ToCustomPath(this string path, char separator) => path.Replace(DirectoryDelimiters.WINDOWS, separator)
                                                                               .Replace(DirectoryDelimiters.UNIX, separator);
    
    [PublicAPI]
    public static string ToWindowsPath(this string path) => path.Replace(DirectoryDelimiters.UNIX, DirectoryDelimiters.WINDOWS);
    [PublicAPI]
    public static string ToPathForCurrentPlatform(this string path) => path.Replace(OtherPlatformSeparator, CurrentPlatformSeparator);
}