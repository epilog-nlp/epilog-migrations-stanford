using System;
using System.Runtime.Serialization;

namespace Stanford.NLP.Util
{
    /// <summary>
    /// Base Type for all annotatable core objects. Should usually be instantiated as <see cref="ArrayCoreMap"/>.
    /// </summary>
    /// <remarks>
    /// Note that implementations of this interface must take care to implement
    /// equality correctly: by default, two CoreMaps are.equal if they contain the
    /// same keys and all corresponding values are.equal.Subclasses that wish to
    /// change this behavior (such as { @link HashableCoreMap}) must make sure that
    /// all other CoreMap implementations have a special case in their.equals to use
    /// that equality definition when appropriate.Similarly, care must be taken when
    /// defining hashcodes.The default hashcode is 37 * sum of all keys' hashcodes
    /// plus the sum of all values' hashcodes. However, use of this class as HashMap
    /// keys is discouraged because the hashcode can change over time. Consider using
    /// a <see cref="HashableCoreMap"/>.
    /// </remarks>
    public interface ICoreMap : ITypesafeMap, ISerializable
    {
        /// <summary>
        /// Attempt to provide a briefer and more human readable <see cref="string"/> for the contents of a <see cref="ICoreMap"/>.
        /// </summary>
        /// <remarks>
        /// The method may not be capable of printing circular dependencies in CoreMaps.
        /// </remarks>
        /// <param name="keys">The annotation keys to print. Keys are identified by the short <see cref="Type"/> Name.</param>
        /// <returns>A more human readable <see cref="string"/> giving possibly partial contents of a <see cref="ICoreMap"/>.</returns>
        string ToShorterString(params string[] keys);

    }
}
