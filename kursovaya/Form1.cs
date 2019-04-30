using System;
using System.IO;
using System.Windows.Forms;

namespace kursovaya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите выйти?", "Внимание",
                          MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                e.Cancel = true;
        }

        OpenFileDialog openFileDialog = new OpenFileDialog();
        private void BtnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = ".txt|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                inputTxtBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            inputTxtBox.Text = "";
            outputTxtBox.Text = "";
        }

        private void InputTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) == false) return; // проверка ввода
            e.Handled = true;
            return;
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            outputTxtBox.Text = null;

            if(rbTranslate.Checked)
            {
                Translation translation = new Translation(inputTxtBox.Text, outputTxtBox, rbEngRus, rbPolRus, rbRusEng, rbRusPol);
            }
            else if (rbTransliterate.Checked)
            {
                Transliteration transliteration = new Transliteration(inputTxtBox.Text, outputTxtBox, rbFrench, rbGerman, rbISO9,
                    rbScientific, cbCheckLetters, cbVowel, cbСonsonant);
            }
        }

        private void RbTranslate_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTranslate.Checked)
            {
                rbEngRus.Visible = true;
                rbPolRus.Visible = true;
                rbRusEng.Visible = true;
                rbRusPol.Visible = true;
            }
            else
            {
                rbEngRus.Visible = false;
                rbPolRus.Visible = false;
                rbRusEng.Visible = false;
                rbRusPol.Visible = false;
            }
        }

        private void RbTransliterate_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTransliterate.Checked)
            {
                rbISO9.Visible = true;
                rbFrench.Visible = true;
                rbGerman.Visible = true;
                rbScientific.Visible = true;
            }
            else
            {
                rbISO9.Visible = false;
                rbFrench.Visible = false;
                rbGerman.Visible = false;
                rbScientific.Visible = false;
            }            
        }

        SaveFileDialog saveFileDialog = new SaveFileDialog();
        private void BtnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = ".txt|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, outputTxtBox.Text);
            MessageBox.Show("Файл сохранен", "Результат");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this, rbEngRus, rbPolRus, rbRusEng, rbRusPol);
            form2.Parent = this.Parent;
            form2.Visible = true;
        }
    }
    
}
