using System.Runtime.Serialization;

namespace Stanford.NLP.Ling
{
    /// <summary>
    /// An item with knowledge about Lemmas.
    /// </summary>
    public interface IHasLemma : ISerializable
    {
        /// <summary>
        /// The Lemma value of the label.
        /// </summary>
        string Lemma { get; set; }
    }
}
