using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace kursovaya
{
    public partial class _DictionaryForm : Form
    {
         RadioButton RbEngRus { get; set; }
         RadioButton RbPolRus { get; set; }
         RadioButton RbRusEng { get; set; }
         RadioButton RbRusPol { get; set; }


        public _DictionaryForm( RadioButton rbEngRus, RadioButton rbPolRus,
            RadioButton rbRusEng, RadioButton rbRusPol)
        {
            RbEngRus = rbEngRus;
            RbPolRus = rbPolRus;
            RbRusEng = rbRusEng;
            RbRusPol = rbRusPol;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MainForm mainform = Owner as MainForm;
            PrintingDict();
        }

        private void PrintingDict()
        {
            List<string> keys = new List<string>();
            List<string> values = new List<string>();
            Dictionary<string, string> temp = new Dictionary<string, string>();
            string path = null;
            GetDictionary(temp, path, RbEngRus, RbRusEng, RbPolRus, RbRusPol);
            for (int i = 0; i < temp.Count; i++)
            {
                keys = temp.Keys.ToList();
                values = temp.Values.ToList();
            }
            richTextBox1.Text = string.Join("\n", keys.ToArray()).ToString();
            richTextBox2.Text = string.Join("\n", values.ToArray()).ToString();
        }

        private Dictionary<string, string> GetDictionary(Dictionary<string, string> temp, string path,
            RadioButton RbEngRus, RadioButton RbRusEng, RadioButton RbPolRus, RadioButton RbRusPol)
        {
            if (RbEngRus.Checked | RbRusEng.Checked)
            {
                path = @"..\..\engRus.txt";
            }
            if (RbPolRus.Checked | RbRusPol.Checked)
            {
                path = @"..\..\polRus.txt";
            }
            using (StreamReader sr = new StreamReader(path))
            {                
                string _line;
                while ((_line = sr.ReadLine()) != null)
                {
                    string[] keyvalue = _line.Split('-');
                    if (keyvalue.Length == 2)
                    {
                        temp.Add(keyvalue[0], keyvalue[1]);
                    }
                }
                temp = temp.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            }
            return temp;
        }

        private void BtnAddNewWord_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();
            string path = null;
            GetDictionary(temp, path, RbEngRus, RbRusEng, RbPolRus, RbRusPol);
            if (tbWordsIn.Text != "" && tbWordsOu.Text != "")
            {
                temp.Add(tbWordsIn.Text.ToLower(), tbWordsOu.Text.ToLower());
            }
            else
            {
                MessageBox.Show("Input the word!", "Warning");
            }
            temp = AddingWord(temp, path, RbEngRus, RbRusEng, RbPolRus, RbRusPol);
        }

        private Dictionary<string, string> AddingWord(Dictionary<string, string> temp, string path,
            RadioButton RbEngRus, RadioButton RbRusEng, RadioButton RbPolRus, RadioButton RbRusPol)
        {
            if (RbEngRus.Checked | RbRusEng.Checked)
            {
                path = @"..\..\engRus.txt";
            }
            if (RbPolRus.Checked | RbRusPol.Checked)
            {
                path = @"..\..\polRus.txt";
            }
            temp = temp.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
            File.WriteAllLines(path, temp.Select(x => x.Key + "-" + x.Value).ToArray());
            PrintingDict();
            return temp;
        }
        private void BtnRemoveWord_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();
            string path = null;
            if (RbEngRus.Checked | RbRusEng.Checked)
            {
                path = @"..\..\engRus.txt";
            }
            if (RbPolRus.Checked | RbRusPol.Checked)
            {
                path = @"..\..\polRus.txt";
            }
            temp = GetDictionary(temp, path, RbEngRus, RbRusEng, RbPolRus, RbRusPol);
            temp = RemovingWord(temp, path, RbEngRus, RbRusEng, RbRusPol, RbPolRus);
            temp = temp.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
            File.WriteAllLines(path, temp.Select(x => x.Key + "-" + x.Value).ToArray());
            PrintingDict();
        }
        private Dictionary<string, string> RemovingWord(Dictionary<string, string> temp, string path,
            RadioButton RbEngRus, RadioButton RbRusEng, RadioButton RbPolRus, RadioButton RbRusPol)
        {
            int firstcharindex = richTextBox1.GetFirstCharIndexOfCurrentLine();//индекс начала слова
            int currentline = richTextBox1.GetLineFromCharIndex(firstcharindex);//индекс строки
            string currentlinetext = richTextBox1.Lines[currentline];
            List<string> keysT = new List<string>();
            List<string> valuesT = new List<string>();

            foreach (var item in temp)
            {
                keysT.Add(item.Key);
                valuesT.Add(item.Value);
            }
            int index = 0;
            for (int i = 0; i < keysT.Count; i++)
            {
                if (keysT[i].Equals(currentlinetext))
                {
                    index = i;
                    keysT.Remove(keysT[i]);
                    valuesT.RemoveAt(index);
                }
                
            }
            Dictionary<string, string> newDict = new Dictionary<string, string>();
            if (keysT.Count == valuesT.Count)
            {
                for (int i = 0; i < keysT.Count; i++)
                {
                    newDict.Add(keysT[i], valuesT[i]);
                }
            }
            return newDict;
        }

        private void RbIwannaAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIwannaAdd.Checked)
            {
                btnAddNewWord.Visible = true;
                tbWordsIn.Visible = true;
                tbWordsOu.Visible = true;
                btnRemoveWord.Visible = false;
            }
        }

        private void RbIwannaDelete_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIwannaDelete.Checked)
            {
                btnAddNewWord.Visible = false;
                tbWordsIn.Visible = true;
                tbWordsOu.Visible = false;
                btnRemoveWord.Visible = true;
            }
        }

        private void RichTextBox1_MouseClick(object sender, MouseEventArgs e) 
        {
            //выделяет всю строку в richtextbox1
            int firstcharindex = richTextBox1.GetFirstCharIndexOfCurrentLine();//индекс начала слова
            int currentline = richTextBox1.GetLineFromCharIndex(firstcharindex);//индекс строки
            string currentlinetext = richTextBox1.Lines[currentline];
            richTextBox1.Select(firstcharindex, currentlinetext.Length + 1);

            richTextBox2.Focus();

            int _firstcharindex = richTextBox2.GetFirstCharIndexFromLine(currentline);//индекс начала слова
            string _currentlinetext = richTextBox2.Lines[currentline];
            richTextBox2.Select(_firstcharindex, _currentlinetext.Length + 1);                      
        }
    }
}
