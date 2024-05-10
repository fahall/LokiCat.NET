using System;

namespace AH.Disposables
{
    /// <summary>
    /// A Wrapper for simple classes to make them disposable
    /// </summary>
    /// <remarks>
    /// Use this for classes like <see cref="UnityEngine.Sprite"/> that do not have their own <see cref="IDisposable"/> implementation when you need to customize their dispose behavior.
    /// </remarks>
    /// <typeparam name="T">The data type.</typeparam>
    public interface IDisposable<T> : IDisposable
    {
        public T Value { get; }
    }
}