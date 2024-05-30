using System;
using JetBrains.Annotations;

namespace LokiCat.NET.GuardClauses
{
    /// <summary>
    /// A utility class for guarding against common programming errors.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the specified argument is null.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="argument">The argument to check.</param>
        /// <param name="argumentName">The name of the argument (optional).</param>
        /// <exception cref="ArgumentNullException">Thrown if the specified argument is null.</exception>
        [PublicAPI]
        public static void AgainstNull<T>(T argument, string argumentName = "")
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        /// <summary>
        /// Throws an <see cref="Exception"/> if the specified predicate evaluates to true for the argument.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="predicate">The predicate to apply to the argument.</param>
        /// <param name="argument">The argument to check.</param>
        /// <param name="argumentName">The name of the argument (optional).</param>
        /// <exception cref="ArgumentNullException">Thrown if the specified predicate is null.</exception>
        /// <exception cref="Exception">Thrown if the specified predicate evaluates to true for the argument.</exception>
        [PublicAPI]
        public static void Against<T>(Func<T, bool> predicate, T argument, string argumentName = "")
        {
            AgainstNull(predicate, nameof(predicate));

            if (predicate(argument))
            {
                throw new GuardException(argumentName);
            }
        }
    }
}