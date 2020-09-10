using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace v3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Word> wordList = new List<Word>();
        private Word currentWord;
        private int currentIndex = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.ReadXml("wordlist.xml");            
            this.currentWord = this.wordList[this.currentIndex];
            this.wordListView.ItemsSource = this.wordList;
            this.SetData(this.currentWord);
        }

        /// <summary>
        /// Sets the data.
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
        }

        /// <summary>
        /// Reads the XML data.
        /// </summary>
        private void ReadXml(string fileName)
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

            for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
            {
                DataRow dr = ds.Tables[0].Rows[r];
                Word w = new Word();
                w.Pinyin = dr.ItemArray[0].ToString();
                w.Hanzi = dr.ItemArray[1].ToString();
                w.Meaning = new string[] { String.Join(",", dr.ItemArray[2]) };
                w.PartOfSpeech = new string[] { String.Join(",", dr.ItemArray[3]) };
                w.Formality = dr.ItemArray[4].ToString();
                wordList.Add(w);
            }

            List<Word> sortedList = wordList.OrderBy(w => w.Pinyin).ToList();
            wordList = sortedList;
            xmlReader.Close();
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
            else
            {
                this.currentIndex = this.wordList.Count;
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
    }
}