using JetBrains.Annotations;

namespace LokiCat.NET.Collections.Exceptions;

/// <summary>
/// Exception thrown when an operation is attempted on an empty collection
/// </summary>
/// <param name="message"></param>
// TODO: Write Tests to cover this function. 
[PublicAPI]
public class EmptyCollectionException(string message) : Exception(message);