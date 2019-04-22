using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kursovaya;

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

        private void BtnOpen_Click(object sender, EventArgs e)
        {

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            inputTxtBox.Text = "";
            outputTxtBox.Text = "";
        }

        private void BtnDict_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void CbChooseOption_MouseClick(object sender, MouseEventArgs e)
        {


        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox3_Click(object sender, EventArgs e) { }

        private void InputTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) == false) return; // проверка ввода
            e.Handled = true;
            return;
        }

        private void InputTxtBox_TextChanged(object sender, EventArgs e)
        {
            //string inputtedText = Convert.ToString(inputTxtBox.Text);
            //inputtedText
        }

        private void OutputTxtBox_TextChanged(object sender, EventArgs e)
        {
            //string outputtedText = Convert.ToString(inputTxtBox.Text);
            
            
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
                    rbScientific);
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

        private void CbReverse_Click(object sender, EventArgs e)
        {
            //удоли
        }

        private void CbReverse_CheckedChanged(object sender, EventArgs e)
        {
            //удоли
        }
    }
    
}
