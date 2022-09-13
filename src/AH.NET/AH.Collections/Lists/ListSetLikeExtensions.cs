using System.Collections.Generic;
using AH.Collections.Enumerables;

namespace AH.Collections.Lists
{
    public static class ListSetLikeExtensions
    {
        /// <summary>
        /// Pop item from the end of a list.
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The last item in the list.</returns>
        /// <exception cref="EmptyCollectionException">Cannot pop from an empty collection</exception>
        public static T PopFromEnd<T>(this IList<T> list)
        {
            if (list.Count == 0)
            {
                throw new EmptyCollectionException("Cannot pop from an empty collection");
            }

            var lastIndex = list.Count - 1;

            var result = list[lastIndex];
            list.RemoveAt(lastIndex);

            return result;
        }
    }
}