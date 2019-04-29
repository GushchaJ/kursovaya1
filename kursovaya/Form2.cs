using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace kursovaya
{
    public partial class Form2 : Form
    {
        Form MainForm;
        RadioButton RbEngRus { get; set; }
        RadioButton RbPolRus { get; set; }
        RadioButton RbRusEng { get; set; }
        RadioButton RbRusPol { get; set; }


        public Form2(Form mainform, RadioButton rbEngRus, RadioButton rbPolRus,
            RadioButton rbRusEng, RadioButton rbRusPol)
        {
            RbEngRus = rbEngRus;
            RbPolRus = rbPolRus;
            RbRusEng = rbRusEng;
            RbRusPol = rbRusPol;
            MainForm = mainform;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 mainform = Owner as Form1;
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
            if (tbWordsIn.Text != null && tbWordsOu.Text != null)
            {
                temp.Add(tbWordsIn.Text, tbWordsOu.Text);
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
            temp = RemovingWord(temp, path, RbEngRus, RbRusEng, RbRusPol, RbPolRus);
            File.WriteAllLines(path, temp.Select(x => x.Key + "-" + x.Value).ToArray());
            PrintingDict();
        }
        private Dictionary<string, string> RemovingWord(Dictionary<string, string> temp, string path,
            RadioButton RbEngRus, RadioButton RbRusEng, RadioButton RbPolRus, RadioButton RbRusPol)
        {
            string str = tbWordsIn.Text;
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
                if (keysT[i].Equals(str))
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
    }
}
