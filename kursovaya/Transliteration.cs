using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
        CheckBox CbCheckLetters { get; set; }

        public Transliteration(string inputtedText, TextBox outputtedtextBox, RadioButton rbFrench,
            RadioButton rbGerman, RadioButton rbISO9, RadioButton rbScientific, CheckBox cbCheckLetters)             
        {
            InputtedText = inputtedText;
            OutputtedTextBox = outputtedtextBox;

            RbFrench = rbFrench;
            RbScientific = rbScientific;
            RbGerman = rbGerman;
            RbIso9 = rbISO9;
            CbCheckLetters = cbCheckLetters;

            string[] rus = { "Щ", "Ч", "Ш", "Ё", "Ж", "Ц", "Ъ", "Ы", "Э", "Ю", "Я", "У", "Х", "А", "Б",
                "В", "Г", "Д", "Е", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т",  "Ф", "Ь" };

            for (int i = 0; i < inputtedText.Length; i++)
            {
                if (rbFrench.Checked)
                {
                    inputtedText = French(inputtedText, rus, cbCheckLetters);
                    break;
                }
                else if (rbGerman.Checked)
                {
                    inputtedText = German(inputtedText, rus, cbCheckLetters);
                    break;
                }
                else if (rbISO9.Checked)
                {
                    inputtedText = Iso9(inputtedText, rus, cbCheckLetters);
                    break;
                }
                else if (rbScientific.Checked)
                {
                    inputtedText = Scientific(inputtedText, rus, cbCheckLetters);
                    break;
                }
            }
            
            outputtedtextBox.Text = inputtedText;           
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
                if (Regex.Match(inputtedText, @"^[А-Яа-я ']+$").Success)
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
        private static string Iso9(string inputtedText, string[] rus, 
            CheckBox cbCheckLetters)
        {
            string[] lat = {"SHH", "CH", "SH", "YO", "ZH", "CZ",  "''", "Y'", "E'", "YU", "YA", "U", "X",
                "A", "B", "V", "G", "D", "E", "Z", "I", "J", "K", "L", "M", "N", "O", "P", "R",
                "S", "T", "F",  "'"};

            

            int length = lat.Length;
            return Transliterate(ref inputtedText, rus, lat, length, cbCheckLetters);
        }
        private static string Scientific(string inputtedText, string[] rus,
            CheckBox cbCheckLetters)
        {
            string[] lat = { "Ŝ","Č", "Š", "Ё", "Ž", "C", "''", "Y", "È", "Û", "Â","U","H",
                "A", "B", "V", "G", "D", "E", "Z", "I", "J", "K", "L",
                "M", "N", "O", "P", "R", "S", "T",  "F",  "'"  };            

            int length = lat.Length;
            return Transliterate(ref inputtedText, rus, lat, length, cbCheckLetters);
        }
        private static string German(string inputtedText, string[] rus,
            CheckBox cbCheckLetters)
        {
            string[] lat = { "SCHTSCH", "TSCH", "SCH", "JO", "SCH", "Z",  "''",  "Y",
                "E", "JU", "JA", "U", "CH", "A", "B", "W", "G", "D", "E", "S", "I", "J", "K", "L", "M",
                "N", "O", "P", "R", "S", "T",  "F",  "'" };

            int length = lat.Length;
            
            return Transliterate(ref inputtedText, rus, lat, length, cbCheckLetters);
        }
         private static string French(string inputtedText, string[] rus,
            CheckBox cbCheckLetters)
        {
             string[] lat = {"CHTCH","TCH", "CH", "IO", "J", "TS",  "''", "Y", "E", "ÏOU", "ÏA","OU","KX",
                "A", "B", "V", "G", "D", "E", "Z", "I", "Ï", "K", "L", "M",  
                "N", "O", "P", "R", "S", "T","F", "'"};            

            int length = lat.Length;
            
            return Transliterate(ref inputtedText, rus, lat, length, cbCheckLetters);
        }        
    }
}
