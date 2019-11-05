namespace Stanford.NLP.Ling
{
    /// <summary>
    /// An item with knowledge about its context.
    /// </summary>
    public interface IHasContext : IHasOriginalText
    {
        /// <summary>
        /// The whitespace <see cref="string"/> before the word.
        /// </summary>
        string Before { get; set; }

        /// <summary>
        /// The whitespace <see cref="string"/> after the word.
        /// </summary>
        string After { get; set; }
    }
}
