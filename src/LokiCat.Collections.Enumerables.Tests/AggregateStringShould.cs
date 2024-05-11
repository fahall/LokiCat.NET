using AH.Collections.Enumerables.Extensions;
using FluentAssertions;

namespace AH.Collections.Enumerables.Tests;

public class AggregateStringShould
{
    [Fact]
    public void CombineStringsWithPassedDelimiter()
    {
        var collection = new[] { 1, 2, 3 };
        var expected = "1:2:3";

        var actual = collection.AggregateString(":");

        actual.Should().Be(expected);

            
        actual = collection.AggregateString(':'); // Works with char inputs too
        actual.Should().Be(expected);

    }

    [Fact]
    public void UseCommasAsTheDefaultDelimiter()
    {
        var collection = new[] { 'a', 'b', 'c' };
        var expected = "a,b,c";
        var actual = collection.AggregateString();

        actual.Should().Be(expected);
    }
}