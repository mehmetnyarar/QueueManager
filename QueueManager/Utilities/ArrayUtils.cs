using System;

namespace QueueManager.Utilities
{
    /// <summary>
    /// Provides utilities for arrays.
    /// </summary>
    public static class ArrayUtils
    {
        /// <summary>
        /// Determines whether an array is null or empty.
        /// </summary>
        /// <returns><c>true</c>, if the array is null or empty, <c>false</c> otherwise.</returns>
        /// <param name="source">Source array.</param>
        public static bool IsNullOrEmpty<T>(this T[] source)
        {
            return source == null || source.Length == 0;
        }

        /// <summary>
        /// Determines whether a string value exists in the array or not.
        /// </summary>
        /// <returns><c>true</c>, if the value exists in the array, <c>false</c> otherwise.</returns>
        /// <param name="source">Source array.</param>
        /// <param name="value">Value to find.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static bool Contains<T>(this T[] source, string value)
        {
            return Array.IndexOf(source, value) != -1;
        }

        /// <summary>
        /// Adds new item to an array.
        /// </summary>
        /// <returns>Array.</returns>
        /// <param name="source">Source array.</param>
        /// <param name="item">Item to be added.</param>
        /// <typeparam name="T">Object.</typeparam>
        public static T[] AddOne<T>(this T[] source, T item)
        {
            // Create a new array if not defined
            if (source == null)
            {
                source = new T[] {};
            }

            // Copy existing items
            T[] result = new T[source.Length + 1];
            source.CopyTo(result, 0);

            // Add new item
            result[source.Length] = item;

            // Return the result
            return result;
        }

        /// <summary>
        /// Adds many items to an array at once.
        /// </summary>
        /// <returns>Array.</returns>
        /// <param name="source">Source array.</param>
        /// <param name="items">Items to be added.</param>
        /// <typeparam name="T">Object.</typeparam>
        public static T[] AddMany<T>(this T[] source, T[] items)
        {
            // Create a new array if not defined
            if (source == null)
            {
                source = new T[] { };
            }

            // Copy existing items
            T[] result = new T[source.Length + items.Length];
            source.CopyTo(result, 0);

            // Add new items
            items.CopyTo(result, source.Length);

            // Return the result
            return result;
        }

        /// <summary>
        /// Removes item from an array.
        /// </summary>
        /// <returns>Array.</returns>
        /// <param name="source">Source array.</param>
        /// <param name="item">Item to be removed.</param>
        /// <typeparam name="T">Object.</typeparam>
        public static T[] Remove<T>(this T[] source, T item)
        {
            // Find the index of the item
            var index = Array.IndexOf(source, item);

            // Create a new array
            T[] result = new T[source.Length - 1];

            // Copy existing items except the one
            // which needs to be deleted
            int i = 0;
            int j = 0;
            while (i < source.Length)
            {
                if (i != index)
                {
                    result[j] = source[i];
                    j++;
                }
                i++;
            }

            // Return the result
            return result;
        }

        /// <summary>
        /// Returns a string representation of an array.
        /// </summary>
        /// <returns>Array as string.</returns>
        /// <param name="source">Source array.</param>
        /// <param name="take">Number of items to include in the result (-1: to include all items).</param>
        /// <param name="separator">Separator.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static string Join<T>(this T[] source, int take = -1, char separator = ',')
        {
            // Determine the size of the array
            var length = take == -1 ? source.Length : take;
            var target = new T[length];

            // Copy items to new array
            Array.Copy(source, target, length);

            // Return the result
            return string.Join(Convert.ToString(separator), target);
        }
    }
}
