using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

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
        CheckBox CbVowel { get; set; }
        CheckBox CbСonsonant { get; set; }

        public Transliteration(string inputtedText, TextBox outputtedtextBox, RadioButton rbFrench,
            RadioButton rbGerman, RadioButton rbISO9, RadioButton rbScientific, CheckBox cbCheckLetters,
            CheckBox cbVowel, CheckBox cbСonsonant)
        {
            InputtedText = inputtedText;
            OutputtedTextBox = outputtedtextBox;

            RbFrench = rbFrench;
            RbScientific = rbScientific;
            RbGerman = rbGerman;
            RbIso9 = rbISO9;
            CbCheckLetters = cbCheckLetters;
            CbVowel = cbVowel;
            CbСonsonant = cbСonsonant;
            

            string[] rus_up = { "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О",
                "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я" };
            string[] rus_low = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };

            if (rbFrench.Checked)
            {
                inputtedText = French(inputtedText, rus_up, rus_low, cbCheckLetters, cbVowel, cbСonsonant);
                if(cbCheckLetters.Checked)
                {

                }
                if(cbVowel.Checked)
                {

                }
                if(cbСonsonant.Checked)
                {

                }
            }
            else if(rbGerman.Checked)
            {
                inputtedText = German(inputtedText, rus_up, rus_low, cbCheckLetters, cbVowel, cbСonsonant);
            }
            else if (rbISO9.Checked)
            {
                inputtedText = Iso9(inputtedText, rus_up, rus_low, cbCheckLetters, cbVowel, cbСonsonant);
            }
            else if(rbScientific.Checked)
            {
                inputtedText = Scientific(inputtedText, rus_up, rus_low, cbCheckLetters, cbVowel, cbСonsonant);
            }
            outputtedtextBox.Text = inputtedText;

            
            
        }
        private static string Transliterate(ref string inputtedText, string[] rus_up, string[] rus_low,
            string[] lat_up, string[] lat_low, string[] consonant, string[] vowels, int length, 
            CheckBox cbCheckLetters, CheckBox cbVowel, 
            CheckBox cbConsonant)
        {
            for (int i = 0; i < length; i++)
            {
                inputtedText = inputtedText.Replace(rus_up[i], lat_up[i]);
                inputtedText = inputtedText.Replace(rus_low[i], lat_low[i]);
            }

            if (cbCheckLetters.Checked)
            {
                for (int i = 0; i < 32; i++)
                {
                    if (lat_up[i].Length > rus_up[i].Length | lat_low[i].Length > rus_low[i].Length)
                    {
                        inputtedText = inputtedText.Replace(lat_low[i], lat_up[i]);

                    }
                }                    
            }

            if (cbVowel.Checked)
            {
                for (int i = 0; i < inputtedText.Length; i++)
                {
                    foreach (var item in vowels)
                    {
                        if (inputtedText.Contains(item))
                        {
                            inputtedText = inputtedText.Replace(item, item.ToUpperInvariant());
                        }                        
                    }
                }
            }
            if (cbConsonant.Checked)
            {
                for (int i = 0; i < inputtedText.Length; i++)
                {
                    foreach (var item in consonant)
                    {
                        if (inputtedText.Contains(item))
                        {
                            inputtedText = inputtedText.Replace(item, item.ToUpperInvariant());
                        }
                    }
                }
            }
            return inputtedText;
        }
        private static string Iso9(string inputtedText, string[] rus_up, string[] rus_low, 
            CheckBox cbCheckLetters, CheckBox cbVowel, CheckBox cbConsonant)
        {
            string[] lat_up = { "A", "B", "V", "G", "D", "E", "YO", "ZH", "Z", "I", "J", "K",
                "L", "M", "N", "O", "P", "R", "S", "T", "U", "F", "X", "CZ", "CH", "SH", "SHH",
                "''", "Y'", "'", "E'", "YU", "YA" };
            string[] lat_low = { "a", "b", "v", "g", "d", "e", "yo", "zh", "z", "i", "j", "k",
                "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "x", "cz", "ch", "sh", "shh",
                "''", "y", "'", "e", "yu", "ya" };
            string[] vowels = {"a", "e", "yo", "i", "o", "u", "y", "yu", "ya", "A", "E", "YO", "I",
                "O", "U", "e'", "E'", "YU", "YA", "Y" };
            string[] consonant = { "b", "v", "g", "d", "zh", "z", "j", "k", "l", "m", "n", "p",
                "r", "s", "t", "f", "x", "cz", "ch", "sh", "shh", "''", "'", "B", "V", "G", "D",
                "ZH", "Z", "J", "K", "L", "M", "N", "P", "R", "S", "T", "F", "X", "CZ", "CH", "SH",
                "SHH" };            
            int length = lat_up.Length;
            return Transliterate(ref inputtedText, rus_up, rus_low, lat_up, lat_low, consonant,
                vowels, length, cbCheckLetters, cbVowel, cbConsonant);
        }
        private static string Scientific(string inputtedText, string[] rus_up, string[] rus_low, 
            CheckBox cbCheckLetters, CheckBox cbVowel, CheckBox cbConsonant)
        {
            string[] lat_up = { "A", "B", "V", "G", "D", "E", "Ё", "Ž", "Z", "I", "J", "K", "L",
                "M", "N", "O", "P", "R", "S", "T", "U", "F", "H", "C", "Č", "Š", "Ŝ", "''", "Y",
                "'", "È", "Û", "Â" };
            string[] lat_low = { "a", "b", "v", "g", "d", "e", "ё", "ž", "z", "i", "j", "k", "l",
                "m", "n", "o", "p", "r", "s", "t", "u", "f", "h", "c", "č", "š", "ŝ", "''", "y",
                "'", "è", "û", "â" };
            int length = lat_up.Length;
            string[] vowels = {"A", "E", "Ё", "I", "O", "U", "Y", "È", "Û", "Â",
                "a", "e", "ё", "i", "o", "u", "y", "è", "û", "â" };
            string[] consonant = {"B", "V", "G", "D", "Ž", "Z", "J", "K", "L",
                "M", "N", "P", "R", "S", "T", "F", "H", "C", "Č", "Š", "Ŝ", "''",
                "'", "b", "v", "g", "d", "ž", "z", "j", "k", "l", "m", "n", "p",
                "r", "s", "t", "f", "h", "c", "č", "š", "ŝ", };

            return Transliterate(ref inputtedText, rus_up, rus_low, lat_up, lat_low, consonant,
                vowels, length, cbCheckLetters, cbVowel, cbConsonant);
        }
        private static string German(string inputtedText, string[] rus_up, string[] rus_low, 
            CheckBox cbCheckLetters, CheckBox cbVowel, CheckBox cbConsonant)
        {
            string[] lat_up = { "A", "B", "W", "G", "D", "E", "JO", "SCH", "S", "I", "J", "K", "L", "M",
                "N", "O", "P", "R", "S", "T", "U", "F", "CH", "Z", "TSCH", "SCH", "SCHTSCH", "''", "Y",
                "'", "E", "JU", "JA" };
            string[] lat_low = { "a", "b", "w", "g", "d", "e", "jo", "sch", "s", "i", "y", "k", "l",
                "m", "n", "o", "p", "r", "s", "t", "u", "f", "ch", "z", "tsch", "sch", "schtsch", "''",
                "y", "'", "e", "ju", "ja" };
            string[] vowels = { "A", "E", "JO", "I", "O", "U", "JU", "JA", "Y",
            "a", "e", "jo", "i", "o", "u", "ju", "ja", "y"};
            string[] consonant = { "B", "W", "G", "D", "SCH", "S","J", "K", "L", "M", "N", "P", "R", "S", "T",
            "F", "CH", "Z", "TSCH", "SCH", "SCHTSCH", "''", "'","b", "w", "g", "d", "sch", "s","y", "k", "l",
                "m", "n","p", "r", "s", "t","f", "ch", "z", "tsch", "sch", "schtsch"};

            int length = lat_up.Length;
            
            return Transliterate(ref inputtedText, rus_up, rus_low, lat_up, lat_low, consonant,
                vowels, length, cbCheckLetters, cbVowel, cbConsonant);
        }
        private static string French(string inputtedText, string[] rus_up, string[] rus_low, CheckBox cbCheckLetters, 
            CheckBox cbVowel, CheckBox cbConsonant)
        {
            string[] lat_up = { "A", "B", "V", "G", "D", "E", "IO", "J", "Z", "I", "Ï", "K", "L", "M",
                "N", "O", "P", "R", "S", "T", "OU", "F", "KX", "TS", "TCH", "CH", "CHTCH", "''", "Y",
                "'", "E", "ÏOU", "ÏA" };
            string[] lat_low = { "a", "b", "v", "g", "d", "e", "io", "j", "z", "i", "ï", "k", "l", "m",
                "n", "o", "p", "r", "s", "t", "ou", "f", "kx", "ts", "tch", "ch", "chtch", "''", "y",
                "'", "e", "iou", "ia" };
            string[] vowels = {"A", "a", "E", "e", "IO", "io", "I", "i", "O", "o", "OU", "ou",
                "Y'", "y'", "IOU", "iou", "IA", "ia"};
            string[] consonant = { "B", "V", "G", "D", "J", "Z", "Ï", "K", "L", "M", "N",
                 "P", "R", "S", "T", "F", "KX", "TS", "TCH", "CH", "CHTCH", "''", "'", "b", "v", "g", "d", "j", "z",
                 "ï", "k", "l", "m", "n", "p", "r", "s", "t", "f", "kx", "ts", "tch", "ch", "chtch", "''", "'"};

            int length = lat_up.Length;
            
            return Transliterate(ref inputtedText, rus_up, rus_low, lat_up, lat_low, consonant,
                vowels, length, cbCheckLetters, cbVowel, cbConsonant);
        }        
    }
}
