namespace kursovaya
{
    partial class _DictionaryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddNewWord = new System.Windows.Forms.Button();
            this.btnRemoveWord = new System.Windows.Forms.Button();
            this.tbWordsIn = new System.Windows.Forms.TextBox();
            this.tbWordsOu = new System.Windows.Forms.TextBox();
            this.rbIwannaAdd = new System.Windows.Forms.RadioButton();
            this.rbIwannaDelete = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(43, 33);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(245, 139);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(321, 33);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(245, 139);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Word";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Translation";
            // 
            // btnAddNewWord
            // 
            this.btnAddNewWord.Location = new System.Drawing.Point(43, 199);
            this.btnAddNewWord.Name = "btnAddNewWord";
            this.btnAddNewWord.Size = new System.Drawing.Size(96, 23);
            this.btnAddNewWord.TabIndex = 4;
            this.btnAddNewWord.Text = "Add word";
            this.btnAddNewWord.UseVisualStyleBackColor = true;
            this.btnAddNewWord.Visible = false;
            this.btnAddNewWord.Click += new System.EventHandler(this.BtnAddNewWord_Click);
            // 
            // btnRemoveWord
            // 
            this.btnRemoveWord.Location = new System.Drawing.Point(452, 199);
            this.btnRemoveWord.Name = "btnRemoveWord";
            this.btnRemoveWord.Size = new System.Drawing.Size(114, 23);
            this.btnRemoveWord.TabIndex = 5;
            this.btnRemoveWord.Text = "Remove word";
            this.btnRemoveWord.UseVisualStyleBackColor = true;
            this.btnRemoveWord.Visible = false;
            this.btnRemoveWord.Click += new System.EventHandler(this.BtnRemoveWord_Click);
            // 
            // tbWordsIn
            // 
            this.tbWordsIn.Location = new System.Drawing.Point(43, 233);
            this.tbWordsIn.Name = "tbWordsIn";
            this.tbWordsIn.Size = new System.Drawing.Size(245, 22);
            this.tbWordsIn.TabIndex = 7;
            this.tbWordsIn.Visible = false;
            // 
            // tbWordsOu
            // 
            this.tbWordsOu.Location = new System.Drawing.Point(321, 233);
            this.tbWordsOu.Name = "tbWordsOu";
            this.tbWordsOu.Size = new System.Drawing.Size(245, 22);
            this.tbWordsOu.TabIndex = 8;
            this.tbWordsOu.Visible = false;
            // 
            // rbIwannaAdd
            // 
            this.rbIwannaAdd.AutoSize = true;
            this.rbIwannaAdd.Location = new System.Drawing.Point(178, 201);
            this.rbIwannaAdd.Name = "rbIwannaAdd";
            this.rbIwannaAdd.Size = new System.Drawing.Size(88, 21);
            this.rbIwannaAdd.TabIndex = 9;
            this.rbIwannaAdd.TabStop = true;
            this.rbIwannaAdd.Text = "Add word";
            this.rbIwannaAdd.UseVisualStyleBackColor = true;
            this.rbIwannaAdd.CheckedChanged += new System.EventHandler(this.RbIwannaAdd_CheckedChanged);
            // 
            // rbIwannaDelete
            // 
            this.rbIwannaDelete.AutoSize = true;
            this.rbIwannaDelete.Location = new System.Drawing.Point(321, 201);
            this.rbIwannaDelete.Name = "rbIwannaDelete";
            this.rbIwannaDelete.Size = new System.Drawing.Size(108, 21);
            this.rbIwannaDelete.TabIndex = 10;
            this.rbIwannaDelete.TabStop = true;
            this.rbIwannaDelete.Text = "Delete Word";
            this.rbIwannaDelete.UseVisualStyleBackColor = true;
            this.rbIwannaDelete.CheckedChanged += new System.EventHandler(this.RbIwannaDelete_CheckedChanged);
            // 
            // _DictionaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 267);
            this.Controls.Add(this.rbIwannaDelete);
            this.Controls.Add(this.rbIwannaAdd);
            this.Controls.Add(this.tbWordsOu);
            this.Controls.Add(this.tbWordsIn);
            this.Controls.Add(this.btnRemoveWord);
            this.Controls.Add(this.btnAddNewWord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Name = "_DictionaryForm";
            this.Text = " Dictionary";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddNewWord;
        private System.Windows.Forms.Button btnRemoveWord;
        private System.Windows.Forms.TextBox tbWordsIn;
        private System.Windows.Forms.TextBox tbWordsOu;
        private System.Windows.Forms.RadioButton rbIwannaAdd;
        private System.Windows.Forms.RadioButton rbIwannaDelete;
    }
}