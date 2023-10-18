namespace AH.Primitives.Strings
{
    public static class ToFileUrlExtensions
    {
        /// <summary>
        /// Converts a raw filepath to a file url.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>The path converted to a file url, with delimiters normalized to /</returns>
        public static string ToFileUrl(this string path) => $"file:///{path.Replace("\\", "/")}";
    }
}