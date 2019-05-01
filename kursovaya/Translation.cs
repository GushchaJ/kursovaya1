using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace kursovaya
{
    class Translation
    {
        string InputtedText { get; set; }
        TextBox OutputtedTextBox { get; set; }
        RadioButton RbEngRus { get; set; }
        RadioButton RbPolRus { get; set; }
        RadioButton RbRusEng { get; set; }
        RadioButton RbRusPol { get; set; }
        MainForm Form { get; set; }
        public Translation(string inputtedText, TextBox outputtedtextBox, RadioButton rbEngRus,
            RadioButton rbPolRus, RadioButton rbRusEng, RadioButton rbRusPol, MainForm form)
        {
            InputtedText = inputtedText;
            OutputtedTextBox = outputtedtextBox;
            RbEngRus = rbEngRus;
            RbRusEng = rbRusEng;
            RbPolRus = rbPolRus;
            RbRusPol = rbRusPol;
            Form = form;

            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            if (rbEngRus.Checked)
            {
                GetEngRus(inputtedText, outputtedtextBox, dictionary);
            }
            else if (rbPolRus.Checked)
            {
                GetPolRus(inputtedText, outputtedtextBox, dictionary);
            }
            else if (rbRusEng.Checked)
            {
                GetEngRus(inputtedText, outputtedtextBox, dictionary);
                Dictionary<string, string> temp = new Dictionary<string, string>();
                foreach (var item in dictionary)
                {
                    temp.Add(item.Value, item.Key);
                }
                dictionary = temp;
            }
            else if (rbRusPol.Checked)
            {
                GetPolRus(inputtedText, outputtedtextBox, dictionary);
                dictionary = Dictionaryreversing(dictionary);
            }

            Translate(inputtedText, outputtedtextBox, dictionary, rbEngRus, 
                rbPolRus, rbRusEng, rbRusPol, form);
        }

        private static Dictionary<string, string> Dictionaryreversing(Dictionary<string, string> dictionary)
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();
            foreach (var i in dictionary)
            { 
                temp.Add(i.Value, i.Key);
            }
            dictionary = temp;
            return dictionary;
        }

        private static void Translate(string inputtedText, TextBox outputtedtextBox, Dictionary<string, string> dictionary, 
            RadioButton rbEngRus, RadioButton rbPolRus, RadioButton rbRusEng, RadioButton rbRusPol, MainForm form)
        {
            inputtedText = inputtedText.ToLower();
            string[] inputtedTextDevided = inputtedText.Split(' ', '.', ',', '!', '?', '"', ':', ';');
            
            List<string> outputtedTextDevided = new List<string>();

            for (int i = 0; i < inputtedTextDevided.Length; i++)
            {
                if (dictionary.ContainsKey(inputtedTextDevided[i]))
                {
                    string res = inputtedTextDevided[i];
                    outputtedTextDevided.Add(dictionary[res]);
                }
                else
                {
                    var result = MessageBox.Show("There's no such word... Would you like" +
                        " to open the dictionary?", "Warning",
                          MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        _DictionaryForm form2 = new _DictionaryForm(form, rbEngRus, rbPolRus, rbRusEng, rbRusPol);
                        form2.Show();
                    }
                }
            }
            string outputtedText = string.Join(" ", outputtedTextDevided.ToArray());
            outputtedtextBox.Text = outputtedText.ToString();
        }

        private static void GetEngRus(string inputtedText, TextBox outputtedtextBox, Dictionary<string, string> dictionary)
        {
            string path = @"..\..\engRus.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                string _line;
                while ((_line = sr.ReadLine()) != null)
                {
                    string[] keyvalue = _line.Split('-');
                    if (keyvalue.Length == 2)
                    {
                        dictionary.Add(keyvalue[0], keyvalue[1]);
                    }
                }
                dictionary = dictionary.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            }
        }
        private static void GetPolRus(string inputtedText, TextBox outputtedtextBox, Dictionary<string, string> dictionary)
        {
            string path = @"..\..\polRus.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                string _line;
                while ((_line = sr.ReadLine()) != null)
                {
                    string[] keyvalue = _line.Split('-');
                    if (keyvalue.Length == 2)
                    {
                        dictionary.Add(keyvalue[0], keyvalue[1]);
                    }
                }
                dictionary = dictionary.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            }
        }
    }
}

