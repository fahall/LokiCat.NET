using System;
using JetBrains.Annotations;

namespace AH.Collections.Essentials.Exceptions
{
    public class EmptyCollectionException : Exception
    {
        // TODO: Write Tests to cover this function. 
        [PublicAPI]
        public EmptyCollectionException(string message) : base(message) { }
    }
}