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

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.ReadXml("wordlist.xml");
        }

        /// <summary>
        /// Reads the xml data.
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
                w.Character = dr.ItemArray[1].ToString();
                w.Meaning = new string[] { String.Join(",", dr.ItemArray[2]) };
                w.PartOfSpeech = new string[] { String.Join(",", dr.ItemArray[3]) };
                w.Formality = dr.ItemArray[4].ToString();
                wordList.Add(w);
            }

            List<Word> sortedList = wordList.OrderBy(w => w.Pinyin).ToList();
            wordList = sortedList;
            /*this.bindingSource1.DataSource = ds.Tables[0];
            this.bindingNavigator1.BindingSource = this.bindingSource1;*/
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
        }
    }
}