using LokiCat.NET.Collections.Enumerables.Extensions;
using FluentAssertions;

namespace LokiCat.NET.Collections.Enumerables.Tests
{
    public class AggregateStringShould
    {
        [Fact]
        public void CombineStringsWithPassedDelimiter()
        {
            var collection = new[] { 1, 2, 3 };
            const string EXPECTED = "1:2:3";

            var actual = collection.AggregateString(":");

            actual.Should().Be(EXPECTED);

            actual = collection.AggregateString(':'); // Works with char inputs too
            actual.Should().Be(EXPECTED);
        }

        [Fact]
        public void UseCommasAsTheDefaultDelimiter()
        {
            var collection = new[] { 'a', 'b', 'c' };
            const string EXPECTED = "a,b,c";
            var actual = collection.AggregateString();

            actual.Should().Be(EXPECTED);
        }
    }
}