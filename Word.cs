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
        /// The pinyin.
        /// </param>
        /// <param name="H">
        /// The hanzi.
        /// </param>
        /// <param name="M">
        /// The meaning.
        /// </param>
        /// <param name="PS">
        /// The part of speech.
        /// </param>
        /// <param name="F">
        /// The formality.
        /// </param>
        public Word(string P, string H, string M, string PS, string F)
        {
            this.Pinyin = P;
            this.Hanzi = H;
            this.Meaning = M;
            this.PartOfSpeech = PS;
            this.Formality = F;
        }

        /// <summary>
        /// Gets or sets the hanzi.
        /// </summary>
        public string Hanzi { get; set; }

        /// <summary>
        /// Gets or sets the pinyin.
        /// </summary>
        public string Pinyin { get; set; }

        /// <summary>
        /// Gets or sets the meaning.
        /// </summary>
        public string Meaning { get; set; }

        /// <summary>
        /// Gets or sets the part of speech.
        /// </summary>
        public string PartOfSpeech { get; set; }

        /// <summary>
        /// Gets or sets the formality.
        /// </summary>
        public string Formality { get; set; }
    }
}