using JetBrains.Annotations;

namespace LokiCat.NET.Primitives.Strings.FilePaths;

/// <summary>
/// Extensions for working with file paths.
/// </summary>
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

    private static char OtherPlatformSeparator => CurrentPlatformSeparator == DirectoryDelimiters.UNIX
        ? DirectoryDelimiters.WINDOWS
        : DirectoryDelimiters.UNIX;

    /// <summary>
    /// Converts a path to a unix formatted path.
    /// </summary>
    /// <param name="path">The path to convert.</param>
    /// <returns>A path with windows delimiters replaced with unix delimiters.</returns>
    [PublicAPI]
    public static string ToUnixPath(this string path) =>
        path.Replace(DirectoryDelimiters.WINDOWS, DirectoryDelimiters.UNIX);

    /// <summary>
    /// Converts a path to a custom formatted path.
    /// </summary>
    /// <param name="path"> The path to convert.</param>
    /// <param name="separator">The separator to use.</param>
    /// <returns>A path with windows and unix delimiters replaced with the custom separator.</returns>
    [PublicAPI]
    public static string ToCustomPath(this string path, char separator) => path
                                                                           .Replace(DirectoryDelimiters.WINDOWS,
                                                                               separator)
                                                                           .Replace(DirectoryDelimiters.UNIX,
                                                                               separator);

    /// <summary>
    /// Converts a path to a windows formatted path.
    /// </summary>
    /// <param name="path">The path to convert.</param>
    /// <returns>A path with unix delimiters replaced with windows delimiters.</returns>
    [PublicAPI]
    public static string ToWindowsPath(this string path) =>
        path.Replace(DirectoryDelimiters.UNIX, DirectoryDelimiters.WINDOWS);

    /// <summary>
    /// Converts a path to a path for the current platform.
    /// </summary>
    /// <param name="path">The path to convert.</param>
    /// <returns>A path with delimiters normalized to the current platform.</returns>
    [PublicAPI]
    public static string ToPathForCurrentPlatform(this string path) =>
        path.Replace(OtherPlatformSeparator, CurrentPlatformSeparator);
}