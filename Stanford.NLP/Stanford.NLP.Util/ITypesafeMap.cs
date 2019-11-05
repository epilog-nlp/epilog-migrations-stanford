using System;
using System.Collections.Generic;

namespace Stanford.NLP.Util
{
    /// <summary>
    /// Type signature for a class that supports the basic operations required
    /// of a typesafe heterogenous map.
    /// </summary>
    public interface ITypesafeMap
    {

        /// <summary>
        /// Returns the value associated with the <see cref="Type"/> of the provided <typeparamref name="TKey"/>.
        /// </summary>
        /// <typeparam name="TKey">The <see cref="Type"/> implementing <see cref="ITypesafeMapKey{TValue}"/> serving as the Map key.</typeparam>
        /// <typeparam name="TValue">The <see cref="Type"/> of the value associated with the provided <typeparamref name="TKey"/>.</typeparam>
        /// <returns></returns>
        TValue GetValue<TKey, TValue>() where TKey : ITypesafeMapKey<TValue>;

        /// <summary>
        /// Associates the given <paramref name="value"/> with the <see cref="Type"/> of the provided <typeparamref name="TKey"/>.
        /// </summary>
        /// <typeparam name="TKey">The <see cref="Type"/> implementing <see cref="ITypesafeMapKey{TValue}"/> serving as the Map key.</typeparam>
        /// <typeparam name="TValue">The <see cref="Type"/> of the value associated with the provided <typeparamref name="TKey"/>.</typeparam>
        /// <param name="value">The value to associate.</param>
        /// <returns>The old, removed, value or null if no value was present.</returns>
        TValue SetValue<TKey, TValue>(TValue value) where TKey : ITypesafeMapKey<TValue>;

        /// <summary>
        /// Removes the given <typeparamref name="TKey"/> from the Map, returning the value removed.
        /// </summary>
        /// <typeparam name="TKey">The <see cref="Type"/> implementing <see cref="ITypesafeMapKey{TValue}"/> serving as the Map key.</typeparam>
        /// <typeparam name="TValue">The <see cref="Type"/> of the value associated with the provided <typeparamref name="TKey"/>.</typeparam>
        /// <returns>The removed value or null if no value was present.</returns>
        TValue Remove<TKey, TValue>() where TKey : ITypesafeMapKey<TValue>;

        /// <summary>
        /// Collection of keys currently held in this Map.
        /// </summary>
        /// <remarks>
        /// Some implementations may have the returned set be immutable.
        /// </remarks>
        ISet<Type> Keys { get; }

        /// <summary>
        /// Returns <c>true</c> if the Map contains the given <typeparamref name="TKey"/>. 
        /// </summary>
        /// <typeparam name="TKey">The <see cref="Type"/> implementing <see cref="ITypesafeMapKey{TValue}"/> serving as the Map key.</typeparam>
        /// <typeparam name="TValue">The <see cref="Type"/> of the value associated with the provided <typeparamref name="TKey"/>.</typeparam>
        /// <returns><c>true</c> if the Map contains <typeparamref name="TKey"/>.</returns>
        bool ContainsKey<TKey, TValue>() where TKey : ITypesafeMapKey<TValue>;

        /// <summary>
        /// The number of keys in the Map.
        /// </summary>
        int Size { get; }
    }

    /// <summary>
    /// Base type of keys for the <see cref="ITypesafeMap"/>.
    /// The <see cref="Type"/> of the implementing classes are the keys themselves - not instances of those classes.
    /// </summary>
    /// <typeparam name="TValue">The <see cref="Type"/> of the value associated with this key.</typeparam>
    public interface ITypesafeMapKey<TValue> { }
}
