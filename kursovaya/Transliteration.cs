using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace kursovaya
{
    class Transliteration
    {
        string InputtedText { get; set; }
        TextBox OutputtedTextBox { get; set; }
        RadioButton RbFrench { get; set; }
        RadioButton RbGerman { get; set; }
        RadioButton RbIso9 { get; set; }
        RadioButton RbScientific { get; set; }
        RadioButton RbOwn { get; set; }
        CheckBox CbCheckLetters { get; set; }
        string [] OwnAlph { get; set; }

        public Transliteration(string inputtedText, TextBox outputtedtextBox, RadioButton rbFrench,
            RadioButton rbGerman, RadioButton rbISO9, RadioButton rbScientific, CheckBox cbCheckLetters,
            string [] ownAlph, RadioButton rbOwn)
        {
            InputtedText = inputtedText;
            OutputtedTextBox = outputtedtextBox;
            OwnAlph = ownAlph;
            RbFrench = rbFrench;
            RbScientific = rbScientific;
            RbGerman = rbGerman;
            RbIso9 = rbISO9;
            CbCheckLetters = cbCheckLetters;
            RbOwn = rbOwn;

            string[] rus = null;
            List<string> temp = new List<string>();
            string path = @"..\..\trRu.txt";
            rus = ReadingFromFile(temp, path);
            inputtedText = Preparing2Translit(inputtedText, rbFrench, rbGerman, rbISO9, 
                rbScientific, cbCheckLetters, ownAlph, rbOwn, rus);

            outputtedtextBox.Text = inputtedText;
        }

        private static string Preparing2Translit(string inputtedText, RadioButton rbFrench, RadioButton rbGerman, 
            RadioButton rbISO9, RadioButton rbScientific, CheckBox cbCheckLetters, string[] ownAlph,
            RadioButton rbOwn, string[] rus)
        {
            for (int i = 0; i < inputtedText.Length; i++)
            {
                if (rbFrench.Checked)
                {
                    inputtedText = French(inputtedText, rus, cbCheckLetters,
                        rbFrench, rbGerman, rbISO9, rbScientific);
                    break;
                }
                else if (rbGerman.Checked)
                {
                    inputtedText = German(inputtedText, rus, cbCheckLetters,
                        rbFrench, rbGerman, rbISO9, rbScientific);
                    break;
                }
                else if (rbISO9.Checked)
                {
                    inputtedText = Iso9(inputtedText, rus, cbCheckLetters,
                        rbFrench, rbGerman, rbISO9, rbScientific);
                    break;
                }
                else if (rbScientific.Checked)
                {
                    inputtedText = Scientific(inputtedText, rus, cbCheckLetters, 
                        rbFrench, rbGerman, rbISO9, rbScientific);
                    break;
                }
                else if (rbOwn.Checked)
                {
                    inputtedText = Own(inputtedText, rus, ownAlph, cbCheckLetters);
                    break;
                }
            }

            return inputtedText;
        }

        private static string[] GettingAlphabet(RadioButton rbFrench, RadioButton rbGerman,
            RadioButton rbISO9, RadioButton rbScientific)
        {
            string[] alph;
            List<string> temp = new List<string>();
            string path = "";
            path = GetPath(rbFrench, rbGerman, rbISO9, rbScientific, path);
            alph = ReadingFromFile(temp, path);
            return alph;
        }

        private static string GetPath(RadioButton rbFrench, RadioButton rbGerman, RadioButton rbISO9, 
            RadioButton rbScientific, string path)
        {
            if (rbFrench.Checked)
            {
                path = @"..\..\trFr.txt";
            }
            if (rbGerman.Checked)
            {
                path = @"..\..\trGer.txt";
            }
            if (rbISO9.Checked)
            {
                path = @"..\..\trIso.txt";
            }
            if (rbScientific.Checked)
            {
                path = @"..\..\trSci.txt";
            }
            return path;
        }

        private static string[] ReadingFromFile(List<string> temp, string path)
        {
            string[] alph;
            using (StreamReader sr = new StreamReader(path))
            {
                string _line;
                while ((_line = sr.ReadLine()) != null)
                {
                    string[] temp1 = _line.Split(',');
                    foreach (string item in temp1)
                    {
                        temp.Add(item);
                    }
                }
            }
            alph = temp.ToArray();
            return alph;
        }

        private static string Transliterate(ref string inputtedText, string[] rus,
            string[] lat, int length, CheckBox cbCheckLetters)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            for (int i = 0; i < length; i++)
            {
                dict.Add(rus[i], lat[i]); //rus - key
            }
            for (int i = 0; i < inputtedText.Length; i++)
            {
                if (Regex.Match(inputtedText, @"^[А-Яа-яёЁ ']+$").Success)
                {
                    for (int j = 0; j < length; j++)
                    {
                        inputtedText = inputtedText.Replace(rus[j], lat[j]);
                        inputtedText = inputtedText.Replace(rus[j].ToLower(), lat[j].ToLower());
                    }
                    if (cbCheckLetters.Checked)
                    {
                        for (int j = 0; j < 32; j++)
                        {
                            if (lat[j].Length > rus[j].Length | lat[j].ToLower
                                ().Length > rus[j].ToLower().Length)
                            {
                                inputtedText = inputtedText.Replace(lat[j].ToLower(), lat[j]);
                            }
                        }
                    }
                    break;
                }
                if (Regex.Match(inputtedText, @"^[A-Z 'ŜČŠЁŽÈÛÂÏ]+$", RegexOptions.IgnoreCase).Success)
                {
                    for (int j = 0; j < length; j++)
                    {
                        inputtedText = inputtedText.Replace(lat[j], rus[j]);
                        inputtedText = inputtedText.Replace(lat[j].ToLower(), rus[j].ToLower());
                    }
                    if (cbCheckLetters.Checked)
                    {
                        for (int j = 0; j < 32; j++)
                        {
                            if (lat[j].Length > rus[j].Length | lat[j].ToLower
                                ().Length > rus[j].ToLower().Length)
                            {
                                inputtedText = inputtedText.Replace(rus[j].ToLower(), rus[j]);
                            }
                        }
                    }
                    break;
                }                
            }
            return inputtedText;
        }

        private static string Own(string inputtedText, string[] rus, string[] ownAlph,
            CheckBox cbCheckLetters)
        {
            int length = ownAlph.Length;
            return Transliterate(ref inputtedText, rus, ownAlph, length, cbCheckLetters);
        }
        private static string Iso9(string inputtedText, string[] rus, 
            CheckBox cbCheckLetters, RadioButton rbFrench, RadioButton rbGerman, RadioButton rbISO9,
            RadioButton rbScientific)
        {
            string[] lat = GettingAlphabet(rbFrench, rbGerman, rbISO9, rbScientific);
            int length = lat.Length;
            return Transliterate(ref inputtedText, rus, lat, length, cbCheckLetters);
        }
        private static string Scientific(string inputtedText, string[] rus,
            CheckBox cbCheckLetters, RadioButton rbFrench, RadioButton rbGerman, RadioButton rbISO9,
            RadioButton rbScientific)
        {
            string[] lat = GettingAlphabet(rbFrench, rbGerman, rbISO9, rbScientific);
            int length = lat.Length;
            return Transliterate(ref inputtedText, rus, lat, length, cbCheckLetters);
        }
        private static string German(string inputtedText, string[] rus,
            CheckBox cbCheckLetters, RadioButton rbFrench, RadioButton rbGerman, RadioButton rbISO9,
            RadioButton rbScientific)
        {
            string[] lat = GettingAlphabet(rbFrench, rbGerman, rbISO9, rbScientific);
            int length = lat.Length;
            return Transliterate(ref inputtedText, rus, lat, length, cbCheckLetters);
        }
         private static string French(string inputtedText, string[] rus,
            CheckBox cbCheckLetters, RadioButton rbFrench, RadioButton rbGerman, RadioButton rbISO9,
            RadioButton rbScientific)
        {
            string[] lat = GettingAlphabet(rbFrench, rbGerman, rbISO9, rbScientific);
            int length = lat.Length;
            return Transliterate(ref inputtedText, rus, lat, length, cbCheckLetters);
        }        
    }
}
