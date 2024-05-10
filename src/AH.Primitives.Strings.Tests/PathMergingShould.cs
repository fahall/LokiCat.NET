using AH.Primitives.Strings.Extensions;
using FluentAssertions;

namespace AH.Primitives.Strings.Tests;

public class PathMergingShould
{
    [Theory]
    [InlineData("Left/Should", "Should/Right", "Left/Should/Right")]
    [InlineData("path/to/root/stuff/", "/stuff/that/is/relative", "path/to/root/stuff/that/is/relative")]
    [InlineData("/absolute/root", "relative/path", "/absolute/root/relative/path")]
    [InlineData("root", "child", "root/child")]
    [InlineData("/root", "/child", "/root/child")]
    [InlineData("path/without/trailing/slash", "child/without/leading/slash", "path/without/trailing/slash/child/without/leading/slash")]
    [InlineData("root/", "/child/", "root/child/")]
    [InlineData("root", "child/", "root/child/")]
    [InlineData("", "child", "child")]
    [InlineData("root", "", "root")]
    [InlineData("", "", "")]
    [InlineData("path/with/trailing/slash/", "child/with/leading/slash", "path/with/trailing/slash/child/with/leading/slash")]
    [InlineData("work/with/different/lengths/of/lengths", "/lengths/of/lengths/leaf", "work/with/different/lengths/of/lengths/leaf")]
    [InlineData("work", "/with/different/lengths/leaf", "work/with/different/lengths/leaf")]
    [InlineData(@"C:\WindowsPath\With\Absolute\Root", @"Absolute\Root\And\Leaf", @"C:\WindowsPath\With\Absolute\Root\And\Leaf")]
    [InlineData(@"C:/Users/FAHal/repos/charadium/src/Charadium/Assets", "Assets/App/Features/DebugConsole/Tests/DebugConsoleAlternateTestScene.unity", @"C:/Users/FAHal/repos/charadium/src/Charadium/Assets/App/Features/DebugConsole/Tests/DebugConsoleAlternateTestScene.unity")]
    public void NotDuplicateWhenPathsHaveSharedComponents(string left, string right, string expected)
    {
        left.ToWindowsPath().MergePath(right.ToWindowsPath()).Should().Be(expected.ToPathForCurrentPlatform(), "Windows paths should be merged correctly");
        left.ToUnixPath().MergePath(right.ToUnixPath()).ToPathForCurrentPlatform().Should().Be(expected.ToPathForCurrentPlatform(), "Unix paths should be merged correctly");
    }
}