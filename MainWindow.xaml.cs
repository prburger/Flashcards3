using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml;

namespace v3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Word> wordList = new List<Word>();
        private List<Sentence> sentenceList = new List<Sentence>();
        private Word currentWord;
        private int currentIndex = 0;
        private int WordPageLength = 10;
        private int WordPage = 1;
        private int SentencePageLength = 10;
        private int SentencePage = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.wordList = ReadWordData("wordlist.xml");
            this.currentWord = wordList[this.currentIndex];
            this.WordView.ItemsSource = wordList;
            this.SentenceView.ItemsSource = ReadSentenceData("sentences.xml");
            this.SetData(this.currentWord);
        }

        /// <summary>
        /// Gets the data set.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <returns>
        /// A DataSet.
        /// </returns>
        private DataSet GetDataSet(string fileName)
        {
            XmlTextReader xmlReader;
            xmlReader = new XmlTextReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\assets", fileName));

            DataSet ds = new DataSet();

            //read the XML data
            try
            {
                ds.ReadXml(xmlReader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            xmlReader.Close();
            return ds;
        }

        /// <summary>
        /// Reads the sentence data.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <returns>
        /// A list of Sentences.
        /// </returns>
        private List<Sentence> ReadSentenceData(string fileName)
        {
            DataSet ds = this.GetDataSet(fileName);
            List<Sentence> list = new List<Sentence>();
            for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
            {
                DataRow dr = ds.Tables[0].Rows[r];
                Sentence s = new Sentence();
                s.Hanzi = dr.ItemArray[0].ToString();
                s.Pinyin = dr.ItemArray[1].ToString();
                s.English = dr.ItemArray[2].ToString();
                list.Add(s);
            }

            List<Sentence> sortedList = list.OrderBy(w => w.English).ToList();
            return sortedList;
        }

        /// <summary>
        /// Sets the current word data.
        /// </summary>
        private void SetData(Word word)
        {
            Text_Pinyin.Text = word.Pinyin;
            Text_Hanzi.Text = word.Hanzi;
            Text_Formality.Text = word.Formality;
            Text_English.Text = "";
            Text_PartOfSpeech.Text = "";

            foreach (var m in word.Meaning)
            {
                if (word.Meaning.Length > 1)
                {
                    Text_English.Text += m + "; ";
                }
                else
                {
                    Text_English.Text = m;
                }
            };

            foreach (var p in word.PartOfSpeech)
            {
                if (word.PartOfSpeech.Length > 1)
                {
                    Text_PartOfSpeech.Text += p + "; ";
                }
                else
                {
                    Text_PartOfSpeech.Text = p;
                }
            };
            SetPageCounts();
        }

        /// <summary>
        /// Sets the page counts.
        /// </summary>
        private void SetPageCounts()
        {
            this.WordCount.Content = String.Format("{0}/{1}", this.currentIndex, this.wordList.Count - 1);
            int pageCount = this.wordList.Count / this.WordPageLength;
            this.WordPageCount.Content = String.Format("{0}/{1}", this.WordPage, pageCount);

            pageCount = 1 + (this.SentenceView.Items.Count / this.SentencePageLength);
            this.SentenceCount.Content = String.Format("{0}/{1} ", this.SentencePage, pageCount);
        }

        /// <summary>
        /// Reads the word XML data.
        /// </summary>
        private List<Word> ReadWordData(string fileName)
        {
            DataSet ds = this.GetDataSet(fileName);
            List<Word> list = new List<Word>();
            for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
            {
                DataRow dr = ds.Tables[0].Rows[r];
                Word w = new Word();
                w.Pinyin = dr.ItemArray[0].ToString();
                w.Hanzi = dr.ItemArray[1].ToString();
                w.Meaning = new string[] { String.Join(",", dr.ItemArray[2]) };
                w.PartOfSpeech = new string[] { String.Join(",", dr.ItemArray[3]) };
                w.Formality = dr.ItemArray[4].ToString();
                list.Add(w);
            }
            List<Word> sortedList = list.OrderBy(w => w.Pinyin).ToList();
            return sortedList;
        }

        /// <summary>
        /// Checks the pinyin_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Check_Pinyin_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Checks the english_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Check_English_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Checks the hanzi_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Check_Hanzi_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Checks the part of speech_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Check_PartOfSpeech_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Checks the formality_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Check_Formality_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// First_word clicked.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void FirstWord_Click(object sender, RoutedEventArgs e)
        {
            this.currentIndex = 0;
            this.currentWord = this.wordList[this.currentIndex];
            this.SetData(this.currentWord);
        }

        /// <summary>
        /// Previous_word clicked.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void PreviousWord_Click(object sender, RoutedEventArgs e)
        {
            if (this.currentIndex > 0)
            {
                this.currentIndex--;
            }
            else
            {
                this.currentIndex = 0;
            }

            this.currentWord = this.wordList[this.currentIndex];
            this.SetData(this.currentWord);
        }

        /// <summary>
        /// Next_word clicked.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void NextWord_Click(object sender, RoutedEventArgs e)
        {
            if (this.currentIndex < this.wordList.Count - 1)
            {
                this.currentIndex++;
            }
            this.currentWord = this.wordList[this.currentIndex];
            this.SetData(this.currentWord);
        }

        /// <summary>
        /// Last_word clicked.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void LastWord_Click(object sender, RoutedEventArgs e)
        {
            this.currentIndex = this.wordList.Count - 1;
            this.currentWord = this.wordList[this.currentIndex];
            this.SetData(this.currentWord);
        }

        /// <summary>
        /// move to the First page of sentences.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void FirstPageSentence_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// move to the Previous page of sentences.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void PreviousPageSentence_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// move to the Next page of sentences.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void NextPageSentence_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// move to the Last page of sentences.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void LastPageSentence_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// move to the First page of words.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void FirstPageWord_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// move to the Previous page of words.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void PreviousPageWord_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// move to the Next page of words.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void NextPageWord_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// move to the Last page of words.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void LastPageWord_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}