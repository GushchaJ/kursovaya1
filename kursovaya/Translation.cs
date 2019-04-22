﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kursovaya;

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

        public Translation(string inputtedText, TextBox outputtedtextBox, RadioButton rbEngRus,
            RadioButton rbPolRus, RadioButton rbRusEng, RadioButton rbRusPol)
        {
            InputtedText = inputtedText;
            OutputtedTextBox = outputtedtextBox;
            RbEngRus = rbEngRus;
            RbRusEng = rbRusEng;
            RbPolRus = rbPolRus;
            RbRusPol = rbRusPol;

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

            Translate(inputtedText, outputtedtextBox, dictionary);
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

        private static void Translate(string inputtedText, TextBox outputtedtextBox, Dictionary<string, string> dictionary)
        {
            string[] inputtedTextDevided = inputtedText.Split(' ', '.', ',', '!', '?', '"', ':', ';');
            List<string> outputtedTextDevided = new List<string>();

            for (int i = 0; i < inputtedTextDevided.Length; i++)
            {
                if (dictionary.ContainsKey(inputtedTextDevided[i]))
                {
                    string res = inputtedTextDevided[i];
                    outputtedTextDevided.Add(dictionary[res]);
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
            }
        }
    }
}
