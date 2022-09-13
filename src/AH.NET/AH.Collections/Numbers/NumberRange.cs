using System;

namespace AH.Collections.Numbers
{
    public static class NumberRange
    {
        public enum BoundsInclusion
        {
            None,
            LowerOnly,
            UpperOnly,
            All,
        }

        public static bool IsBetween<T>(this T value, T minimum, T maximum, BoundsInclusion bounds = BoundsInclusion.All)
            where T : IComparable<T>
        {
            return bounds switch
            {
                BoundsInclusion.None => value.IsGreaterThan(minimum) && value.IsLessThan(maximum),
                BoundsInclusion.LowerOnly => value.IsGreaterThanOrEqualTo(minimum) && value.IsLessThan(maximum),
                BoundsInclusion.UpperOnly => value.IsGreaterThan(minimum) && value.IsLessThanOrEqualTo(maximum),
                BoundsInclusion.All => value.IsGreaterThanOrEqualTo(minimum) && value.IsLessThanOrEqualTo(maximum),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        public static bool IsLessThan<T>(this T value, T other) where T : IComparable<T> => value.CompareTo(other) < 0;
        public static bool IsGreaterThan<T>(this T value, T other) where T : IComparable<T> => value.CompareTo(other) > 0;
        public static bool IsLessThanOrEqualTo<T>(this T value, T other) where T : IComparable<T> => value.CompareTo(other) <= 0;
        public static bool IsGreaterThanOrEqualTo<T>(this T value, T other) where T : IComparable<T> => value.CompareTo(other) >= 0;
    }
}