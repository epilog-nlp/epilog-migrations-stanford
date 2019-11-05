namespace Stanford.NLP.Ling
{
    /// <summary>
    /// An item with knowledge about its index.
    /// </summary>
    public interface IHasIndex
    {
        /// <summary>
        /// Identifier of the source Document.
        /// </summary>
        string DocumentId { get; set; }

        /// <summary>
        /// Sent index of the item.
        /// </summary>
        int SentIndex { get; set; }

        /// <summary>
        /// Index of the item.
        /// </summary>
        int Index { get; set; }
    }
}
