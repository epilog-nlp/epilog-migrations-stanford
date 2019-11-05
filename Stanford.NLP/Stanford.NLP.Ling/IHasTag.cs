namespace Stanford.NLP.Ling
{
    /// <summary>
    /// An item with knowledge about Part-of-Speech tags.
    /// </summary>
    public interface IHasTag
    {
        /// <summary>
        /// The tag value of the label.
        /// </summary>
        string Tag { get; set; }
    }
}
