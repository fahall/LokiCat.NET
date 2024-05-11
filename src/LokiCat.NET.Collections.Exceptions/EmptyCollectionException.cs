using JetBrains.Annotations;

namespace LokiCat.NET.Collections.Exceptions;

[method: PublicAPI]
public class EmptyCollectionException(string message) : Exception(message)
{
    // TODO: Write Tests to cover this function. 
}