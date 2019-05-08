using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace kursovaya
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        } 
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Warning",
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
            MainForm form = new MainForm();

            string[] ownAlph = null;
            ownAlph = AddingOwnAlphabet(ownAlph);

            if (rbTranslate.Checked)
            {
                Translation translation = new Translation(inputTxtBox.Text, outputTxtBox,
                    rbEngRus, rbPolRus, rbRusEng, rbRusPol, form);
            }
            else if (rbTransliterate.Checked)
            {
                Transliteration transliteration = new Transliteration(inputTxtBox.Text, outputTxtBox, rbFrench, rbGerman, rbISO9,
                    rbScientific,  cbCheckLetters, ownAlph, rbOwn);
            }            
        }

        private void RbTranslate_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTranslate.Checked)
            {
                this.Width = 666;
                this.Height = 198;
                rbEngRus.Visible = true;
                rbPolRus.Visible = true;
                rbRusEng.Visible = true;
                rbRusPol.Visible = true;
                label1.Visible = false;
                btnDict.Visible = true;
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
                this.Width = 666;
                this.Height = 198;
                rbISO9.Visible = true;
                rbFrench.Visible = true;
                rbGerman.Visible = true;
                rbScientific.Visible = true;
                rbOwn.Visible = true;
                cbCheckLetters.Visible = true;
                label1.Visible = false;                
            }
            else
            {
                rbISO9.Visible = false;
                rbFrench.Visible = false;
                rbGerman.Visible = false;
                rbScientific.Visible = false;
                rbOwn.Visible = false;
                cbCheckLetters.Visible = false;
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
            MessageBox.Show("File is saved", "Result");
        }

        private void BtnDict_Click(object sender, EventArgs e)
        {
            _DictionaryForm form2 = new _DictionaryForm(rbEngRus, rbPolRus, rbRusEng, rbRusPol)
            {
                Parent = this.Parent,
                Visible = true
            };
        }

        private void RbISO9_CheckedChanged(object sender, EventArgs e)
        {
            if (rbISO9.Checked)
            {
                ChangeSize();
                Visibility();
            }
        }

        private void ChangeSize()
        {
            Width = 666;
            Height = 340;
        }

        private void Visibility()
        {
            inputTxtBox.Visible = true;
            outputTxtBox.Visible = true;
            btnOpen.Visible = true;
            btnSave.Visible = true;
            btnConvert.Visible = true;
            btnClear.Visible = true;
        }

        private void RbScientific_CheckedChanged(object sender, EventArgs e)
        {
            if (rbScientific.Checked)
            {
                ChangeSize();
                Visibility();
            }
        }

        private void RbGerman_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGerman.Checked)
            {
                ChangeSize();
                Visibility();
            }
        }

        private void RbFrench_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFrench.Checked)
            {
                ChangeSize();
                Visibility();
            }
        }

        private void RbRusPol_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRusPol.Checked)
            {
                ChangeSize();
                Visibility();
            }
        }

        private void RbPolRus_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPolRus.Checked)
            {
                ChangeSize();
                Visibility();
            }
        }

        private void RbRusEng_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRusEng.Checked)
            {
                ChangeSize();
                Visibility();
            }
        }

        private void RbEngRus_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEngRus.Checked)
            {
                ChangeSize();
                Visibility();
            }
        }

        private void RbOwn_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOwn.Checked)
            {
                Width = 666;
                Height = 652;
                Visibility();
            }
            string[] ownAlph = null;
            ownAlph = AddingOwnAlphabet(ownAlph);

        }

        private string[] AddingOwnAlphabet(string[] ownAlph)
        {
            List<string> own = new List<string>();

            own.Add(tbSch.Text); own.Add(tbCch.Text); own.Add(tbSh.Text); own.Add(tbJo.Text); own.Add(tbZh.Text);
            own.Add(tbTs.Text); own.Add(tbTv.Text); own.Add(tbY.Text); own.Add(tbJe.Text); own.Add(tbJu.Text);
            own.Add(tbJa.Text); own.Add(tbU.Text); own.Add(tbCh.Text); own.Add(tbA.Text); own.Add(tbB.Text);
            own.Add(tbV.Text); own.Add(tbG.Text); own.Add(tbD.Text); own.Add(tbE.Text); own.Add(tbZ.Text);
            own.Add(tbI.Text); own.Add(tbJ.Text); own.Add(tbK.Text); own.Add(tbL.Text); own.Add(tbM.Text);
            own.Add(tbN.Text); own.Add(tbO.Text); own.Add(tbP.Text); own.Add(tbR.Text); own.Add(tbC.Text);
            own.Add(tbT.Text); own.Add(tbF.Text); own.Add(TbMia.Text);

            ownAlph = own.ToArray();
            return ownAlph;
        }
    }    
}
