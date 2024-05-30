using System;
using JetBrains.Annotations;

namespace LokiCat.NET.Primitives.Numbers.Extensions
{
    /// <summary>
    /// Extensions for working with number ranges.
    /// </summary>
    public static class NumberRange
    {
        /// <summary>
        /// Mathematical Bounds Inclusion Type
        /// </summary>
        [PublicAPI]
        public enum BoundsInclusion
        {
            /// <summary>
            /// Exclude Both Bounds
            /// </summary>
            None,

            /// <summary>
            /// Include the lower bound, exclude the upper bound.
            /// </summary>
            LowerOnly,

            /// <summary>
            /// Include the upper bound, exclude the lower bound.
            /// </summary>
            UpperOnly,

            /// <summary>
            /// Include Both Bounds
            /// </summary>
            All,
        }

        /// <summary>
        /// Determines whether the value is between the passed minimum and maximum values.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <param name="bounds">The bounds inclusion type.</param>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <returns>True if the value is between the minimum and maximum values; otherwise, false.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Unknown <see cref="BoundsInclusion"/> value.</exception>

        // TODO: Write Tests to cover this function. 
        [PublicAPI]
        public static bool IsBetween<T>(this T value, T minimum, T maximum,
            BoundsInclusion bounds = BoundsInclusion.All)
            where T : IComparable<T>
        {
            switch (bounds)
            {
                case BoundsInclusion.None:
                    return value.IsGreaterThan(minimum) && value.IsLessThan(maximum);

                case BoundsInclusion.LowerOnly:
                    return value.IsGreaterThanOrEqualTo(minimum) && value.IsLessThan(maximum);

                case BoundsInclusion.UpperOnly:
                    return value.IsGreaterThan(minimum) && value.IsLessThanOrEqualTo(maximum);

                case BoundsInclusion.All:
                    return value.IsGreaterThanOrEqualTo(minimum) && value.IsLessThanOrEqualTo(maximum);

                default:
                    throw new ArgumentOutOfRangeException(nameof(bounds), $"Unknown {nameof(BoundsInclusion)} value.");
            }
        }

        /// <summary>
        /// Fluent check if the value is less than the other value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="other">The other value to compare.</param>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <returns> True if the value is less than the other value; otherwise, false.</returns>

        // TODO: Write Tests to cover this function. 
        [PublicAPI]
        public static bool IsLessThan<T>(this T value, T other) where T : IComparable<T> => value.CompareTo(other) < 0;

        /// <summary>
        /// Fluent check if the value is greater than the other value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="other">The other value to compare.</param>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <returns></returns>

        // TODO: Write Tests to cover this function. 
        [PublicAPI]
        public static bool IsGreaterThan<T>(this T value, T other) where T : IComparable<T> =>
            value.CompareTo(other) > 0;

        /// <summary>
        /// Fluent check if the value is less than or equal to the other value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="other">The other value to compare.</param>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <returns>True if the value is less than or equal to the other value; otherwise, false.</returns>

        // TODO: Write Tests to cover this function. 
        [PublicAPI]
        public static bool IsLessThanOrEqualTo<T>(this T value, T other) where T : IComparable<T> =>
            value.CompareTo(other) <= 0;

        /// <summary>
        /// Fluent check if the value is greater than or equal to the other value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="other">The other value to compare.</param>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <returns>True if the value is greater than or equal to the other value; otherwise, false.</returns>

        // TODO: Write Tests to cover this function. 
        [PublicAPI]
        public static bool IsGreaterThanOrEqualTo<T>(this T value, T other) where T : IComparable<T> =>
            value.CompareTo(other) >= 0;
    }
}