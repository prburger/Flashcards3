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
        private List<Word> WordList = new List<Word>();
        private List<Sentence> SentenceList = new List<Sentence>();
        private Word CurrentWord;
        private int CurrentIndex = 0;
        private int WordPageLength = 15;
        private int MaxPageLength = 15;
        private int WordPage = 1;
        private int SentencePageLength = 15;
        private int SentencePage = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            WordList = ReadWordData("wordlist.xml");
            SentenceList = ReadSentenceData("sentences.xml");
            this.SetData();
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
        private void SetData()
        {
            CurrentWord = WordList[CurrentIndex];
            WordView.ItemsSource = WordList;
            Text_Pinyin.Text = CurrentWord.Pinyin;
            Text_Hanzi.Text = CurrentWord.Hanzi;
            Text_Formality.Text = CurrentWord.Formality;
            Text_English.Text = CurrentWord.Meaning;
            Text_PartOfSpeech.Text = CurrentWord.PartOfSpeech;
            SetPageCounts();
            this.FirstPageSentence_Click(null, null);
            this.FirstPageWord_Click(null, null);
        }

        /// <summary>
        /// Sets the page counts.
        /// </summary>
        private void SetPageCounts()
        {
            this.WordCount.Content = String.Format("{0}/{1}", CurrentIndex, WordList.Count - 1);
            int pageCount = WordList.Count / this.WordPageLength;
            this.WordPageCount.Content = String.Format("{0}/{1}", this.WordPage + 1, pageCount);
            pageCount = this.SentenceView.Items.Count / this.SentencePageLength;
            this.SentenceCount.Content = String.Format("{0}/{1} ", this.SentencePage + 1, pageCount);
            if (SentenceList.Count < MaxPageLength)
            {
                SentencePageLength = SentenceList.Count;
            }
            else
            {
                SentencePageLength = MaxPageLength;
            }
            if (SentenceList.Count < MaxPageLength)
            {
                SentencePageLength = SentenceList.Count;
            }
            else
            {
                SentencePageLength = MaxPageLength;
            }
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
                w.Meaning = dr.ItemArray[2].ToString();
                w.PartOfSpeech = dr.ItemArray[3].ToString();
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
            CurrentIndex = 0;
            CurrentWord = WordList[CurrentIndex];
            this.SetData();
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
            if (CurrentIndex > 0)
            {
                CurrentIndex--;
            }
            else
            {
                CurrentIndex = 0;
            }

            CurrentWord = WordList[CurrentIndex];
            this.SetData();
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
            if (CurrentIndex < WordList.Count - 1)
            {
                CurrentIndex++;
            }
            CurrentWord = WordList[CurrentIndex];
            this.SetData();
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
            CurrentIndex = WordList.Count - 1;
            CurrentWord = WordList[CurrentIndex];
            this.SetData();
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
            SentencePage = 0;
            SentenceView.ItemsSource = SentenceList.GetRange(SentencePage * SentencePageLength, SentencePageLength);
            this.SetPageCounts();
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
            if (SentencePage > 0)
            {
                SentencePage--;
            }
            SentenceView.ItemsSource = SentenceList.GetRange(SentencePage * SentencePageLength, SentencePageLength);
            this.SetPageCounts();
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
            if (SentencePage < (SentenceList.Count / SentencePageLength) - 1)
            {
                SentencePage++;
            }
            SentenceView.ItemsSource = SentenceList.GetRange(SentencePage * SentencePageLength, SentencePageLength);
            this.SetPageCounts();
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
            SentencePage = (SentenceList.Count / SentencePageLength);
            SentenceView.ItemsSource = SentenceList.GetRange(SentencePage * SentencePageLength, SentencePageLength);
            this.SetPageCounts();
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
            WordPage = 0;
            WordView.ItemsSource = WordList.GetRange(WordPage * WordPageLength, WordPageLength);
            this.SetPageCounts();
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
            if (WordPage > 0)
            {
                WordPage--;
            }
            WordView.ItemsSource = WordList.GetRange(WordPage * WordPageLength, WordPageLength);
            this.SetPageCounts();
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
            if (WordPage < WordList.Count / WordPageLength)
            {
                WordPage++;
            }
            this.WordView.ItemsSource = WordList.GetRange(WordPage * WordPageLength, WordPageLength);
            this.SetPageCounts();
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
            WordPage = WordList.Count / WordPageLength;
            this.WordView.ItemsSource = WordList.GetRange(WordPage * WordPageLength, WordPageLength);
            this.SetPageCounts();
        }
    }
}