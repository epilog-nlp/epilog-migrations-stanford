namespace Stanford.NLP.Ling
{
    /// <summary>
    /// An abstract token.
    /// </summary>
    /// <remarks>
    /// Joins all the natural token-like interfaces, like <see cref="IHasWord"/>, <see cref="IHasLemma"/>, etc.
    /// </remarks>
    public interface IAbstractToken : IHasWord, IHasIndex, IHasTag, IHasLemma, IHasNER, IHasOffset, IHasOriginalText, IHasContext
    {
    }
}
