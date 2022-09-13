using System;
using JetBrains.Annotations;

namespace AH.Collections.Enumerables
{
    [PublicAPI]
    public class EmptyCollectionException : Exception
    {
        public EmptyCollectionException(string message) : base(message) { }
    }
}