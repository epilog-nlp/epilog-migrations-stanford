namespace Stanford.NLP.Ling
{
    /// <summary>
    /// An item with knowledge about words.
    /// </summary>
    public interface IHasWord
    {
        /// <summary>
        /// The word value of the label.
        /// </summary>
        string Word { get; set; }
    }
}
