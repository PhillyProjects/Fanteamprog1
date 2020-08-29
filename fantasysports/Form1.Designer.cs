namespace fantasysports
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.data_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.referenz_btn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // data_btn
            // 
            this.data_btn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.data_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.data_btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.data_btn.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.data_btn.ForeColor = System.Drawing.Color.Black;
            this.data_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.data_btn.Location = new System.Drawing.Point(12, 12);
            this.data_btn.Name = "data_btn";
            this.data_btn.Size = new System.Drawing.Size(364, 50);
            this.data_btn.TabIndex = 1;
            this.data_btn.Text = "Fanteam upload";
            this.data_btn.UseVisualStyleBackColor = false;
            this.data_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.button1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(12, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(364, 50);
            this.button1.TabIndex = 2;
            this.button1.Text = "Rotowire upload";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // referenz_btn
            // 
            this.referenz_btn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.referenz_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.referenz_btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.referenz_btn.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.referenz_btn.ForeColor = System.Drawing.Color.Black;
            this.referenz_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.referenz_btn.Location = new System.Drawing.Point(12, 124);
            this.referenz_btn.Name = "referenz_btn";
            this.referenz_btn.Size = new System.Drawing.Size(364, 50);
            this.referenz_btn.TabIndex = 5;
            this.referenz_btn.Text = "Referenztabelle verwalten";
            this.referenz_btn.UseVisualStyleBackColor = false;
            this.referenz_btn.Click += new System.EventHandler(this.referenz_btn_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Cross;
            this.button2.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(12, 180);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(364, 50);
            this.button2.TabIndex = 6;
            this.button2.Text = "Team generieren";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(391, 241);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.referenz_btn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.data_btn);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "FantasySportsScrapper v 1.0";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button data_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button referenz_btn;
        private System.Windows.Forms.Button button2;
    }
}

