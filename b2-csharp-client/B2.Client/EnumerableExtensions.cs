using System.Collections.Generic;


namespace B2.Client
{
    /// <summary>
    /// Extension methods for easily constructing <see cref="IEnumerable{T}"/> instances from individual items.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Convert a single item into an <see cref="IEnumerable{T}"/> contaning that item only, if the item is non-null, or an empty
        /// <see cref="IEnumerable{T}"/> if the item is null.
        /// </summary>
        /// <param name="value">The item to convert into an <see cref="IEnumerable{T}"/>.</param>
        /// <typeparam name="T">The type of the item.</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> containing that item, or an empty <see cref="IEnumerable{T}"/> if the item was
        /// null.</returns>
        public static IEnumerable<T> Yield<T>(this T value)
        {
            if (value == null) {
                yield break;
            }
            yield return value;
        }

        /// <summary>
        /// Concatenate an arbitrary number of items into an <see cref="IEnumerable{T}"/> containing only the non-null items.
        /// </summary>
        /// <param name="value">The first item to enumerate over.</param>
        /// <param name="others">The remaining items to enumerate over.</param>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> contaning the non-null items.</returns>
        public static IEnumerable<T> ConcatWith<T>(this T value, params T[] others)
        {
            if (value != null) {
                yield return value;
            }
            foreach (var entry in others) {
                if (entry != null) {
                    yield return entry;
                }
            }
        }
    }
}