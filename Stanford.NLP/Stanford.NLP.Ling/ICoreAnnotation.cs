namespace Stanford.NLP.Ling
{
    /// <summary>
    /// Marker interface for any annotation that can be marked on a <see cref="Util.ICoreMap"/>,
    /// parameterized by the type of the value associated with the annotation.
    /// </summary>
    /// <remarks>
    /// Subclasses of this interface are the keys in the <see cref="Util.ICoreMap"/>, so they are
    /// instantiated only by utility methods in <see cref="CoreAnnotations"/>.
    /// </remarks>
    /// <typeparam name="TValue">The <see cref="System.Type"/> of the value stored in the Map.</typeparam>
    public interface ICoreAnnotation<TValue> : Util.ITypesafeMapKey<TValue>
    {
    }
}
