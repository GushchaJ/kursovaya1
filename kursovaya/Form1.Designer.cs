namespace kursovaya
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.rbTranslate = new System.Windows.Forms.RadioButton();
            this.rbTransliterate = new System.Windows.Forms.RadioButton();
            this.gbSelector = new System.Windows.Forms.GroupBox();
            this.gbEditor = new System.Windows.Forms.GroupBox();
            this.rbFrench = new System.Windows.Forms.RadioButton();
            this.rbGerman = new System.Windows.Forms.RadioButton();
            this.rbScientific = new System.Windows.Forms.RadioButton();
            this.rbISO9 = new System.Windows.Forms.RadioButton();
            this.rbRusPol = new System.Windows.Forms.RadioButton();
            this.rbPolRus = new System.Windows.Forms.RadioButton();
            this.rbRusEng = new System.Windows.Forms.RadioButton();
            this.rbEngRus = new System.Windows.Forms.RadioButton();
            this.btnConvert = new System.Windows.Forms.Button();
            this.outputTxtBox = new System.Windows.Forms.TextBox();
            this.inputTxtBox = new System.Windows.Forms.TextBox();
            this.gbSelector.SuspendLayout();
            this.gbEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(9, 106);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(76, 23);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "Open...";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(554, 262);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(19, 262);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "View dictionary";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(104, 106);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // rbTranslate
            // 
            this.rbTranslate.AutoSize = true;
            this.rbTranslate.Location = new System.Drawing.Point(6, 25);
            this.rbTranslate.Name = "rbTranslate";
            this.rbTranslate.Size = new System.Drawing.Size(90, 22);
            this.rbTranslate.TabIndex = 10;
            this.rbTranslate.TabStop = true;
            this.rbTranslate.Text = "Translate";
            this.rbTranslate.UseVisualStyleBackColor = true;
            this.rbTranslate.CheckedChanged += new System.EventHandler(this.RbTranslate_CheckedChanged);
            // 
            // rbTransliterate
            // 
            this.rbTransliterate.AutoSize = true;
            this.rbTransliterate.Location = new System.Drawing.Point(122, 25);
            this.rbTransliterate.Name = "rbTransliterate";
            this.rbTransliterate.Size = new System.Drawing.Size(110, 22);
            this.rbTransliterate.TabIndex = 11;
            this.rbTransliterate.TabStop = true;
            this.rbTransliterate.Text = "Transliterate";
            this.rbTransliterate.UseVisualStyleBackColor = true;
            this.rbTransliterate.CheckedChanged += new System.EventHandler(this.RbTransliterate_CheckedChanged);
            // 
            // gbSelector
            // 
            this.gbSelector.Controls.Add(this.rbTransliterate);
            this.gbSelector.Controls.Add(this.rbTranslate);
            this.gbSelector.Location = new System.Drawing.Point(13, 28);
            this.gbSelector.Name = "gbSelector";
            this.gbSelector.Size = new System.Drawing.Size(616, 60);
            this.gbSelector.TabIndex = 12;
            this.gbSelector.TabStop = false;
            this.gbSelector.Text = "Select the desired function";
            // 
            // gbEditor
            // 
            this.gbEditor.Controls.Add(this.rbFrench);
            this.gbEditor.Controls.Add(this.rbGerman);
            this.gbEditor.Controls.Add(this.rbScientific);
            this.gbEditor.Controls.Add(this.rbISO9);
            this.gbEditor.Controls.Add(this.rbRusPol);
            this.gbEditor.Controls.Add(this.rbPolRus);
            this.gbEditor.Controls.Add(this.rbRusEng);
            this.gbEditor.Controls.Add(this.rbEngRus);
            this.gbEditor.Controls.Add(this.btnConvert);
            this.gbEditor.Controls.Add(this.btnClear);
            this.gbEditor.Controls.Add(this.outputTxtBox);
            this.gbEditor.Controls.Add(this.inputTxtBox);
            this.gbEditor.Controls.Add(this.btnOpen);
            this.gbEditor.Location = new System.Drawing.Point(13, 94);
            this.gbEditor.Name = "gbEditor";
            this.gbEditor.Size = new System.Drawing.Size(616, 147);
            this.gbEditor.TabIndex = 13;
            this.gbEditor.TabStop = false;
            this.gbEditor.Text = "Editor";
            // 
            // rbFrench
            // 
            this.rbFrench.AutoSize = true;
            this.rbFrench.Location = new System.Drawing.Point(477, 25);
            this.rbFrench.Name = "rbFrench";
            this.rbFrench.Size = new System.Drawing.Size(139, 22);
            this.rbFrench.TabIndex = 17;
            this.rbFrench.TabStop = true;
            this.rbFrench.Text = "Based on French";
            this.rbFrench.UseVisualStyleBackColor = true;
            this.rbFrench.Visible = false;
            // 
            // rbGerman
            // 
            this.rbGerman.AutoSize = true;
            this.rbGerman.Location = new System.Drawing.Point(289, 25);
            this.rbGerman.Name = "rbGerman";
            this.rbGerman.Size = new System.Drawing.Size(147, 22);
            this.rbGerman.TabIndex = 16;
            this.rbGerman.TabStop = true;
            this.rbGerman.Text = "Based on German";
            this.rbGerman.UseVisualStyleBackColor = true;
            this.rbGerman.Visible = false;
            // 
            // rbScientific
            // 
            this.rbScientific.AutoSize = true;
            this.rbScientific.Location = new System.Drawing.Point(149, 25);
            this.rbScientific.Name = "rbScientific";
            this.rbScientific.Size = new System.Drawing.Size(83, 22);
            this.rbScientific.TabIndex = 15;
            this.rbScientific.TabStop = true;
            this.rbScientific.Text = "Scientific";
            this.rbScientific.UseVisualStyleBackColor = true;
            this.rbScientific.Visible = false;
            // 
            // rbISO9
            // 
            this.rbISO9.AutoSize = true;
            this.rbISO9.Location = new System.Drawing.Point(6, 25);
            this.rbISO9.Name = "rbISO9";
            this.rbISO9.Size = new System.Drawing.Size(104, 22);
            this.rbISO9.TabIndex = 14;
            this.rbISO9.TabStop = true;
            this.rbISO9.Text = "ISO 9:1995";
            this.rbISO9.UseVisualStyleBackColor = true;
            this.rbISO9.Visible = false;
            // 
            // rbRusPol
            // 
            this.rbRusPol.AutoSize = true;
            this.rbRusPol.Location = new System.Drawing.Point(490, 25);
            this.rbRusPol.Name = "rbRusPol";
            this.rbRusPol.Size = new System.Drawing.Size(87, 22);
            this.rbRusPol.TabIndex = 13;
            this.rbRusPol.TabStop = true;
            this.rbRusPol.Text = "Rus->Pol";
            this.rbRusPol.UseVisualStyleBackColor = true;
            this.rbRusPol.Visible = false;
            // 
            // rbPolRus
            // 
            this.rbPolRus.AutoSize = true;
            this.rbPolRus.Location = new System.Drawing.Point(323, 25);
            this.rbPolRus.Name = "rbPolRus";
            this.rbPolRus.Size = new System.Drawing.Size(87, 22);
            this.rbPolRus.TabIndex = 12;
            this.rbPolRus.TabStop = true;
            this.rbPolRus.Text = "Pol->Rus";
            this.rbPolRus.UseVisualStyleBackColor = true;
            this.rbPolRus.Visible = false;
            // 
            // rbRusEng
            // 
            this.rbRusEng.AutoSize = true;
            this.rbRusEng.Location = new System.Drawing.Point(160, 25);
            this.rbRusEng.Name = "rbRusEng";
            this.rbRusEng.Size = new System.Drawing.Size(93, 22);
            this.rbRusEng.TabIndex = 11;
            this.rbRusEng.TabStop = true;
            this.rbRusEng.Text = "Rus->Eng";
            this.rbRusEng.UseVisualStyleBackColor = true;
            this.rbRusEng.Visible = false;
            // 
            // rbEngRus
            // 
            this.rbEngRus.AutoSize = true;
            this.rbEngRus.Location = new System.Drawing.Point(6, 25);
            this.rbEngRus.Name = "rbEngRus";
            this.rbEngRus.Size = new System.Drawing.Size(93, 22);
            this.rbEngRus.TabIndex = 10;
            this.rbEngRus.TabStop = true;
            this.rbEngRus.Text = "Eng->Rus";
            this.rbEngRus.UseVisualStyleBackColor = true;
            this.rbEngRus.Visible = false;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(500, 106);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(92, 23);
            this.btnConvert.TabIndex = 9;
            this.btnConvert.Text = "Convert!";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.BtnConvert_Click);
            // 
            // outputTxtBox
            // 
            this.outputTxtBox.Location = new System.Drawing.Point(323, 62);
            this.outputTxtBox.Name = "outputTxtBox";
            this.outputTxtBox.Size = new System.Drawing.Size(269, 26);
            this.outputTxtBox.TabIndex = 5;
            // 
            // inputTxtBox
            // 
            this.inputTxtBox.Location = new System.Drawing.Point(6, 62);
            this.inputTxtBox.Name = "inputTxtBox";
            this.inputTxtBox.Size = new System.Drawing.Size(280, 26);
            this.inputTxtBox.TabIndex = 4;
            this.inputTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputTxtBox_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(650, 297);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbSelector);
            this.Controls.Add(this.gbEditor);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "F1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Leave += new System.EventHandler(this.Form1_Load);
            this.gbSelector.ResumeLayout(false);
            this.gbSelector.PerformLayout();
            this.gbEditor.ResumeLayout(false);
            this.gbEditor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton rbTranslate;
        private System.Windows.Forms.RadioButton rbTransliterate;
        private System.Windows.Forms.GroupBox gbSelector;
        private System.Windows.Forms.GroupBox gbEditor;
        private System.Windows.Forms.TextBox outputTxtBox;
        private System.Windows.Forms.TextBox inputTxtBox;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.RadioButton rbEngRus;
        private System.Windows.Forms.RadioButton rbRusPol;
        private System.Windows.Forms.RadioButton rbPolRus;
        private System.Windows.Forms.RadioButton rbRusEng;
        private System.Windows.Forms.RadioButton rbISO9;
        private System.Windows.Forms.RadioButton rbFrench;
        private System.Windows.Forms.RadioButton rbGerman;
        private System.Windows.Forms.RadioButton rbScientific;
    }
}

