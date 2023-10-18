﻿using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace AH.Collections.Enumerables
{
    public static class CombinationExtensions
    {
        [PublicAPI]
        public static IEnumerable<IEnumerable<T>> GetCombinations<T>(this IEnumerable<T> list,
            IEnumerable<int> lengths) where T : IComparable =>
            Collect(list, GetCombinationsWithDuplicates, lengths);

        [PublicAPI]
        public static IEnumerable<IEnumerable<T>> GetCombinationsUnique<T>(this IEnumerable<T> list,
            IEnumerable<int> lengths) where T : IComparable =>
            Collect(list, GetCombinationsUnique, lengths.Distinct());

        [PublicAPI]
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(this IEnumerable<T> list, IEnumerable<int> lengths) => Collect(list, GetPermutationsWithDuplicates, lengths);

        [PublicAPI]
        public static IEnumerable<IEnumerable<T>> GetPermutationsUnique<T>(this IEnumerable<T> list, IEnumerable<int> lengths) => Collect(list, GetPermutationsUnique, lengths.Distinct());

        private static IEnumerable<IEnumerable<T>> GetCombinationsWithDuplicates<T>(IEnumerable<T> enumerable,
            int combinationLength) where T : IComparable
        {
            var list = enumerable.ToArray();
            return combinationLength == 1
                ? list.Select(t => new[] { t })
                : GetCombinationsWithDuplicates(list, combinationLength - 1)
                    .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) >= 0),
                                (t1, t2) => t1.Concat(new[] { t2 }));
        }
        
        private static IEnumerable<IEnumerable<T>>
            GetCombinationsUnique<T>(IEnumerable<T> enumerable, int length) where T : IComparable
        {
            var list = enumerable.ToArray();

            if (length == 1)
            {
                return list.Select(t => new[] { t });
            }

            return GetCombinationsUnique(list, length - 1)
                .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) > 0),
                            (t1, t2) => t1.Concat(new[] { t2 }));
        }

        private static IEnumerable<IEnumerable<T>> GetPermutationsWithDuplicates<T>(IEnumerable<T> enumerable, int length)
        {
            var list = enumerable.ToArray();

            return length == 1
                ? list.Select(t => new[] { t })
                : GetPermutationsWithDuplicates(list, length - 1)
                    .SelectMany(t => list, (t1, t2) => t1.Concat(new[] { t2 }));
        }

        private static IEnumerable<IEnumerable<T>> GetPermutationsUnique<T>(IEnumerable<T> enumerable, int length)
        {
            var list = enumerable.ToArray();

            if (length == 1)
            {
                return list.Select(t => new[] { t });
            }

            return GetPermutationsWithDuplicates(list, length - 1)
                .SelectMany(t => list.Where(o => !t.Contains(o)),
                            (t1, t2) => t1.Concat(new[] { t2 }));
        }
        
        private static IEnumerable<IEnumerable<T>> Collect<T>(IEnumerable<T> items,
            Func<IEnumerable<T>, int, IEnumerable<IEnumerable<T>>> action, IEnumerable<int> lengths)
        {
            var list = items.ToArray();

            return lengths.Where(l => l > 0).Select(l => action.Invoke(list, l)).Flatten();
        }
    }
}