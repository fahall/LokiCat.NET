using FluentAssertions;
using Xunit;

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
    public void NotDuplicateWhenPathsHaveSharedComponents(string left, string right, string expected)
    {
        left.MergePath(right).ToPathForCurrentPlatform().Should().Be(expected.ToPathForCurrentPlatform());
    }
}