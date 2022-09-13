namespace AH.Collections.Chars
{
    public static class CharExtensions
    {
        /// <returns>
        /// True: character represents whitespace
        /// False: characters represents a printed glyph (i.e. not whitespace)
        /// </returns>
        public static bool IsWhitespace(this char character) => char.IsWhiteSpace(character);

        /// <returns>
        /// True: characters represents a printed glyph (i.e. not whitespace)
        /// False: character represents whitespace
        /// </returns>
        public static bool IsGlyph(this char character) => !character.IsWhitespace();
    }
}