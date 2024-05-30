using FluentAssertions;
using LokiCat.NET.Primitives.Strings.FilePaths;

namespace LokiCat.NET.Primitives.Strings.Tests
{
    public class FilePathExtensionsShould
    {
        [Theory]
        [InlineData(@"C:\Users\user\Documents\file.txt", "C:/Users/user/Documents/file.txt")]
        [InlineData(@"D:\Program Files\Project\file.txt", "D:/Program Files/Project/file.txt")]
        [InlineData(@"E:\Photos\2022\image.jpg", "E:/Photos/2022/image.jpg")]
        [InlineData(@"F:\Projects\Code\app\source\Main.cs", "F:/Projects/Code/app/source/Main.cs")]
        [InlineData(@"relative\path\to\file.txt", "relative/path/to/file.txt")]
        [InlineData(@"D:/Documents\file.txt", "D:/Documents/file.txt")] // Already using forward slash
        [InlineData(@"folder1\folder2\file.txt", "folder1/folder2/file.txt")]
        [InlineData("folder1/folder2/file.txt", "folder1/folder2/file.txt")] // Already using forward slash
        [InlineData("/root", "/root")] // Correct Slash at beginning
        [InlineData("root/", "root/")] // Correct Slash at end
        [InlineData(@"\root", "/root")] // Slash at beginning
        [InlineData(@"root\", "root/")] // Slash at end
        public void ConvertToUnixPath(string input, string expected)
        {
            input.ToUnixPath().Should().Be(expected);
        }

        [Theory]
        [InlineData("C:/Users/user/Documents/file.txt", @"C:\Users\user\Documents\file.txt")]
        [InlineData("D:/Program Files/Project/file.txt", @"D:\Program Files\Project\file.txt")]
        [InlineData("E:/Photos/2022/image.jpg", @"E:\Photos\2022\image.jpg")]
        [InlineData("F:/Projects/Code/app/source/Main.cs", @"F:\Projects\Code\app\source\Main.cs")]
        [InlineData("relative/path/to/file.txt", @"relative\path\to\file.txt")]
        [InlineData(@"D:\Documents\file.txt", @"D:\Documents\file.txt")] // Already using backslash
        [InlineData("folder1/folder2/file.txt", @"folder1\folder2\file.txt")]
        [InlineData(@"folder1\folder2\file.txt", @"folder1\folder2\file.txt")] // Already using backslash
        [InlineData("/root", @"\root")] // Slash at beginning
        [InlineData("root/", @"root\")] // Slash at end
        [InlineData(@"\root", @"\root")] // Correct Slash at beginning
        [InlineData(@"root\", @"root\")] // Correct Slash at end
        public void ConvertToWindowsPath(string input, string expected)
        {
            input.ToWindowsPath().Should().Be(expected);
        }

        [Theory]
        [InlineData(@"C:\Users\user\Documents\file.txt", @"C:\Users\user\Documents\file.txt")]
        [InlineData("C:/Users/user/Documents/file.txt", @"C:\Users\user\Documents\file.txt")]
        [InlineData(@"D:\Program Files/Project\file.txt", @"D:\Program Files\Project\file.txt")]
        [InlineData(@"E:/Photos\2022/image.jpg", @"E:\Photos\2022\image.jpg")]
        [InlineData(@"relative\path/to/file.txt", @"relative\path\to\file.txt")]
        [InlineData("D:/Documents/file.txt", @"D:\Documents\file.txt")]
        [InlineData("folder1/folder2/file.txt", @"folder1\folder2\file.txt")]
        [InlineData(@"folder1\folder2\file.txt", @"folder1\folder2\file.txt")]
        public void ConvertToPathForCurrentPlatform(string input, string expected)
        {
            var actual = input.ToPathForCurrentPlatform();

            // Dynamically adjust the expected value based on the current platform
            var expectedOnCurrentPlatform = expected
                                            .Replace('\\', Path.DirectorySeparatorChar)
                                            .Replace('/', Path.DirectorySeparatorChar);

            actual.Should().Be(expectedOnCurrentPlatform);
        }
    }
}