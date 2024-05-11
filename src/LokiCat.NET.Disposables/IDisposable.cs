using JetBrains.Annotations;

namespace LokiCat.NET.Disposables;

/// <summary>
/// A Wrapper for simple classes to make them disposable
/// </summary>
/// <remarks>
/// Use this for classes that do not have their own <see cref="IDisposable"/> implementation when you need to customize their dispose behavior.
/// </remarks>
/// <typeparam name="T">The data type.</typeparam>
[PublicAPI]
public interface IDisposable<out T> : IDisposable
{
    public T Value { get; }
}