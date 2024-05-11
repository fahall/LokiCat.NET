using JetBrains.Annotations;

namespace AH.Collections.Enumerables.Extensions
{
    [PublicAPI]
    public static class AggregateStringExtension
    {
        /// <summary>
        /// Converts the contents of the enumerable to strings and combines them into a single string, with the passed delimiter
        /// </summary>
        /// <param name="items">Items to stringify</param>
        /// <param name="delimiter">Delimiter between items in output string</param>
        /// <returns>A string representation of the enumerable's contents.</returns>
        public static string AggregateString<T>(this IEnumerable<T> items, string delimiter = ",") => 
            items.Select(t => $"{t}")
                 .Aggregate((current, next) => $"{current}{delimiter}{next}");
        
        /// <inheritdoc cref="AggregateStringExtension.AggregateString{T}(IEnumerable{T}, char)"/>
        public static string AggregateString<T>(this IEnumerable<T> items, char delimiter) => 
            items.Select(t => $"{t}")
                 .Aggregate((current, next) => $"{current}{delimiter}{next}");
    }
}