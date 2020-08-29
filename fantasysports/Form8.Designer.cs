namespace fantasysports
{
    partial class Form8
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
            this.TurnierID_input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Wettbewerb_combobox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Info_lbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TurnierID_input
            // 
            this.TurnierID_input.Location = new System.Drawing.Point(126, 24);
            this.TurnierID_input.Name = "TurnierID_input";
            this.TurnierID_input.Size = new System.Drawing.Size(214, 20);
            this.TurnierID_input.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "TurnierID eingeben";
            // 
            // Wettbewerb_combobox
            // 
            this.Wettbewerb_combobox.FormattingEnabled = true;
            this.Wettbewerb_combobox.Items.AddRange(new object[] {
            "Weekly_Monster_PL"});
            this.Wettbewerb_combobox.Location = new System.Drawing.Point(126, 61);
            this.Wettbewerb_combobox.Name = "Wettbewerb_combobox";
            this.Wettbewerb_combobox.Size = new System.Drawing.Size(214, 21);
            this.Wettbewerb_combobox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Turnierform";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(313, 58);
            this.button1.TabIndex = 13;
            this.button1.Text = "DB upload";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Info_lbl
            // 
            this.Info_lbl.AutoSize = true;
            this.Info_lbl.Location = new System.Drawing.Point(74, 100);
            this.Info_lbl.Name = "Info_lbl";
            this.Info_lbl.Size = new System.Drawing.Size(28, 13);
            this.Info_lbl.TabIndex = 16;
            this.Info_lbl.Text = "Info:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 18;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(25, 208);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(315, 58);
            this.button2.TabIndex = 19;
            this.button2.Text = "Optimierung durchführen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(25, 282);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(315, 58);
            this.button3.TabIndex = 20;
            this.button3.Text = "Team DB download";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 367);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Info_lbl);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Wettbewerb_combobox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TurnierID_input);
            this.Name = "Form8";
            this.Text = "FantasySportsScrapper v 1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TurnierID_input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Wettbewerb_combobox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Info_lbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}