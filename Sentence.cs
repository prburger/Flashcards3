namespace v3
{
    /// <summary>
    /// The sentence class.
    /// </summary>
    public class Sentence
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sentence" /> class.
        /// </summary>
        public Sentence() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sentence" /> class.
        /// </summary>
        /// <param name="pinyin">
        /// The pinyin.
        /// </param>
        /// <param name="english">
        /// The English.
        /// </param>
        /// <param name="hanzi">
        /// The hanzi.
        /// </param>
        public Sentence(string pinyin, string english, string hanzi)
        {
            this.English = english;
            this.Pinyin = pinyin;
            this.Hanzi = hanzi;
        }

        /// <summary>
        /// Gets or sets the pinyin.
        /// </summary>
        public string Pinyin { get; set; }

        /// <summary>
        /// Gets or sets the English.
        /// </summary>
        public string English { get; set; }

        /// <summary>
        /// Gets or sets the hanzi.
        /// </summary>
        public string Hanzi { get; set; }
    }
}