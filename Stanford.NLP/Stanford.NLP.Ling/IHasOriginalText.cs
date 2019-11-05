namespace Stanford.NLP.Ling
{
    /// <summary>
    /// A Token able to produce/set original texts.
    /// </summary>
    public interface IHasOriginalText
    {
        /// <summary>
        /// The <see cref="string"/> which is the original character sequence of the token.
        /// </summary>
        string OriginalText { get; set; }
    }
}
