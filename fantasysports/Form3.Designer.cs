namespace fantasysports
{
    partial class Form3
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
            this.uploadfanteam_btn = new System.Windows.Forms.Button();
            this.FanteamUrl_input = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Wettbewerb_combobox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AnzahlSeiten_input = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.status_lbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.TurnierID_eingabe = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // uploadfanteam_btn
            // 
            this.uploadfanteam_btn.Location = new System.Drawing.Point(523, 58);
            this.uploadfanteam_btn.Name = "uploadfanteam_btn";
            this.uploadfanteam_btn.Size = new System.Drawing.Size(122, 61);
            this.uploadfanteam_btn.TabIndex = 0;
            this.uploadfanteam_btn.Text = "upload";
            this.uploadfanteam_btn.UseVisualStyleBackColor = true;
            this.uploadfanteam_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // FanteamUrl_input
            // 
            this.FanteamUrl_input.Location = new System.Drawing.Point(89, 60);
            this.FanteamUrl_input.Name = "FanteamUrl_input";
            this.FanteamUrl_input.Size = new System.Drawing.Size(427, 20);
            this.FanteamUrl_input.TabIndex = 2;
            this.FanteamUrl_input.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Wettbewerb:";
            // 
            // Wettbewerb_combobox
            // 
            this.Wettbewerb_combobox.FormattingEnabled = true;
            this.Wettbewerb_combobox.Location = new System.Drawing.Point(89, 143);
            this.Wettbewerb_combobox.Name = "Wettbewerb_combobox";
            this.Wettbewerb_combobox.Size = new System.Drawing.Size(121, 21);
            this.Wettbewerb_combobox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Fanteam Url:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Anzahl Seiten:";
            // 
            // AnzahlSeiten_input
            // 
            this.AnzahlSeiten_input.Location = new System.Drawing.Point(89, 101);
            this.AnzahlSeiten_input.Name = "AnzahlSeiten_input";
            this.AnzahlSeiten_input.Size = new System.Drawing.Size(36, 20);
            this.AnzahlSeiten_input.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(147, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "TurnierID:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Status:";
            // 
            // status_lbl
            // 
            this.status_lbl.AutoSize = true;
            this.status_lbl.Location = new System.Drawing.Point(89, 25);
            this.status_lbl.Name = "status_lbl";
            this.status_lbl.Size = new System.Drawing.Size(13, 13);
            this.status_lbl.TabIndex = 19;
            this.status_lbl.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(235, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Neuer Eintrag:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(316, 143);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(198, 20);
            this.textBox1.TabIndex = 22;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(523, 138);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(122, 25);
            this.button4.TabIndex = 26;
            this.button4.Text = "Aktualisieren";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // TurnierID_eingabe
            // 
            this.TurnierID_eingabe.Location = new System.Drawing.Point(207, 101);
            this.TurnierID_eingabe.Name = "TurnierID_eingabe";
            this.TurnierID_eingabe.Size = new System.Drawing.Size(120, 20);
            this.TurnierID_eingabe.TabIndex = 29;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(658, 186);
            this.Controls.Add(this.TurnierID_eingabe);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.status_lbl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AnzahlSeiten_input);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Wettbewerb_combobox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FanteamUrl_input);
            this.Controls.Add(this.uploadfanteam_btn);
            this.Name = "Form3";
            this.Text = "FantasySportsScrapper v 1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uploadfanteam_btn;
        private System.Windows.Forms.TextBox FanteamUrl_input;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox Wettbewerb_combobox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox AnzahlSeiten_input;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label status_lbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox TurnierID_eingabe;
    }
}