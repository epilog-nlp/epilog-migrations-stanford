namespace Stanford.NLP.Ling
{
    /// <summary>
    /// A Token able to produce Named Entity Recognition (NER) tags.
    /// </summary>
    public interface IHasNER
    {
        /// <summary>
        /// The named entity class of the label.
        /// </summary>
        string NERClass { get; set; }
    }
}
