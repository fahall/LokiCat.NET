using System;
using JetBrains.Annotations;

namespace LokiCat.NET.Collections.Exceptions
{
    /// <summary>
    /// Exception thrown when an operation is attempted on an empty collection
    /// </summary>

    // TODO: Write Tests to cover this function. 
    [PublicAPI]
    public class EmptyCollectionException : Exception
    {
        /// <summary>
        /// Exception thrown when an operation is attempted on an empty collection
        /// </summary>
        /// <param name="message"></param>
        public EmptyCollectionException(string message) : base(message) { }
    }
}