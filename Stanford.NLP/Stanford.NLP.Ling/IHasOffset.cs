using System.Runtime.Serialization;

namespace Stanford.NLP.Ling
{
    /// <summary>
    /// An item carrying <see cref="char"/> offset references to an original text <see cref="string"/>.
    /// </summary>
    public interface IHasOffset : ISerializable
    {
        /// <summary>
        /// The beginning <see cref="char"/> offset of the label (or -1 if none).
        /// </summary>
        /// <remarks>
        /// Note that these are currently measured in terms of UTF-16 char offsets, not codepoints,
        /// so that when non-BMP Unicode characters are present, such a character will add 2 to
        /// the position. On the other hand, these values will work with <see cref="string.Substring(int)"/> and
        /// you can then calculate the number of codepoints in a substring.
        /// </remarks>
        int BeginPosition { get; set; }

        /// <summary>
        /// The ending <see cref="char"/> offset of the label (or -1 if none).
        /// This is the offset of the <see cref="char"/> after this token.
        /// </summary>
        /// <remarks>
        /// Note that these are currently measured in terms of UTF-16 char offsets, not codepoints,
        /// so that when non-BMP Unicode characters are present, such a character will add 2 to
        /// the position. On the other hand, these values will work with <see cref="string.Substring(int)"/> and
        /// you can then calculate the number of codepoints in a substring.
        /// </remarks>
        int EndPosition { get; set; }
    }
}
