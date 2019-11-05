namespace Stanford.NLP.Ling
{
    /// <summary>
    /// An item with knowledge about Categories.
    /// </summary>
    public interface IHasCategory
    {
        /// <summary>
        /// The category value of the label.
        /// </summary>
        string Category { get; set; }
    }
}
