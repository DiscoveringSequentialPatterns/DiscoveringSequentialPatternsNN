namespace URL_Pattern
{
    partial class Form1
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
            this.tBMaxPatterLen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tBPatternCount = new System.Windows.Forms.TextBox();
            this.cBPatternFixedLen = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tBMaxWordCount = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tBAllRecordsCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tBMinPatterLen = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tBSigleRowLength = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tBMAXLiczbaPowtorzenWzorcawRekordzie = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tBMakOdstepMiedzySekwencjami = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tBMaxPatterLen
            // 
            this.tBMaxPatterLen.Location = new System.Drawing.Point(413, 27);
            this.tBMaxPatterLen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tBMaxPatterLen.Name = "tBMaxPatterLen";
            this.tBMaxPatterLen.Size = new System.Drawing.Size(132, 22);
            this.tBMaxPatterLen.TabIndex = 0;
            this.tBMaxPatterLen.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(409, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "MAX Długość wzorca";
            // 
            // tBPatternCount
            // 
            this.tBPatternCount.Location = new System.Drawing.Point(345, 100);
            this.tBPatternCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tBPatternCount.Name = "tBPatternCount";
            this.tBPatternCount.Size = new System.Drawing.Size(132, 22);
            this.tBPatternCount.TabIndex = 3;
            this.tBPatternCount.Text = "5";
            // 
            // cBPatternFixedLen
            // 
            this.cBPatternFixedLen.AutoSize = true;
            this.cBPatternFixedLen.Location = new System.Drawing.Point(29, 71);
            this.cBPatternFixedLen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBPatternFixedLen.Name = "cBPatternFixedLen";
            this.cBPatternFixedLen.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cBPatternFixedLen.Size = new System.Drawing.Size(176, 21);
            this.cBPatternFixedLen.TabIndex = 4;
            this.cBPatternFixedLen.Text = "Stała długość Wzorców";
            this.cBPatternFixedLen.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Liczba różnych wzorców (ile sekwencji)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 142);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(297, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Liczba różnych rozpatrywanych słów/podstron";
            // 
            // tBMaxWordCount
            // 
            this.tBMaxWordCount.Location = new System.Drawing.Point(345, 135);
            this.tBMaxWordCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tBMaxWordCount.Name = "tBMaxWordCount";
            this.tBMaxWordCount.Size = new System.Drawing.Size(132, 22);
            this.tBMaxWordCount.TabIndex = 6;
            this.tBMaxWordCount.Text = "5";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(29, 23);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(205, 58);
            this.button2.TabIndex = 9;
            this.button2.Text = "Zapisz wygenerowane wzorce do Pliku (z reach)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 172);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Liczba Wektorow uczących";
            // 
            // tBAllRecordsCount
            // 
            this.tBAllRecordsCount.Location = new System.Drawing.Point(344, 169);
            this.tBAllRecordsCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tBAllRecordsCount.Name = "tBAllRecordsCount";
            this.tBAllRecordsCount.Size = new System.Drawing.Size(132, 22);
            this.tBAllRecordsCount.TabIndex = 10;
            this.tBAllRecordsCount.Text = "50";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(323, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Minimalna długość wzorca (liczba liczb we wzorcu)";
            this.label5.UseWaitCursor = true;
            // 
            // tBMinPatterLen
            // 
            this.tBMinPatterLen.Location = new System.Drawing.Point(31, 31);
            this.tBMinPatterLen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tBMinPatterLen.Name = "tBMinPatterLen";
            this.tBMinPatterLen.Size = new System.Drawing.Size(132, 22);
            this.tBMinPatterLen.TabIndex = 13;
            this.tBMinPatterLen.Text = "5";
            this.tBMinPatterLen.UseWaitCursor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(667, 23);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(357, 58);
            this.button3.TabIndex = 15;
            this.button3.Text = "Konwertuj na 1 z N";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(0, 246);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 28);
            this.button4.TabIndex = 16;
            this.button4.Text = "generuj";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 204);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(292, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Rozmiar Poj Wiersza (ile max liczb w wierszu)";
            // 
            // tBSigleRowLength
            // 
            this.tBSigleRowLength.Location = new System.Drawing.Point(344, 203);
            this.tBSigleRowLength.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tBSigleRowLength.Name = "tBSigleRowLength";
            this.tBSigleRowLength.Size = new System.Drawing.Size(132, 22);
            this.tBSigleRowLength.TabIndex = 17;
            this.tBSigleRowLength.Text = "50";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(253, 246);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(379, 28);
            this.button1.TabIndex = 19;
            this.button1.Text = "Generuj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 574);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1220, 123);
            this.panel1.TabIndex = 20;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(303, 38);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(209, 43);
            this.button5.TabIndex = 16;
            this.button5.Text = "Zapisz wygenerowane wzorce do Pliku";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBox1.Location = new System.Drawing.Point(0, 278);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1220, 296);
            this.richTextBox1.TabIndex = 21;
            this.richTextBox1.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(688, 151);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(884, 124);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(185, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "Błędnie generowane wzorce";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(888, 151);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "label9";
            // 
            // tBMAXLiczbaPowtorzenWzorcawRekordzie
            // 
            this.tBMAXLiczbaPowtorzenWzorcawRekordzie.Location = new System.Drawing.Point(744, 31);
            this.tBMAXLiczbaPowtorzenWzorcawRekordzie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tBMAXLiczbaPowtorzenWzorcawRekordzie.Name = "tBMAXLiczbaPowtorzenWzorcawRekordzie";
            this.tBMAXLiczbaPowtorzenWzorcawRekordzie.Size = new System.Drawing.Size(132, 22);
            this.tBMAXLiczbaPowtorzenWzorcawRekordzie.TabIndex = 25;
            this.tBMAXLiczbaPowtorzenWzorcawRekordzie.Text = "3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(744, 7);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(327, 17);
            this.label10.TabIndex = 26;
            this.label10.Text = "Maksymalna liczba powtórzeń wzorca   w rekordzie";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(649, 123);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(196, 17);
            this.label11.TabIndex = 27;
            this.label11.Text = "Numer generowanego wzorca";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(741, 57);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(263, 17);
            this.label12.TabIndex = 29;
            this.label12.Text = "Maksymalny odstęp miedzy sekwencjami";
            // 
            // tBMakOdstepMiedzySekwencjami
            // 
            this.tBMakOdstepMiedzySekwencjami.Location = new System.Drawing.Point(741, 81);
            this.tBMakOdstepMiedzySekwencjami.Margin = new System.Windows.Forms.Padding(4);
            this.tBMakOdstepMiedzySekwencjami.Name = "tBMakOdstepMiedzySekwencjami";
            this.tBMakOdstepMiedzySekwencjami.Size = new System.Drawing.Size(132, 22);
            this.tBMakOdstepMiedzySekwencjami.TabIndex = 28;
            this.tBMakOdstepMiedzySekwencjami.Text = "10";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 697);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tBMakOdstepMiedzySekwencjami);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tBMAXLiczbaPowtorzenWzorcawRekordzie);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tBSigleRowLength);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tBMinPatterLen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tBAllRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tBMaxWordCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cBPatternFixedLen);
            this.Controls.Add(this.tBPatternCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tBMaxPatterLen);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBMaxPatterLen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBPatternCount;
        private System.Windows.Forms.CheckBox cBPatternFixedLen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBMaxWordCount;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBAllRecordsCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tBMinPatterLen;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tBSigleRowLength;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tBMAXLiczbaPowtorzenWzorcawRekordzie;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tBMakOdstepMiedzySekwencjami;
    }
}

