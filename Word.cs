namespace v3
{
    /// <summary>
    /// The word.
    /// </summary>

    public class Word
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Word" /> class.
        /// </summary>
        public Word() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Word" /> class.
        /// </summary>
        /// <param name="P">
        /// The p.
        /// </param>
        /// <param name="C">
        /// The c.
        /// </param>
        /// <param name="M">
        /// The m.
        /// </param>
        /// <param name="PS">
        /// The p s.
        /// </param>
        /// <param name="F">
        /// The f.
        /// </param>
        public Word(string P, string C, string[] M, string[] PS, string F)
        {
            this.Pinyin = P;
            this.Character = C;
            this.Meaning = M;
            this.PartOfSpeech = PS;
            this.Formality = F;
        }

        /// <summary>
        /// Gets or sets the pinyin.
        /// </summary>
        public string Pinyin { get; set; }

        /// <summary>
        /// Gets or sets the character.
        /// </summary>
        public string Character { get; set; }

        /// <summary>
        /// Gets or sets the meaning.
        /// </summary>
        public string[] Meaning { get; set; }

        /// <summary>
        /// Gets or sets the part of speech.
        /// </summary>
        public string[] PartOfSpeech { get; set; }

        /// <summary>
        /// Gets or sets the formality.
        /// </summary>
        public string Formality { get; set; }
    }
}