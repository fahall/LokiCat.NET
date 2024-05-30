using System;

namespace LokiCat.NET.GuardClauses
{
    /// <summary>
    /// Custom exception class used by the Guard class.
    /// </summary>
    internal class GuardException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuardException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message.</param>
        public GuardException(string message) : base(message) { }
    }
}